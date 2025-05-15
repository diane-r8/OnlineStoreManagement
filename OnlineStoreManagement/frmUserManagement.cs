using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace OnlineStoreManagement
{
    public partial class frmUserManagement : Form
    {
        // Guard to prevent update logic from running after a successful update
        private bool isUpdatingUser = false;

        public frmUserManagement()
        {
            InitializeComponent();
            tabControlUserManager.SelectedIndexChanged += tabControlUserManager_SelectedIndexChanged;
            btnExport.Click += btnExport_Click;
            btnBack.Click += (s, e) => this.Close();
            btnBack2.Click += (s, e) => this.Close();
            btnBack3.Click += (s, e) => this.Close();
            btnBack4.Click += (s, e) => this.Close();
            btnSaveAccount.Click += btnSaveAccount_Click;
            btnUpdateUser.Click += btnUpdateUser_Click;
            btnSearchbyUsernameUpdate.Click += btnSearchbyUsernameUpdate_Click;
            btnSearchbyUsernameDelete.Click += btnSearchbyUsernameDelete_Click;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            this.Load += frmUserManagement_Load;
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            LoadRoles();
            btnUpdateUser.Enabled = true;
        }

        private void LoadRoles()
        {
            comboBoxRole.Items.Clear();
            comboBoxRoleUpdate.Items.Clear();
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT role_name FROM roles ORDER BY role_name";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string role = reader["role_name"].ToString();
                        comboBoxRole.Items.Add(role);
                        comboBoxRoleUpdate.Items.Add(role);
                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // --- ADD USER ---
        private int? GetRoleIdByName(string roleName)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT role_id FROM roles WHERE role_name = @roleName LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@roleName", roleName);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : (int?)null;
            }
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string roleName = comboBoxRole.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int? roleId = GetRoleIdByName(roleName);
            if (roleId == null)
            {
                MessageBox.Show("Selected role does not exist.", "Role Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Check for duplicate username/email
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username=@username OR email=@email";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", username);
                checkCmd.Parameters.AddWithValue("@email", email);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (exists > 0)
                {
                    MessageBox.Show("Username or email already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string insertQuery = "INSERT INTO users (username, password, email, role_id) VALUES (@username, @password, @email, @role_id)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // NOTE: hash in production
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@role_id", roleId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Text = txtPassword.Text = txtEmail.Text = comboBoxRole.Text = "";
            }
        }

        // --- UPDATE USER ---
        private void btnSearchbyUsernameUpdate_Click(object sender, EventArgs e)
        {
            string username = txtSearchbyUsernameUpdate.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT u.*, r.role_name FROM users u LEFT JOIN roles r ON u.role_id = r.role_id WHERE u.username=@username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtUsernameUpdate.Text = reader["username"].ToString();
                        txtPasswordUpdate.Text = reader["password"].ToString();
                        txtEmailUpdate.Text = reader["email"].ToString();
                        comboBoxRoleUpdate.Text = reader["role_name"].ToString();
                        txtUsernameUpdate.Tag = reader["user_id"];
                        btnUpdateUser.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("User not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnUpdateUser.Enabled = false;
                        txtUsernameUpdate.Tag = null;
                    }
                }
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (isUpdatingUser || !btnUpdateUser.Enabled) return;
            if (txtUsernameUpdate.Tag == null)
            {
                MessageBox.Show("Please search for a user first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Move focus and disable button immediately after validation
            btnUpdateUser.Enabled = false;
            txtSearchbyUsernameUpdate.Focus();
            isUpdatingUser = true;
            int userId = Convert.ToInt32(txtUsernameUpdate.Tag);
            string username = txtUsernameUpdate.Text.Trim();
            string password = txtPasswordUpdate.Text.Trim();
            string email = txtEmailUpdate.Text.Trim();
            string roleName = comboBoxRoleUpdate.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(roleName))
            {
                isUpdatingUser = false;
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                isUpdatingUser = false;
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int? roleId = GetRoleIdByName(roleName);
            if (roleId == null)
            {
                isUpdatingUser = false;
                MessageBox.Show("Selected role does not exist.", "Role Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                // Check for duplicate username/email (exclude current user)
                string checkQuery = "SELECT COUNT(*) FROM users WHERE (username=@username OR email=@email) AND user_id<>@id";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", username);
                checkCmd.Parameters.AddWithValue("@email", email);
                checkCmd.Parameters.AddWithValue("@id", userId);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (exists > 0)
                {
                    isUpdatingUser = false;
                    MessageBox.Show("Username or email already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string updateQuery = "UPDATE users SET username=@username, password=@password, email=@email, role_id=@role_id WHERE user_id=@id";
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // NOTE: hash in production
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@role_id", roleId);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsernameUpdate.Text = txtPasswordUpdate.Text = txtEmailUpdate.Text = comboBoxRoleUpdate.Text = txtSearchbyUsernameUpdate.Text = "";
                txtUsernameUpdate.Tag = null;
                isUpdatingUser = false;
            }
        }

        // --- DELETE USER ---
        private void btnSearchbyUsernameDelete_Click(object sender, EventArgs e)
        {
            string username = txtSearchbyUsernameDelete.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT u.*, r.role_name FROM users u LEFT JOIN roles r ON u.role_id = r.role_id WHERE u.username=@username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string roleName = "(No Role)";
                        try { roleName = reader["role_name"] == DBNull.Value ? "(No Role)" : reader["role_name"].ToString(); } catch { roleName = "(No Role)"; }
                        MessageBox.Show($"User found.\nUsername: {reader["username"]}\nEmail: {reader["email"]}\nRole: {roleName}", "User Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnDeleteAccount.Enabled = true;
                        btnDeleteAccount.Tag = reader["user_id"];
                    }
                    else
                    {
                        MessageBox.Show("User not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnDeleteAccount.Enabled = false;
                        btnDeleteAccount.Tag = null;
                    }
                }
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (btnDeleteAccount.Tag == null)
            {
                MessageBox.Show("Please search for a user first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int userId = Convert.ToInt32(btnDeleteAccount.Tag);
            var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM users WHERE user_id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User not found or already deleted.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtSearchbyUsernameDelete.Text = "";
                btnDeleteAccount.Enabled = false;
                btnDeleteAccount.Tag = null;
            }
        }

        // --- VIEW USERS LIST ---
        private void tabControlUserManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlUserManager.SelectedTab == tabPageViewAccountsList)
            {
                LoadUsersList();
            }
        }

        private void LoadUsersList()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT u.user_id, u.username, u.email, r.role_name, u.created_at, u.updated_at FROM users u LEFT JOIN roles r ON u.role_id = r.role_id";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewAccountsList.DataSource = dt;
            }
        }

        // --- EXPORT TO EXCEL (CSV) ---
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewAccountsList.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "Users.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        // Write headers
                        for (int i = 0; i < dataGridViewAccountsList.Columns.Count; i++)
                        {
                            sb.Append('"' + dataGridViewAccountsList.Columns[i].HeaderText + '"');
                            if (i < dataGridViewAccountsList.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();
                        // Write data
                        foreach (DataGridViewRow row in dataGridViewAccountsList.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataGridViewAccountsList.Columns.Count; i++)
                                {
                                    object value = row.Cells[i].Value;
                                    if (dataGridViewAccountsList.Columns[i].HeaderText.ToLower().Contains("date") && value is DateTime dt)
                                    {
                                        sb.Append('"' + dt.ToString("yyyy-MM-dd HH:mm:ss") + '"');
                                    }
                                    else
                                    {
                                        var strValue = value?.ToString().Replace("\"", "\"\"");
                                        sb.Append('"' + strValue + '"');
                                    }
                                    if (i < dataGridViewAccountsList.Columns.Count - 1) sb.Append(",");
                                }
                                sb.AppendLine();
                            }
                        }
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Exported successfully! Excel will now open the file.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            System.Diagnostics.Process.Start("excel.exe", '"' + sfd.FileName + '"');
                        }
                        catch (Exception)
                        {
                            try { System.Diagnostics.Process.Start(sfd.FileName); }
                            catch (Exception) { MessageBox.Show("Could not open the file automatically. Please open it manually from the saved location.", "Open File", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An unexpected error occurred while exporting. Please try again.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- HELPERS ---
        private bool IsValidEmail(string email)
        {
            try { var addr = new System.Net.Mail.MailAddress(email); return addr.Address == email; }
            catch { return false; }
        }
    }
}

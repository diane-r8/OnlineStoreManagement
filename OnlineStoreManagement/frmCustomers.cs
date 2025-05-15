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

namespace OnlineStoreManagement
{
    public partial class frmCustomers: Form
    {
        public frmCustomers()
        {
            InitializeComponent();
            tabControlUserManager.SelectedIndexChanged += tabControlUserManager_SelectedIndexChanged;
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT customer_id, first_name, last_name, email, phone, address FROM customers";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    var dgv = this.Controls.Find("dataGridViewCustomersList", true).FirstOrDefault() as DataGridView;
                    if (dgv != null)
                        dgv.DataSource = dt;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Unable to connect to the database. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("An unexpected error occurred. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Helper method for duplicate email error
        private void ShowDuplicateEmailError()
        {
            MessageBox.Show("The email address you entered is already registered. Please use a different email.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool EmailExists(string email, int? excludeCustomerId = null)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = excludeCustomerId == null
                    ? "SELECT COUNT(*) FROM customers WHERE TRIM(LOWER(email)) = TRIM(LOWER(@email))"
                    : "SELECT COUNT(*) FROM customers WHERE TRIM(LOWER(email)) = TRIM(LOWER(@email)) AND customer_id <> @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email.Trim().ToLower());
                if (excludeCustomerId != null)
                    cmd.Parameters.AddWithValue("@id", excludeCustomerId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateCustomerFields(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("First name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Last name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ADD CUSTOMER
        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text;
            string address = txtAddress.Text;

            // Standard validation
            if (!ValidateCustomerFields(firstName, lastName, email))
                return;

            // Pre-check for duplicate email (case-insensitive, trimmed)
            if (EmailExists(email))
            {
                ShowDuplicateEmailError();
                return;
            }

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO customers (first_name, last_name, email, phone, address) VALUES (@first, @last, @email, @phone, @address)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@first", firstName);
                    cmd.Parameters.AddWithValue("@last", lastName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer added successfully!");
                    LoadCustomers();
                    ClearFields();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Unable to add customer. Please check your input or try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("An unexpected error occurred. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // SEARCH CUSTOMER FOR UPDATE
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            string searchName = txtUpdateSearchbyName.Text;
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM customers WHERE first_name LIKE @name OR last_name LIKE @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", "%" + searchName + "%");
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtUpdateFirstName.Text = reader["first_name"].ToString();
                        txtUpdateLastName.Text = reader["last_name"].ToString();
                        txtUpdatePhone.Text = reader["phone"].ToString();
                        txtUpdateEmail.Text = reader["email"].ToString();
                        txtUpdateAddress.Text = reader["address"].ToString();
                        txtUpdateFirstName.Tag = reader["customer_id"];
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Unable to connect to the database. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("An unexpected error occurred. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // UPDATE CUSTOMER
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (txtUpdateFirstName.Tag == null)
            {
                MessageBox.Show("Please search and select a customer to update.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(txtUpdateFirstName.Tag);
            string firstName = txtUpdateFirstName.Text;
            string lastName = txtUpdateLastName.Text;
            string email = txtUpdateEmail.Text.Trim();
            string phone = txtUpdatePhone.Text;
            string address = txtUpdateAddress.Text;

            // Pre-check for duplicate email (case-insensitive, trimmed, exclude current customer)
            if (EmailExists(email, id))
            {
                ShowDuplicateEmailError();
                return;
            }

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE customers SET first_name=@first, last_name=@last, email=@email, phone=@phone, address=@address WHERE customer_id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@first", firstName);
                    cmd.Parameters.AddWithValue("@last", lastName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer updated successfully!");
                    LoadCustomers();
                    ClearFields();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Unable to update customer. Please check your input or try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("An unexpected error occurred. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // SEARCH CUSTOMER FOR DELETE
        private void button4_Click(object sender, EventArgs e)
        {
            string searchName = txtDeleteSearchByName.Text;
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM customers WHERE first_name LIKE @name OR last_name LIKE @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", "%" + searchName + "%");
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtDeleteSearchByName.Tag = reader["customer_id"];
                        MessageBox.Show($"Customer found: {reader["first_name"]} {reader["last_name"]}", "Customer Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Unable to connect to the database. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("An unexpected error occurred. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // DELETE CUSTOMER
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (txtDeleteSearchByName.Tag == null)
            {
                MessageBox.Show("Please search and select a customer to delete.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(txtDeleteSearchByName.Tag);
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM customers WHERE customer_id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer deleted successfully!");
                    LoadCustomers();
                    ClearFields();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Unable to delete customer. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("An unexpected error occurred. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearchbyName_Click(object sender, EventArgs e)
        {
            btnSearchUser_Click(sender, e);
        }

        private void btnDeleteSearchbyName_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void btnExportCustomersList_Click(object sender, EventArgs e)
        {
            btnExport_Click(sender, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Helper method for user-friendly error messages
        private void ShowUserError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var dgv = this.Controls.Find("dataGridViewCustomersList", true).FirstOrDefault() as DataGridView;
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "Customers.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sb.Append(dgv.Columns[i].HeaderText);
                            if (i < dgv.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dgv.Columns.Count; i++)
                                {
                                    sb.Append(row.Cells[i].Value?.ToString().Replace(",", " "));
                                    if (i < dgv.Columns.Count - 1) sb.Append(",");
                                }
                                sb.AppendLine();
                            }
                        }
                        System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
                        try
                        {
                            System.Diagnostics.Process.Start(sfd.FileName);
                            MessageBox.Show("Exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            ShowUserError("Could not open the file automatically. Please open it manually from the saved location.", "Open File");
                        }
                    }
                    catch (Exception)
                    {
                        ShowUserError("An unexpected error occurred while exporting. Please try again.", "Export Error");
                    }
                }
            }
        }

        private void tabControlUserManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlUserManager.SelectedTab == tabPageViewAccountsList)
            {
                LoadCustomers();
            }
        }

        private void ClearFields()
        {
            // Add Customer tab
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            // Update Customer tab
            txtUpdateFirstName.Text = "";
            txtUpdateLastName.Text = "";
            txtUpdateEmail.Text = "";
            txtUpdatePhone.Text = "";
            txtUpdateAddress.Text = "";
            txtUpdateSearchbyName.Text = "";
            txtUpdateFirstName.Tag = null;
            // Delete Customer tab
            txtDeleteSearchByName.Text = "";
            txtDeleteSearchByName.Tag = null;
        }
    }
}


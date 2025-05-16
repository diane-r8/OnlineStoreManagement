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
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT user_id, username FROM users WHERE email=@Email";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("No account found with that email address.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        string foundUsername = reader["username"].ToString();
                        MessageBox.Show($"Account found. Username: {foundUsername}\nPlease enter your new password.", "Account Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.Close();
                var changePasswordForm = new frmChangePassword(email);
                changePasswordForm.ShowDialog();
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new frmLogin();
            loginForm.Show();
        }

        private bool IsValidEmail(string email)
        {
            try { var addr = new System.Net.Mail.MailAddress(email); return addr.Address == email; }
            catch { return false; }
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            // Optional: focus email textbox
            txtEmail.Focus();
        }
    }
}

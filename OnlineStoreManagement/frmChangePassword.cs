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
    public partial class frmChangePassword : Form
    {
        private string _email;
        public frmChangePassword(string email)
        {
            InitializeComponent();
            _email = email;
            btnChangePassword.Click += btnChangePassword_Click;
            btnBackToLogin.Click += btnBackToLogin_Click;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please enter both new password and confirm password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string updateQuery = "UPDATE users SET password=@Password WHERE email=@Email";
                using (var cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Password", newPassword); // In production, hash this
                    cmd.Parameters.AddWithValue("@Email", _email);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Do NOT close the form here; let the user click Back to Login
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            // Close the forgot password form if it's open
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmForgotPassword)
                {
                    form.Close();
                    break;
                }
            }
            // Bring the dashboard to the front if it's open
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmDashboard")
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    break;
                }
            }
            this.Close();
        }
    }
}

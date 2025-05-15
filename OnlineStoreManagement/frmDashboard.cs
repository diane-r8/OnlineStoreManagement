using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStoreManagement
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            frmCustomers customersForm = new frmCustomers();
            customersForm.Show();
        }

        private void btnProductManagement_Click(object sender, EventArgs e)
        {
            frmProducts productsForm = new frmProducts();
            productsForm.Show();
        }

        private void btnOrderManagement_Click(object sender, EventArgs e)
        {
            frmOrders ordersForm = new frmOrders();
            ordersForm.Show();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            frmUserManagement userManagementForm = new frmUserManagement();
            userManagementForm.Show();
        }

        private void btnReportsManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnPaymentManagement_Click(object sender, EventArgs e)
        {
            frmPayments paymentsForm = new frmPayments();
            paymentsForm.Show();
        }

        private void btnReviewManagement_Click(object sender, EventArgs e)
        {
            frmReviews reviewsForm = new frmReviews();
            reviewsForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
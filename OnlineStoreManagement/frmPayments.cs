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
using System.Diagnostics;

namespace OnlineStoreManagement
{
    public partial class frmPayments: Form
    {
        public frmPayments()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            btnSearchFilter.Click += btnSearchFilter_Click;
            btnResetSearchFilter.Click += btnResetSearchFilter_Click;
            btnExport.Click += btnExport_Click;
            comboBoxPayementMethodFilter.SelectedIndexChanged += comboBoxPayementMethodFilter_SelectedIndexChanged;
            comboBoxPaymentStatusFilter.SelectedIndexChanged += comboBoxPaymentStatusFilter_SelectedIndexChanged;
            // Populate filter combo boxes
            LoadPaymentMethodFilter();
            LoadPaymentStatusFilter();
            // Always populate combo boxes when the form opens
            LoadOrderIDs();
            LoadPaymentMethodCombo(comboBoxPaymentMethod);
            LoadPaymentStatusCombo(comboBoxStatus);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage4)
            {
                LoadPaymentsList();
            }
            else if (tabControl1.SelectedTab == tabPage1)
            {
                LoadOrderIDs();
                LoadPaymentMethodCombo(comboBoxPaymentMethod);
                LoadPaymentStatusCombo(comboBoxStatus);
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                LoadOrderIDsUpdate();
                LoadPaymentMethodCombo(comboBoxPaymentMethodUpdate);
                LoadPaymentStatusCombo(comboBoxStatusUpdate);
            }
        }

        private void LoadPaymentsList(string orderId = "", string method = "All", string status = "All")
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var query = new StringBuilder("SELECT payment_id, order_id, payment_date, amount, payment_method, status FROM payments WHERE 1=1");
                if (!string.IsNullOrWhiteSpace(orderId))
                    query.Append(" AND order_id = @orderId");
                if (!string.IsNullOrWhiteSpace(method) && method != "All")
                    query.Append(" AND payment_method = @method");
                if (!string.IsNullOrWhiteSpace(status) && status != "All")
                    query.Append(" AND status = @status");
                using (var cmd = new MySqlCommand(query.ToString(), conn))
                {
                    if (!string.IsNullOrWhiteSpace(orderId))
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                    if (!string.IsNullOrWhiteSpace(method) && method != "All")
                        cmd.Parameters.AddWithValue("@method", method);
                    if (!string.IsNullOrWhiteSpace(status) && status != "All")
                        cmd.Parameters.AddWithValue("@status", status);
                    var dt = new DataTable();
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        dataGridViewPaymentsList.DataSource = dt;
                    }
                }
            }
        }

        private void btnSearchFilter_Click(object sender, EventArgs e)
        {
            LoadPaymentsList(txtOrderSearch.Text.Trim(), comboBoxPayementMethodFilter.Text, comboBoxPaymentStatusFilter.Text);
        }

        private void btnResetSearchFilter_Click(object sender, EventArgs e)
        {
            txtOrderSearch.Text = "";
            comboBoxPayementMethodFilter.SelectedIndex = 0;
            comboBoxPaymentStatusFilter.SelectedIndex = 0;
            LoadPaymentsList();
        }

        private void comboBoxPayementMethodFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearchFilter_Click(sender, e);
        }

        private void comboBoxPaymentStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearchFilter_Click(sender, e);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewPaymentsList.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "Payments.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        // Write headers
                        for (int i = 0; i < dataGridViewPaymentsList.Columns.Count; i++)
                        {
                            sb.Append('"' + dataGridViewPaymentsList.Columns[i].HeaderText + '"');
                            if (i < dataGridViewPaymentsList.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();
                        // Write data
                        foreach (DataGridViewRow row in dataGridViewPaymentsList.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataGridViewPaymentsList.Columns.Count; i++)
                                {
                                    object value = row.Cells[i].Value;
                                    if (dataGridViewPaymentsList.Columns[i].HeaderText.ToLower().Contains("date") && value is DateTime dt)
                                    {
                                        sb.Append('"' + dt.ToString("yyyy-MM-dd HH:mm:ss") + '"');
                                    }
                                    else
                                    {
                                        var strValue = value?.ToString().Replace("\"", "\"\"");
                                        sb.Append('"' + strValue + '"');
                                    }
                                    if (i < dataGridViewPaymentsList.Columns.Count - 1) sb.Append(",");
                                }
                                sb.AppendLine();
                            }
                        }
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Exported successfully! Excel will now open the file.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            Process.Start("excel.exe", '"' + sfd.FileName + '"');
                        }
                        catch (Exception)
                        {
                            try { Process.Start(sfd.FileName); }
                            catch (Exception) { MessageBox.Show("Could not open the file automatically. Please open it manually from the saved location.", "Open File", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadPaymentMethodFilter()
        {
            comboBoxPayementMethodFilter.Items.Clear();
            comboBoxPayementMethodFilter.Items.Add("All");
            comboBoxPayementMethodFilter.Items.Add("GCash");
            comboBoxPayementMethodFilter.Items.Add("Credit Card");
            comboBoxPayementMethodFilter.Items.Add("Bank Transfer");
            comboBoxPayementMethodFilter.Items.Add("COD");
            comboBoxPayementMethodFilter.SelectedIndex = 0;
        }

        private void LoadPaymentStatusFilter()
        {
            comboBoxPaymentStatusFilter.Items.Clear();
            comboBoxPaymentStatusFilter.Items.Add("All");
            comboBoxPaymentStatusFilter.Items.Add("Completed");
            comboBoxPaymentStatusFilter.Items.Add("Pending");
            comboBoxPaymentStatusFilter.Items.Add("Refunded");
            comboBoxPaymentStatusFilter.SelectedIndex = 0;
        }

        private void LoadOrderIDs()
        {
            comboBoxOrderID.Items.Clear();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT order_id FROM orders ORDER BY order_id ASC", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxOrderID.Items.Add(reader["order_id"].ToString());
                    }
                }
            }
        }

        private void LoadOrderIDsUpdate()
        {
            comboBoxOrderIDUpdate.Items.Clear();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT order_id FROM orders ORDER BY order_id ASC", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxOrderIDUpdate.Items.Add(reader["order_id"].ToString());
                    }
                }
            }
        }

        private void LoadPaymentMethodCombo(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Items.Add("GCash");
            combo.Items.Add("Credit Card");
            combo.Items.Add("Bank Transfer");
            combo.Items.Add("COD");
            combo.SelectedIndex = 0;
        }

        private void LoadPaymentStatusCombo(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Items.Add("Completed");
            combo.Items.Add("Pending");
            combo.Items.Add("Refunded");
            combo.SelectedIndex = 0;
        }

        // --- Add Payment ---
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (comboBoxOrderID.SelectedItem == null || comboBoxPaymentMethod.SelectedItem == null || comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select Order ID, Payment Method, and Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int orderId = int.Parse(comboBoxOrderID.SelectedItem.ToString());
            string method = comboBoxPaymentMethod.SelectedItem.ToString();
            string status = comboBoxStatus.SelectedItem.ToString();
            DateTime paymentDate = dateTimePickerPaymentDate.Value;
            decimal amount = numericUpDownTotalAmount.Value;
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO payments (order_id, payment_date, amount, payment_method, status) VALUES (@order_id, @payment_date, @amount, @payment_method, @status)", conn);
                cmd.Parameters.AddWithValue("@order_id", orderId);
                cmd.Parameters.AddWithValue("@payment_date", paymentDate);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@payment_method", method);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAddPaymentFields();
            }
        }

        // --- Update Payment ---
        private void btnUpdatePaymentDetails_Click(object sender, EventArgs e)
        {
            if (comboBoxOrderIDUpdate.SelectedItem == null || comboBoxPaymentMethodUpdate.SelectedItem == null || comboBoxStatusUpdate.SelectedItem == null)
            {
                MessageBox.Show("Please select Order ID, Payment Method, and Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int orderId = int.Parse(comboBoxOrderIDUpdate.SelectedItem.ToString());
            string method = comboBoxPaymentMethodUpdate.SelectedItem.ToString();
            string status = comboBoxStatusUpdate.SelectedItem.ToString();
            DateTime paymentDate = dateTimePickerPaymentDateUpdate.Value;
            decimal amount = numericUpDownTotalAmountUpdate.Value;
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE payments SET payment_date=@payment_date, amount=@amount, payment_method=@payment_method, status=@status WHERE order_id=@order_id", conn);
                cmd.Parameters.AddWithValue("@order_id", orderId);
                cmd.Parameters.AddWithValue("@payment_date", paymentDate);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@payment_method", method);
                cmd.Parameters.AddWithValue("@status", status);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Payment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearUpdatePaymentFields();
                }
                else
                {
                    MessageBox.Show("No payment found for the selected Order ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // --- Delete Payment ---
        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchByPaymentIDDelete.Text))
            {
                MessageBox.Show("Please enter a Payment ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int paymentId;
            if (!int.TryParse(txtSearchByPaymentIDDelete.Text, out paymentId))
            {
                MessageBox.Show("Payment ID must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM payments WHERE payment_id=@payment_id", conn);
                cmd.Parameters.AddWithValue("@payment_id", paymentId);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Payment deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearDeletePaymentFields();
                }
                else
                {
                    MessageBox.Show("No payment found with the given Payment ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // --- Search by Payment ID (Update Tab) ---
        private void btnSearchbyPaymentID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchbyPaymentID.Text))
            {
                MessageBox.Show("Please enter a Payment ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int paymentId;
            if (!int.TryParse(txtSearchbyPaymentID.Text, out paymentId))
            {
                MessageBox.Show("Payment ID must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM payments WHERE payment_id=@payment_id", conn);
                cmd.Parameters.AddWithValue("@payment_id", paymentId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBoxOrderIDUpdate.SelectedItem = reader["order_id"].ToString();
                        dateTimePickerPaymentDateUpdate.Value = Convert.ToDateTime(reader["payment_date"]);
                        numericUpDownTotalAmountUpdate.Value = Convert.ToDecimal(reader["amount"]);
                        comboBoxPaymentMethodUpdate.SelectedItem = reader["payment_method"].ToString();
                        comboBoxStatusUpdate.SelectedItem = reader["status"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Payment not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // --- Search by Payment ID (Delete Tab) ---
        private void btnSearchByPaymentIDDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchByPaymentIDDelete.Text))
            {
                MessageBox.Show("Please enter a Payment ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int paymentId;
            if (!int.TryParse(txtSearchByPaymentIDDelete.Text, out paymentId))
            {
                MessageBox.Show("Payment ID must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM payments WHERE payment_id=@payment_id", conn);
                cmd.Parameters.AddWithValue("@payment_id", paymentId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show($"Payment found.\nOrder ID: {reader["order_id"]}\nAmount: {reader["amount"]}\nStatus: {reader["status"]}", "Payment Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Payment not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerPaymentDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownTotalAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmDashboard)
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    break;
                }
            }
            this.Close();
        }

        private void txtSearchbyPaymentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxOrderIDUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerPaymentDateUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownTotalAmountUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPaymentMethodUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxStatusUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmDashboard)
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    break;
                }
            }
            this.Close();
        }

        private void txtSearchByPaymentIDDelete_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmDashboard)
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    break;
                }
            }
            this.Close();
        }

        private void btnBack4_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmDashboard)
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    break;
                }
            }
            this.Close();
        }

        private void txtOrderSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewPaymentsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClearAddPaymentFields()
        {
            comboBoxOrderID.SelectedIndex = -1;
            comboBoxPaymentMethod.SelectedIndex = 0;
            comboBoxStatus.SelectedIndex = 0;
            dateTimePickerPaymentDate.Value = DateTime.Now;
            numericUpDownTotalAmount.Value = 0;
        }

        private void ClearUpdatePaymentFields()
        {
            comboBoxOrderIDUpdate.SelectedIndex = -1;
            comboBoxPaymentMethodUpdate.SelectedIndex = 0;
            comboBoxStatusUpdate.SelectedIndex = 0;
            dateTimePickerPaymentDateUpdate.Value = DateTime.Now;
            numericUpDownTotalAmountUpdate.Value = 0;
            txtSearchbyPaymentID.Text = "";
        }

        private void ClearDeletePaymentFields()
        {
            txtSearchByPaymentIDDelete.Text = "";
        }
    }
}

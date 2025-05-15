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
using OnlineStoreManagement;

namespace OnlineStoreManagement
{
    public partial class frmOrders: Form
    {
        // Guard flag for delete search
        private bool isSearchingDelete = false;

        public frmOrders()
        {
            InitializeComponent();
            this.Load += frmOrders_Load;
            btnAddOrder.Click += btnAddOrder_Click;
            comboBoxProduct.SelectedIndexChanged += comboBoxProduct_SelectedIndexChanged;
            numericUpDownQuantity.ValueChanged += numericUpDownQuantity_ValueChanged;
            btnSearchbyOrderIDUpdate.Click += btnSearchbyOrderIDUpdate_Click;
            btnUpdateOrderDetails.Click += btnUpdateOrderDetails_Click;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            btnExport.Click += btnExport_Click;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            btnBack.Click += btnBack_Click;
            btnBack2.Click += btnBack2_Click;
            btnBack3.Click += btnBack3_Click;
            btnBack4.Click += btnBack4_Click;
            // Add more as needed for other controls (e.g., Back buttons)
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchbyOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCustomerUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxProductUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalAmountUpdate();
        }

        private void numericUpDownQuantityUpdate_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAmountUpdate();
        }

        private void dateTimePickerOrderDateUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownTotalAmountUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxStatusUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
        private void btnBack2_Click(object sender, EventArgs e) { this.Close(); }
        private void btnBack3_Click(object sender, EventArgs e) { this.Close(); }
        private void btnBack4_Click(object sender, EventArgs e) { this.Close(); }

        private void btnSearchbyOrderIDUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchbyOrderID.Text))
            {
                MessageBox.Show("Please enter an Order ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int orderId;
            if (!int.TryParse(txtSearchbyOrderID.Text, out orderId))
            {
                MessageBox.Show("Order ID must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM orders WHERE order_id = @order_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@order_id", orderId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Set customer ComboBox by matching customer_id
                        int customerId = Convert.ToInt32(reader["customer_id"]);
                        for (int i = 0; i < comboBoxCustomerUpdate.Items.Count; i++)
                        {
                            var item = comboBoxCustomerUpdate.Items[i] as ComboboxItem;
                            if (item != null && Convert.ToInt32(item.Value) == customerId)
                            {
                                comboBoxCustomerUpdate.SelectedIndex = i;
                                break;
                            }
                        }
                        // Set product ComboBox by matching product_id
                        int productId = Convert.ToInt32(reader["product_id"]);
                        for (int i = 0; i < comboBoxProductUpdate.Items.Count; i++)
                        {
                            var item = comboBoxProductUpdate.Items[i] as ProductComboboxItem;
                            if (item != null && Convert.ToInt32(item.Value) == productId)
                            {
                                comboBoxProductUpdate.SelectedIndex = i;
                                break;
                            }
                        }
                        // Set status ComboBox by matching status string
                        string status = reader["status"].ToString();
                        for (int i = 0; i < comboBoxStatusUpdate.Items.Count; i++)
                        {
                            if (comboBoxStatusUpdate.Items[i].ToString() == status)
                            {
                                comboBoxStatusUpdate.SelectedIndex = i;
                                break;
                            }
                        }
                        dateTimePickerOrderDateUpdate.Value = Convert.ToDateTime(reader["order_date"]);
                        numericUpDownTotalAmountUpdate.Value = Convert.ToDecimal(reader["total_amount"]);
                        // Set quantity
                        numericUpDownQuantityUpdate.Value = Convert.ToDecimal(reader["quantity"]);
                    }
                    else
                    {
                        MessageBox.Show("Order not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnUpdateOrderDetails_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchbyOrderID.Text))
            {
                MessageBox.Show("Please search for an order first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxProductUpdate.SelectedItem == null)
            {
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numericUpDownQuantityUpdate.Value <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int orderId = int.Parse(txtSearchbyOrderID.Text);
            int customerId = (int)((ComboboxItem)comboBoxCustomerUpdate.SelectedItem).Value;
            int productId = (int)((ProductComboboxItem)comboBoxProductUpdate.SelectedItem).Value;
            int quantity = (int)numericUpDownQuantityUpdate.Value;
            DateTime orderDate = dateTimePickerOrderDateUpdate.Value;
            decimal totalAmount = numericUpDownTotalAmountUpdate.Value;
            string status = comboBoxStatusUpdate.SelectedItem.ToString();
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE orders SET customer_id=@customer_id, product_id=@product_id, quantity=@quantity, order_date=@order_date, total_amount=@total_amount, status=@status WHERE order_id=@order_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@order_date", orderDate);
                    cmd.Parameters.AddWithValue("@total_amount", totalAmount);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order updated successfully!");
                    ClearUpdateOrderFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating order: " + ex.Message);
                }
            }
        }

        private void ClearUpdateOrderFields()
        {
            txtSearchbyOrderID.Text = "";
            comboBoxCustomerUpdate.SelectedIndex = -1;
            comboBoxProductUpdate.SelectedIndex = -1;
            numericUpDownQuantityUpdate.Value = 0;
            numericUpDownTotalAmountUpdate.Value = 0;
            comboBoxStatusUpdate.SelectedIndex = -1;
            dateTimePickerOrderDateUpdate.Value = DateTime.Now;
        }

        private void txtSearchbyOrderIDDelete_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchbyOrderIDDelete_Click(object sender, EventArgs e)
        {
            if (isSearchingDelete) return;
            isSearchingDelete = true;
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearchbyOrderIDDelete.Text))
                {
                    MessageBox.Show("Please enter an Order ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnDeleteOrder.Enabled = false;
                    return;
                }
                int orderId;
                if (!int.TryParse(txtSearchbyOrderIDDelete.Text, out orderId))
                {
                    MessageBox.Show("Order ID must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnDeleteOrder.Enabled = false;
                    return;
                }
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM orders WHERE order_id = @order_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show($"Order found.\nCustomer ID: {reader["customer_id"]}\nOrder Date: {reader["order_date"]}\nTotal: {reader["total_amount"]}\nStatus: {reader["status"]}", "Order Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnDeleteOrder.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Order not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSearchbyOrderIDDelete.Text = "";
                            btnDeleteOrder.Enabled = false;
                        }
                    }
                }
            }
            finally
            {
                isSearchingDelete = false;
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchbyOrderIDDelete.Text))
            {
                btnDeleteOrder.Enabled = false;
                return;
            }
            int orderId = int.Parse(txtSearchbyOrderIDDelete.Text);
            var confirm = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM orders WHERE order_id=@order_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order deleted successfully!");
                        ClearDeleteOrderFields();
                        btnDeleteOrder.Enabled = false;
                        txtSearchbyOrderIDDelete.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Order not found or already deleted.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearDeleteOrderFields();
                        btnDeleteOrder.Enabled = false;
                        txtSearchbyOrderIDDelete.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting order: " + ex.Message);
                }
            }
        }

        private void ClearDeleteOrderFields()
        {
            txtSearchbyOrderIDDelete.Text = "";
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadProducts();
            LoadCustomersUpdate();
            LoadProductsUpdate();
            LoadStatusUpdate();
            comboBoxStatus.Items.AddRange(new string[] { "Pending", "Shipped", "Delivered", "Cancelled" });
            dateTimePickerOrderDate.Value = DateTime.Now;
            numericUpDownTotalAmount.Maximum = 1000000;
            numericUpDownTotalAmountUpdate.Maximum = 1000000;
        }

        private void LoadCustomers()
        {
            comboBoxCustomer.Items.Clear();
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT customer_id, first_name, last_name FROM customers";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxCustomer.Items.Add(new ComboboxItem
                        {
                            Text = reader["first_name"] + " " + reader["last_name"],
                            Value = reader["customer_id"]
                        });
                    }
                }
            }
        }

        private void LoadProducts()
        {
            comboBoxProduct.Items.Clear();
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT product_id, product_name, price FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxProduct.Items.Add(new ProductComboboxItem
                        {
                            Text = reader["product_name"].ToString(),
                            Value = reader["product_id"],
                            Price = Convert.ToDecimal(reader["price"])
                        });
                    }
                }
            }
        }

        private void LoadCustomersUpdate()
        {
            comboBoxCustomerUpdate.Items.Clear();
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT customer_id, first_name, last_name FROM customers";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxCustomerUpdate.Items.Add(new ComboboxItem
                        {
                            Text = reader["first_name"] + " " + reader["last_name"],
                            Value = reader["customer_id"]
                        });
                    }
                }
            }
        }

        private void LoadProductsUpdate()
        {
            comboBoxProductUpdate.Items.Clear();
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT product_id, product_name, price FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxProductUpdate.Items.Add(new ProductComboboxItem
                        {
                            Text = reader["product_name"].ToString(),
                            Value = reader["product_id"],
                            Price = Convert.ToDecimal(reader["price"])
                        });
                    }
                }
            }
        }

        private void LoadStatusUpdate()
        {
            comboBoxStatusUpdate.Items.Clear();
            comboBoxStatusUpdate.Items.AddRange(new string[] { "Pending", "Shipped", "Delivered", "Cancelled" });
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            if (comboBoxProduct.SelectedItem is ProductComboboxItem product && numericUpDownQuantity.Value > 0)
            {
                numericUpDownTotalAmount.Value = product.Price * numericUpDownQuantity.Value;
            }
            else
            {
                numericUpDownTotalAmount.Value = 0;
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedItem == null || comboBoxProduct.SelectedItem == null || numericUpDownQuantity.Value <= 0)
            {
                MessageBox.Show("Please select a customer, product, and enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerId = (int)((ComboboxItem)comboBoxCustomer.SelectedItem).Value;
            int productId = (int)((ProductComboboxItem)comboBoxProduct.SelectedItem).Value;
            int quantity = (int)numericUpDownQuantity.Value;
            DateTime orderDate = dateTimePickerOrderDate.Value;
            decimal totalAmount = numericUpDownTotalAmount.Value;
            string status = comboBoxStatus.SelectedItem.ToString();

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO orders (customer_id, product_id, quantity, order_date, total_amount, status) VALUES (@customer_id, @product_id, @quantity, @order_date, @total_amount, @status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@order_date", orderDate);
                    cmd.Parameters.AddWithValue("@total_amount", totalAmount);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order added successfully!");
                    ClearAddOrderFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding order: " + ex.Message);
                }
            }
        }

        private void ClearAddOrderFields()
        {
            comboBoxCustomer.SelectedIndex = -1;
            comboBoxProduct.SelectedIndex = -1;
            numericUpDownQuantity.Value = 0;
            numericUpDownTotalAmount.Value = 0;
            comboBoxStatus.SelectedIndex = -1;
            dateTimePickerOrderDate.Value = DateTime.Now;
        }

        private class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString() => Text;
        }
        private class ProductComboboxItem : ComboboxItem
        {
            public decimal Price { get; set; }
        }

        private void LoadOrdersList()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT o.order_id, CONCAT(c.first_name, ' ', c.last_name) AS customer, p.product_name, o.quantity, o.order_date, o.total_amount, o.status FROM orders o JOIN customers c ON o.customer_id = c.customer_id JOIN products p ON o.product_id = p.product_id";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewOrderList.DataSource = dt;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderList.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "Orders.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        // Write headers
                        for (int i = 0; i < dataGridViewOrderList.Columns.Count; i++)
                        {
                            sb.Append("\"" + dataGridViewOrderList.Columns[i].HeaderText + "\"");
                            if (i < dataGridViewOrderList.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();
                        // Write data
                        foreach (DataGridViewRow row in dataGridViewOrderList.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataGridViewOrderList.Columns.Count; i++)
                                {
                                    object value = row.Cells[i].Value;
                                    // Format order date column
                                    if (dataGridViewOrderList.Columns[i].HeaderText.ToLower().Contains("date") && value is DateTime dt)
                                    {
                                        sb.Append("\"" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "\"");
                                    }
                                    else
                                    {
                                        var strValue = value?.ToString().Replace("\"", "\"\"");
                                        sb.Append("\"" + strValue + "\"");
                                    }
                                    if (i < dataGridViewOrderList.Columns.Count - 1) sb.Append(",");
                                }
                                sb.AppendLine();
                            }
                        }
                        System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Exported successfully! Excel will now open the file.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            // Try to open with Excel explicitly
                            System.Diagnostics.Process.Start("excel.exe", '"' + sfd.FileName + '"');
                        }
                        catch (Exception)
                        {
                            try
                            {
                                // Fallback: open with default associated app
                                System.Diagnostics.Process.Start(sfd.FileName);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Could not open the file automatically. Please open it manually from the saved location.", "Open File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An unexpected error occurred while exporting. Please try again.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage4)
            {
                LoadOrdersList();
            }
        }

        private void UpdateTotalAmountUpdate()
        {
            if (comboBoxProductUpdate.SelectedItem is ProductComboboxItem product && numericUpDownQuantityUpdate.Value > 0)
            {
                numericUpDownTotalAmountUpdate.Value = product.Price * numericUpDownQuantityUpdate.Value;
            }
            else
            {
                numericUpDownTotalAmountUpdate.Value = 0;
            }
        }
    }
}

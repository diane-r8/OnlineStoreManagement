using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OnlineStoreManagement
{
    public partial class frmProducts : Form
    {
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString() => Text;
        }

        public frmProducts()
        {
            InitializeComponent();
            // Set min/max for price filters and add product
            numericUpDownMinPrice.Minimum = 0;
            numericUpDownMinPrice.Maximum = 1000000;
            numericUpDownMaxPrice.Minimum = 0;
            numericUpDownMaxPrice.Maximum = 1000000;
            numericUpDownPrice.Minimum = 0;
            numericUpDownPrice.Maximum = 1000000;
            // Load categories for add/update and filter
            LoadCategories();
            LoadCategoriesUpdate();
            LoadCategoriesFilter();
            // Re-attach all button event handlers
            btnSaveProduct.Click += btnSaveProduct_Click;
            btnUpdateProductDetails.Click += btnUpdateProductDetails_Click;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            btnSearchbyProductName.Click += btnSearchbyProductName_Click;
            btnSearchbyProductNameDelete.Click += btnSearchbyProductNameDelete_Click;
            btnExport.Click += btnExport_Click;
            btnBack.Click += BackToDashboard;
            btnBack2.Click += BackToDashboard;
            btnBack3.Click += BackToDashboard;
            btnBack4.Click += BackToDashboard;
            btnGoToCategories.Click += btnGoToCategories_Click;
            btnSearchFilter.Click += btnSearchFilter_Click;
            btnResetSearchFilter.Click += btnResetSearchFilter_Click;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownPrice_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownStockQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchbyProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductNameUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCategoryUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownPriceUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownStockQuantityUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxDescriptionUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductNameDelete_TextChanged(object sender, EventArgs e)
        {

        }

        // --- ADD PRODUCT ---
        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            string name = txtProductName.Text.Trim();
            object catVal = (comboBoxCategory.SelectedItem as ComboBoxItem)?.Value;
            int? categoryId = null;
            if (catVal is int)
                categoryId = (int)catVal;
            else if (catVal is long)
                categoryId = Convert.ToInt32(catVal);
            decimal price = numericUpDownPrice.Value;
            int stock = (int)numericUpDownStockQuantity.Value;
            string description = richTextBoxDescription?.Text ?? "";
            if (string.IsNullOrWhiteSpace(name) || categoryId == null)
            {
                MessageBox.Show("Please enter all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO products (product_name, category_id, price, stock_quantity, description) VALUES (@name, @category_id, @price, @stock, @description)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category_id", categoryId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Product added successfully!", "Success");
            // Clear all fields after successful add
            txtProductName.Text = "";
            comboBoxCategory.SelectedIndex = -1;
            numericUpDownPrice.Value = 0;
            numericUpDownStockQuantity.Value = 0;
            if (richTextBoxDescription != null) richTextBoxDescription.Text = "";
        }

        // --- UPDATE PRODUCT ---
        private void btnSearchbyProductName_Click(object sender, EventArgs e)
        {
            string searchName = txtSearchbyProductName.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchName))
            {
                MessageBox.Show("Enter a product name to search.");
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT p.*, c.category_name AS category FROM products p LEFT JOIN productcategories c ON p.category_id = c.category_id WHERE p.product_name=@name";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", searchName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtProductNameUpdate.Text = reader["product_name"].ToString();
                            // Set category by category_id
                            int categoryId = Convert.ToInt32(reader["category_id"]);
                            foreach (var item in comboBoxCategoryUpdate.Items)
                            {
                                if (item is ComboBoxItem cbi && Convert.ToInt32(cbi.Value) == categoryId)
                                {
                                    comboBoxCategoryUpdate.SelectedItem = item;
                                    break;
                                }
                            }
                            numericUpDownPriceUpdate.Value = Convert.ToDecimal(reader["price"]);
                            if (richTextBoxDescriptionUpdate != null)
                                richTextBoxDescriptionUpdate.Text = reader["description"].ToString();
                            numericUpDownStockQuantityUpdate.Value = Convert.ToInt32(reader["stock_quantity"]);
                            txtProductNameUpdate.Tag = reader["product_id"]; // store id for update
                        }
                        else
                        {
                            MessageBox.Show("Product not found.");
                        }
                    }
                }
            }
        }
        private void btnUpdateProductDetails_Click(object sender, EventArgs e)
        {
            if (txtProductNameUpdate.Tag == null)
            {
                MessageBox.Show("Search for a product first.");
                return;
            }
            int productId = Convert.ToInt32(txtProductNameUpdate.Tag);
            string name = txtProductNameUpdate.Text.Trim();
            object catVal = (comboBoxCategoryUpdate.SelectedItem as ComboBoxItem)?.Value;
            int? categoryId = null;
            if (catVal is int)
                categoryId = (int)catVal;
            else if (catVal is long)
                categoryId = Convert.ToInt32(catVal);
            decimal price = numericUpDownPriceUpdate.Value;
            string description = richTextBoxDescriptionUpdate.Text.Trim();
            int stock = (int)numericUpDownStockQuantityUpdate.Value;
            if (string.IsNullOrWhiteSpace(name) || categoryId == null)
            {
                MessageBox.Show("Please enter all required fields.");
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE products SET product_name=@name, category_id=@category_id, price=@price, description=@description, stock_quantity=@stock WHERE product_id=@id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category_id", categoryId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Product updated successfully!");
            // Clear all update fields
            txtProductNameUpdate.Text = "";
            comboBoxCategoryUpdate.SelectedIndex = -1;
            numericUpDownPriceUpdate.Value = 0;
            numericUpDownStockQuantityUpdate.Value = 0;
            if (richTextBoxDescriptionUpdate != null) richTextBoxDescriptionUpdate.Text = "";
            txtProductNameUpdate.Tag = null;
            txtSearchbyProductName.Text = "";
        }

        // --- DELETE PRODUCT ---
        private void btnSearchbyProductNameDelete_Click(object sender, EventArgs e)
        {
            string searchName = txtProductNameDelete.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchName))
            {
                MessageBox.Show("Enter a product name to search.");
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT p.*, c.category_name AS category FROM products p LEFT JOIN productcategories c ON p.category_id = c.category_id WHERE p.product_name=@name";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", searchName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtProductNameDelete.Tag = reader["product_id"]; // store id for delete
                            MessageBox.Show($"Product found: {reader["product_name"]}\nCategory: {reader["category"]}\nPrice: {reader["price"]}\nStock: {reader["stock_quantity"]}\nDescription: {reader["description"]}");
                        }
                        else
                        {
                            MessageBox.Show("Product not found.");
                        }
                    }
                }
            }
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (txtProductNameDelete.Tag == null)
            {
                MessageBox.Show("Search for a product first.");
                return;
            }
            int productId = Convert.ToInt32(txtProductNameDelete.Tag);
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM products WHERE product_id=@id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Product deleted successfully!");
            // Clear all delete fields
            txtProductNameDelete.Text = "";
            txtProductNameDelete.Tag = null;
        }

        // --- VIEW PRODUCTS LIST (now includes description) ---
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage4)
            {
                LoadProductsList();
            }
        }
        private void LoadProductsList()
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT p.product_id, p.product_name, c.category_name AS category, p.price, p.stock_quantity, p.description FROM products p LEFT JOIN productcategories c ON p.category_id = c.category_id";
                using (var adapter = new MySqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewProductsList.DataSource = dt;
                }
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductsList.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "Products.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        // Write headers
                        for (int i = 0; i < dataGridViewProductsList.Columns.Count; i++)
                        {
                            sb.Append('"' + dataGridViewProductsList.Columns[i].HeaderText + '"');
                            if (i < dataGridViewProductsList.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();
                        // Write data
                        foreach (DataGridViewRow row in dataGridViewProductsList.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataGridViewProductsList.Columns.Count; i++)
                                {
                                    object value = row.Cells[i].Value;
                                    sb.Append('"' + (value?.ToString().Replace("\"", "\"\"") ?? "") + '"');
                                    if (i < dataGridViewProductsList.Columns.Count - 1) sb.Append(",");
                                }
                                sb.AppendLine();
                            }
                        }
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Exported successfully! File will now open.");
                        try
                        {
                            Process.Start(sfd.FileName);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not open the file automatically. Please open it manually from the saved location.");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error occurred while exporting.");
                    }
                }
            }
        }

        // --- CATEGORY LOADING ---
        private void LoadCategories()
        {
            comboBoxCategory.Items.Clear();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT category_id, category_name FROM productcategories";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxCategory.Items.Add(new ComboBoxItem
                        {
                            Text = reader["category_name"].ToString(),
                            Value = reader["category_id"]
                        });
                    }
                }
            }
        }
        private void LoadCategoriesUpdate()
        {
            comboBoxCategoryUpdate.Items.Clear();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT category_id, category_name FROM productcategories";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxCategoryUpdate.Items.Add(new ComboBoxItem
                        {
                            Text = reader["category_name"].ToString(),
                            Value = reader["category_id"]
                        });
                    }
                }
            }
        }
        private void LoadCategoriesFilter()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("All");
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT category_name FROM productcategories";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["category_name"].ToString());
                    }
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        // --- NAVIGATION ---
        private void BackToDashboard(object sender, EventArgs e)
        {
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
        private void btnGoToCategories_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmCategories")
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    return;
                }
            }
            new frmCategories().Show();
        }

        private void btnSearchFilter_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string category = comboBox1.SelectedItem?.ToString();
            decimal minPrice = numericUpDownMinPrice.Value;
            decimal maxPrice = numericUpDownMaxPrice.Value;
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var query = new StringBuilder(@"SELECT p.product_id, p.product_name, c.category_name AS category, p.price, p.stock_quantity, p.description FROM products p LEFT JOIN productcategories c ON p.category_id = c.category_id WHERE 1=1");
                if (!string.IsNullOrWhiteSpace(name))
                    query.Append(" AND p.product_name LIKE @name");
                if (!string.IsNullOrWhiteSpace(category) && category != "All")
                    query.Append(" AND c.category_name = @category");
                if (minPrice > 0)
                    query.Append(" AND p.price >= @minPrice");
                if (maxPrice > 0 && maxPrice >= minPrice)
                    query.Append(" AND p.price <= @maxPrice");
                using (var cmd = new MySqlCommand(query.ToString(), conn))
                {
                    if (!string.IsNullOrWhiteSpace(name))
                        cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                    if (!string.IsNullOrWhiteSpace(category) && category != "All")
                        cmd.Parameters.AddWithValue("@category", category);
                    if (minPrice > 0)
                        cmd.Parameters.AddWithValue("@minPrice", minPrice);
                    if (maxPrice > 0 && maxPrice >= minPrice)
                        cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewProductsList.DataSource = dt;
                    }
                }
            }
        }
        private void btnResetSearchFilter_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            numericUpDownMinPrice.Value = 0;
            numericUpDownMaxPrice.Value = 0;
            LoadProductsList();
        }
    }
}

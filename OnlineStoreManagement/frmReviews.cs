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
    public partial class frmReviews: Form
    {
        public frmReviews()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            btnSaveReview.Click += btnSaveReview_Click;
            btnUpdateReviewDetails.Click += btnUpdateReviewDetails_Click;
            btnDeleteReview.Click += btnDeleteReview_Click;
            btnSearchByReviewIDUpdate.Click += btnSearchByReviewIDUpdate_Click;
            btnSearchFilter.Click += btnSearchFilter_Click;
            btnResetSearchFilter.Click += btnResetSearchFilter_Click;
            btnExport.Click += btnExport_Click;
            btnBack.Click += BackToDashboard;
            btnBack2.Click += BackToDashboard;
            btnBack3.Click += BackToDashboard;
            btnBack4.Click += BackToDashboard;
            comboBoxRatingsFilter.SelectedIndexChanged += comboBoxRatingsFilter_SelectedIndexChanged;
            LoadCustomers();
            LoadProducts();
            LoadCustomersUpdate();
            LoadProductsUpdate();
            LoadRatingsFilter();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownRating_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerOrderDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveReview_Click(object sender, EventArgs e)
        {
            // If all fields are empty, do nothing (assume reset/clear)
            if (comboBoxCustomer.SelectedIndex == -1 && comboBoxProduct.SelectedIndex == -1 && numericUpDownRating.Value == 1 && string.IsNullOrWhiteSpace(richTextBoxComment.Text))
                return;
            if (comboBoxCustomer.SelectedItem == null || comboBoxProduct.SelectedItem == null || numericUpDownRating.Value < 1)
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerId = ((ComboBoxItem)comboBoxCustomer.SelectedItem).Value;
            int productId = ((ComboBoxItem)comboBoxProduct.SelectedItem).Value;
            int rating = (int)numericUpDownRating.Value;
            string comment = richTextBoxComment.Text.Trim();
            DateTime reviewDate = dateTimePickerOrderDate.Value;
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO reviews (customer_id, product_id, rating, review_text, review_date) VALUES (@customer_id, @product_id, @rating, @review_text, @review_date)", conn);
                cmd.Parameters.AddWithValue("@customer_id", customerId);
                cmd.Parameters.AddWithValue("@product_id", productId);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.Parameters.AddWithValue("@review_text", comment);
                cmd.Parameters.AddWithValue("@review_date", reviewDate);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Review added successfully!", "Success");
            ClearAddFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchByProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchByProductName_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCustomerUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxProductUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownRatingUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxCommentUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerOrderDateUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateReviewDetails_Click(object sender, EventArgs e)
        {
            // If all fields are empty, do nothing (assume reset/clear)
            if (comboBoxCustomerUpdate.SelectedIndex == -1 && comboBoxProductUpdate.SelectedIndex == -1 && numericUpDownRatingUpdate.Value == 1 && string.IsNullOrWhiteSpace(richTextBoxCommentUpdate.Text) && string.IsNullOrWhiteSpace(txtSearchByReviewIDUpdate.Text))
                return;
            if (txtSearchByReviewIDUpdate.Tag == null)
            {
                MessageBox.Show("Search for a review first.");
                return;
            }
            int reviewId = (int)txtSearchByReviewIDUpdate.Tag;
            if (comboBoxCustomerUpdate.SelectedItem == null || comboBoxProductUpdate.SelectedItem == null || numericUpDownRatingUpdate.Value < 1)
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerId = ((ComboBoxItem)comboBoxCustomerUpdate.SelectedItem).Value;
            int productId = ((ComboBoxItem)comboBoxProductUpdate.SelectedItem).Value;
            int rating = (int)numericUpDownRatingUpdate.Value;
            string comment = richTextBoxCommentUpdate.Text.Trim();
            DateTime reviewDate = dateTimePickerOrderDateUpdate.Value;
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE reviews SET customer_id=@customer_id, product_id=@product_id, rating=@rating, review_text=@review_text, review_date=@review_date WHERE review_id=@id", conn);
                cmd.Parameters.AddWithValue("@customer_id", customerId);
                cmd.Parameters.AddWithValue("@product_id", productId);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.Parameters.AddWithValue("@review_text", comment);
                cmd.Parameters.AddWithValue("@review_date", reviewDate);
                cmd.Parameters.AddWithValue("@id", reviewId);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Review updated successfully!", "Success");
            ClearUpdateFields();
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            BackToDashboard(sender, e);
        }

        private void txtSearchByReviewIDDelete_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchByReviewIDDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchByReviewIDDelete.Text))
            {
                MessageBox.Show("Enter a Review ID.");
                return;
            }
            int reviewId;
            if (!int.TryParse(txtSearchByReviewIDDelete.Text, out reviewId))
            {
                MessageBox.Show("Invalid Review ID.");
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM reviews WHERE review_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", reviewId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show($"Review found:\nCustomer ID: {reader["customer_id"]}\nProduct ID: {reader["product_id"]}\nRating: {reader["rating"]}\nComment: {reader["review_text"]}\nDate: {reader["review_date"]}");
                        txtSearchByReviewIDDelete.Tag = reviewId;
                    }
                    else
                    {
                        MessageBox.Show("Review not found.");
                    }
                }
            }
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxRatingsFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReviewsList();
        }

        private void btnSearchFilter_Click(object sender, EventArgs e)
        {
            LoadReviewsList();
        }

        private void btnResetSearchFilter_Click(object sender, EventArgs e)
        {
            txtProductSearch.Text = "";
            comboBoxRatingsFilter.SelectedIndex = 0;
            LoadReviewsList();
        }

        private void dataGridViewReviewsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewReviewsList.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "Reviews.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        // Write headers
                        for (int i = 0; i < dataGridViewReviewsList.Columns.Count; i++)
                        {
                            sb.Append(dataGridViewReviewsList.Columns[i].HeaderText);
                            if (i < dataGridViewReviewsList.Columns.Count - 1)
                                sb.Append(",");
                        }
                        sb.AppendLine();
                        // Write data
                        foreach (DataGridViewRow row in dataGridViewReviewsList.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataGridViewReviewsList.Columns.Count; i++)
                                {
                                    sb.Append(row.Cells[i].Value?.ToString().Replace(",", " "));
                                    if (i < dataGridViewReviewsList.Columns.Count - 1)
                                        sb.Append(",");
                                }
                                sb.AppendLine();
                            }
                        }
                        File.WriteAllText(sfd.FileName, sb.ToString());
                        Process.Start(sfd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Failed to export file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBack4_Click(object sender, EventArgs e)
        {
            BackToDashboard(sender, e);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage4)
                LoadReviewsList();
            if (tabControl1.SelectedTab == tabPage1)
            {
                LoadCustomers();
                LoadProducts();
            }
            if (tabControl1.SelectedTab == tabPage2)
            {
                LoadCustomersUpdate();
                LoadProductsUpdate();
            }
        }

        private void btnDeleteReview_Click(object sender, EventArgs e)
        {
            // If all fields are empty, do nothing (assume reset/clear)
            if (string.IsNullOrWhiteSpace(txtSearchByReviewIDDelete.Text) && txtSearchByReviewIDDelete.Tag == null)
                return;
            if (txtSearchByReviewIDDelete.Tag == null)
            {
                MessageBox.Show("Search for a review first.");
                return;
            }
            int reviewId = (int)txtSearchByReviewIDDelete.Tag;
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM reviews WHERE review_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", reviewId);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Review deleted successfully!", "Success");
            ClearDeleteFields();
        }

        private void btnSearchByReviewIDUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchByReviewIDUpdate.Text))
            {
                MessageBox.Show("Enter a Review ID.");
                return;
            }
            int reviewId;
            if (!int.TryParse(txtSearchByReviewIDUpdate.Text, out reviewId))
            {
                MessageBox.Show("Invalid Review ID.");
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM reviews WHERE review_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", reviewId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Set combo boxes
                        for (int i = 0; i < comboBoxCustomerUpdate.Items.Count; i++)
                        {
                            if (((ComboBoxItem)comboBoxCustomerUpdate.Items[i]).Value == Convert.ToInt32(reader["customer_id"]))
                            {
                                comboBoxCustomerUpdate.SelectedIndex = i;
                                break;
                            }
                        }
                        for (int i = 0; i < comboBoxProductUpdate.Items.Count; i++)
                        {
                            if (((ComboBoxItem)comboBoxProductUpdate.Items[i]).Value == Convert.ToInt32(reader["product_id"]))
                            {
                                comboBoxProductUpdate.SelectedIndex = i;
                                break;
                            }
                        }
                        numericUpDownRatingUpdate.Value = Convert.ToInt32(reader["rating"]);
                        richTextBoxCommentUpdate.Text = reader["review_text"].ToString();
                        dateTimePickerOrderDateUpdate.Value = Convert.ToDateTime(reader["review_date"]);
                        txtSearchByReviewIDUpdate.Tag = reviewId;
                    }
                    else
                    {
                        MessageBox.Show("Review not found.");
                    }
                }
            }
        }

        private void LoadCustomers()
        {
            comboBoxCustomer.Items.Clear();
            var items = new List<ComboBoxItem>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT customer_id, first_name, last_name FROM customers", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new ComboBoxItem { Text = reader["first_name"] + " " + reader["last_name"], Value = Convert.ToInt32(reader["customer_id"]) });
                    }
                }
            }
            foreach (var item in items.OrderBy(i => i.Text))
                comboBoxCustomer.Items.Add(item);
        }

        private void LoadProducts()
        {
            comboBoxProduct.Items.Clear();
            var items = new List<ComboBoxItem>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT product_id, product_name FROM products", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new ComboBoxItem { Text = reader["product_name"].ToString(), Value = Convert.ToInt32(reader["product_id"]) });
                    }
                }
            }
            foreach (var item in items.OrderBy(i => i.Text))
                comboBoxProduct.Items.Add(item);
        }

        private void LoadCustomersUpdate()
        {
            comboBoxCustomerUpdate.Items.Clear();
            var items = new List<ComboBoxItem>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT customer_id, first_name, last_name FROM customers", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new ComboBoxItem { Text = reader["first_name"] + " " + reader["last_name"], Value = Convert.ToInt32(reader["customer_id"]) });
                    }
                }
            }
            foreach (var item in items.OrderBy(i => i.Text))
                comboBoxCustomerUpdate.Items.Add(item);
        }

        private void LoadProductsUpdate()
        {
            comboBoxProductUpdate.Items.Clear();
            var items = new List<ComboBoxItem>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT product_id, product_name FROM products", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new ComboBoxItem { Text = reader["product_name"].ToString(), Value = Convert.ToInt32(reader["product_id"]) });
                    }
                }
            }
            foreach (var item in items.OrderBy(i => i.Text))
                comboBoxProductUpdate.Items.Add(item);
        }

        private void LoadRatingsFilter()
        {
            comboBoxRatingsFilter.Items.Clear();
            comboBoxRatingsFilter.Items.Add("All");
            for (int i = 1; i <= 5; i++) comboBoxRatingsFilter.Items.Add(i.ToString());
            comboBoxRatingsFilter.SelectedIndex = 0;
        }

        private void LoadReviewsList()
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var query = new StringBuilder("SELECT r.review_id, c.first_name AS customer, p.product_name AS product, r.rating, r.review_text, r.review_date FROM reviews r LEFT JOIN customers c ON r.customer_id = c.customer_id LEFT JOIN products p ON r.product_id = p.product_id WHERE 1=1");
                if (!string.IsNullOrWhiteSpace(txtProductSearch.Text))
                    query.Append(" AND p.product_name LIKE @product");
                if (comboBoxRatingsFilter.SelectedIndex > 0)
                    query.Append(" AND r.rating = @rating");
                query.Append(" ORDER BY r.review_id ASC");
                using (var cmd = new MySqlCommand(query.ToString(), conn))
                {
                    if (!string.IsNullOrWhiteSpace(txtProductSearch.Text))
                        cmd.Parameters.AddWithValue("@product", "%" + txtProductSearch.Text + "%");
                    if (comboBoxRatingsFilter.SelectedIndex > 0)
                        cmd.Parameters.AddWithValue("@rating", comboBoxRatingsFilter.SelectedItem.ToString());
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewReviewsList.DataSource = dt;
                        if (dataGridViewReviewsList.Columns.Count > 0)
                            dataGridViewReviewsList.Sort(dataGridViewReviewsList.Columns["review_id"], ListSortDirection.Ascending);
                    }
                }
            }
        }

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

        private void ClearAddFields()
        {
            comboBoxCustomer.SelectedIndex = -1;
            comboBoxProduct.SelectedIndex = -1;
            numericUpDownRating.Value = 1;
            richTextBoxComment.Text = "";
            dateTimePickerOrderDate.Value = DateTime.Now;
        }

        private void ClearUpdateFields()
        {
            comboBoxCustomerUpdate.SelectedIndex = -1;
            comboBoxProductUpdate.SelectedIndex = -1;
            numericUpDownRatingUpdate.Value = 1;
            richTextBoxCommentUpdate.Text = "";
            dateTimePickerOrderDateUpdate.Value = DateTime.Now;
            txtSearchByReviewIDUpdate.Text = "";
            txtSearchByReviewIDUpdate.Tag = null;
        }

        private void ClearDeleteFields()
        {
            txtSearchByReviewIDDelete.Text = "";
            txtSearchByReviewIDDelete.Tag = null;
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public override string ToString() => Text;
    }
}

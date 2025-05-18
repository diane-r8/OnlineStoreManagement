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
    public partial class frmCategories : Form
    {
        private bool isOperationInProgress = false;

        public frmCategories()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            btnSaveCategory.Click += btnSaveCategory_Click;
            btnUpdateCategoryDetails.Click += btnUpdateCategoryDetails_Click;
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            btnSearchByCategoryName.Click += btnSearchByCategoryName_Click;
            btnSearchFilter.Click += btnSearchFilter_Click;
            btnResetSearchFilter.Click += btnResetSearchFilter_Click;
            btnBack.Click += btnBack_Click;
            btnBack2.Click += btnBack_Click;
            btnBack3.Click += btnBack_Click;
            btnBack4.Click += btnBack_Click;
            LoadCategoriesList();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage4)
                LoadCategoriesList();
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if (isOperationInProgress) return;
            isOperationInProgress = true;
            try
            {
                string name = txtCategoryName.Text.Trim();
                string desc = richTextBoxDescription.Text.Trim();
                if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(desc))
                    return;
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("INSERT INTO productcategories (category_name, description) VALUES (@name, @desc)", conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryName.Text = "";
                richTextBoxDescription.Text = "";
                LoadCategoriesList();
                txtCategoryName.Focus();
            }
            finally
            {
                isOperationInProgress = false;
            }
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

        private void txtSearchbyCategoryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchByCategoryName_Click(object sender, EventArgs e)
        {
            string name = txtSearchbyCategoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a category name to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM productcategories WHERE category_name=@name", conn);
                cmd.Parameters.AddWithValue("@name", name);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        numericUpDownCategoryIDUpdate.Value = Convert.ToDecimal(reader["category_id"]);
                        txtCategoryNameUpdate.Text = reader["category_name"].ToString();
                        richTextBoxDescriptionUpdate.Text = reader["description"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Category not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void numericUpDownCategoryIDUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCategoryNameUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxDescriptionUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateCategoryDetails_Click(object sender, EventArgs e)
        {
            if (isOperationInProgress) return;
            isOperationInProgress = true;
            try
            {
                int id = (int)numericUpDownCategoryIDUpdate.Value;
                string name = txtCategoryNameUpdate.Text.Trim();
                string desc = richTextBoxDescriptionUpdate.Text.Trim();
                if (id == 0 && string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(desc) && string.IsNullOrWhiteSpace(txtSearchbyCategoryName.Text))
                    return;
                if (id <= 0 || string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please search for a category and enter a new name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("UPDATE productcategories SET category_name=@name, description=@desc WHERE category_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        numericUpDownCategoryIDUpdate.Value = 0;
                        txtCategoryNameUpdate.Text = "";
                        richTextBoxDescriptionUpdate.Text = "";
                        txtSearchbyCategoryName.Text = "";
                        LoadCategoriesList();
                        txtSearchbyCategoryName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No category found with the given ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            finally
            {
                isOperationInProgress = false;
            }
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {

        }

        private void txtCategoryNameDelete_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (isOperationInProgress) return;
            isOperationInProgress = true;
            try
            {
                string name = txtCategoryNameDelete.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                    return;
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM productcategories WHERE category_name=@name", conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCategoryNameDelete.Text = "";
                        LoadCategoriesList();
                        txtCategoryNameDelete.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No category found with the given name.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            finally
            {
                isOperationInProgress = false;
            }
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewCategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearchFilter_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDownsCategoryIDFilter.Value;
            string name = txtCategoryNameFilter.Text.Trim();
            LoadCategoriesList(id > 0 ? id : (int?)null, name);
        }

        private void btnResetSearchFilter_Click(object sender, EventArgs e)
        {
            numericUpDownsCategoryIDFilter.Value = 0;
            txtCategoryNameFilter.Text = "";
            LoadCategoriesList();
        }

        private void LoadCategoriesList(int? id = null, string name = "")
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var query = new StringBuilder("SELECT category_id, category_name, description FROM productcategories WHERE 1=1");
                if (id.HasValue && id.Value > 0)
                    query.Append(" AND category_id = @id");
                if (!string.IsNullOrWhiteSpace(name))
                    query.Append(" AND category_name LIKE @name");
                using (var cmd = new MySqlCommand(query.ToString(), conn))
                {
                    if (id.HasValue && id.Value > 0)
                        cmd.Parameters.AddWithValue("@id", id.Value);
                    if (!string.IsNullOrWhiteSpace(name))
                        cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                    var dt = new DataTable();
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        dataGridViewCategoriesList.DataSource = dt;
                    }
                }
            }
        }

        private void btnSearchByCategoryNameDelete_Click(object sender, EventArgs e)
        {
            string name = txtCategoryNameDelete.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a category name to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM productcategories WHERE category_name=@name", conn);
                cmd.Parameters.AddWithValue("@name", name);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show($"Category found.\nID: {reader["category_id"]}\nDescription: {reader["description"]}", "Category Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Category not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void numericUpDownsCategoryIDFilter_ValueChanged(object sender, EventArgs e)
        {
            // Intentionally left blank to resolve Designer event handler
        }

        private void txtCategoryNameFilter_TextChanged(object sender, EventArgs e)
        {
            // Intentionally left blank to resolve Designer event handler
        }

        private void btnBack4_Click(object sender, EventArgs e)
        {
            // Intentionally left blank to resolve Designer event handler
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategoriesList.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "Categories.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        // Write headers
                        for (int i = 0; i < dataGridViewCategoriesList.Columns.Count; i++)
                        {
                            sb.Append('"' + dataGridViewCategoriesList.Columns[i].HeaderText + '"');
                            if (i < dataGridViewCategoriesList.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();
                        // Write data
                        foreach (DataGridViewRow row in dataGridViewCategoriesList.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataGridViewCategoriesList.Columns.Count; i++)
                                {
                                    object value = row.Cells[i].Value;
                                    var strValue = value?.ToString().Replace("\"", "\"\"");
                                    sb.Append('"' + strValue + '"');
                                    if (i < dataGridViewCategoriesList.Columns.Count - 1) sb.Append(",");
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
    }
}

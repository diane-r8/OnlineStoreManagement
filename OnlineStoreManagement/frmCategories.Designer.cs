namespace OnlineStoreManagement
{
    partial class frmCategories
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategories));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveCategory = new System.Windows.Forms.Button();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBack2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearchbyCategoryName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSearchByCategoryName = new System.Windows.Forms.Button();
            this.btnUpdateCategoryDetails = new System.Windows.Forms.Button();
            this.richTextBoxDescriptionUpdate = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCategoryNameUpdate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCategoryIDUpdate = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnBack3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearchByCategoryNameDelete = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCategoryNameDelete = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.numericUpDownsCategoryIDFilter = new System.Windows.Forms.NumericUpDown();
            this.txtCategoryNameFilter = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnResetSearchFilter = new System.Windows.Forms.Button();
            this.btnSearchFilter = new System.Windows.Forms.Button();
            this.btnBack4 = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dataGridViewCategoriesList = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCategoryIDUpdate)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownsCategoryIDFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoriesList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-6, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(744, 678);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.YellowGreen;
            this.tabPage1.Controls.Add(this.btnBack);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(736, 640);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Category";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Crimson;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(549, 583);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(156, 41);
            this.btnBack.TabIndex = 59;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(40, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(149, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(541, 56);
            this.label1.TabIndex = 57;
            this.label1.Text = "ADD CATEGORY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveCategory);
            this.groupBox1.Controls.Add(this.richTextBoxDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCategoryName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(40, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 406);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            // 
            // btnSaveCategory
            // 
            this.btnSaveCategory.BackColor = System.Drawing.Color.Orange;
            this.btnSaveCategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveCategory.Location = new System.Drawing.Point(153, 325);
            this.btnSaveCategory.Name = "btnSaveCategory";
            this.btnSaveCategory.Size = new System.Drawing.Size(349, 56);
            this.btnSaveCategory.TabIndex = 28;
            this.btnSaveCategory.Text = "Save Category";
            this.btnSaveCategory.UseVisualStyleBackColor = false;
            this.btnSaveCategory.Click += new System.EventHandler(this.btnSaveCategory_Click);
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.richTextBoxDescription.Location = new System.Drawing.Point(238, 129);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxDescription.Size = new System.Drawing.Size(374, 131);
            this.richTextBoxDescription.TabIndex = 44;
            this.richTextBoxDescription.Text = "";
            this.richTextBoxDescription.TextChanged += new System.EventHandler(this.richTextBoxDescription_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(31, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 29);
            this.label3.TabIndex = 43;
            this.label3.Text = "Description:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtCategoryName.Location = new System.Drawing.Point(238, 60);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(374, 35);
            this.txtCategoryName.TabIndex = 48;
            this.txtCategoryName.TextChanged += new System.EventHandler(this.txtCategoryName_TextChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(31, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(242, 29);
            this.label8.TabIndex = 47;
            this.label8.Text = "Category Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.YellowGreen;
            this.tabPage2.Controls.Add(this.btnBack2);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(736, 640);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit Category";
            // 
            // btnBack2
            // 
            this.btnBack2.BackColor = System.Drawing.Color.Crimson;
            this.btnBack2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack2.Location = new System.Drawing.Point(552, 585);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(156, 41);
            this.btnBack2.TabIndex = 55;
            this.btnBack2.Text = "Back";
            this.btnBack2.UseVisualStyleBackColor = false;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(43, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 101);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(152, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(541, 56);
            this.label2.TabIndex = 53;
            this.label2.Text = "EDIT CATEGORY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSearchbyCategoryName);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnSearchByCategoryName);
            this.groupBox2.Controls.Add(this.btnUpdateCategoryDetails);
            this.groupBox2.Controls.Add(this.richTextBoxDescriptionUpdate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCategoryNameUpdate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numericUpDownCategoryIDUpdate);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(43, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 459);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            // 
            // txtSearchbyCategoryName
            // 
            this.txtSearchbyCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchbyCategoryName.Location = new System.Drawing.Point(234, 47);
            this.txtSearchbyCategoryName.Name = "txtSearchbyCategoryName";
            this.txtSearchbyCategoryName.Size = new System.Drawing.Size(253, 35);
            this.txtSearchbyCategoryName.TabIndex = 51;
            this.txtSearchbyCategoryName.TextChanged += new System.EventHandler(this.txtSearchbyCategoryName_TextChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(27, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(240, 75);
            this.label13.TabIndex = 50;
            this.label13.Text = "Search by Category Name:";
            // 
            // btnSearchByCategoryName
            // 
            this.btnSearchByCategoryName.BackColor = System.Drawing.Color.Orange;
            this.btnSearchByCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchByCategoryName.Location = new System.Drawing.Point(493, 44);
            this.btnSearchByCategoryName.Name = "btnSearchByCategoryName";
            this.btnSearchByCategoryName.Size = new System.Drawing.Size(133, 41);
            this.btnSearchByCategoryName.TabIndex = 49;
            this.btnSearchByCategoryName.Text = "Search";
            this.btnSearchByCategoryName.UseVisualStyleBackColor = false;
            this.btnSearchByCategoryName.Click += new System.EventHandler(this.btnSearchByCategoryName_Click);
            // 
            // btnUpdateCategoryDetails
            // 
            this.btnUpdateCategoryDetails.BackColor = System.Drawing.Color.Orange;
            this.btnUpdateCategoryDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdateCategoryDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCategoryDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateCategoryDetails.Location = new System.Drawing.Point(115, 381);
            this.btnUpdateCategoryDetails.Name = "btnUpdateCategoryDetails";
            this.btnUpdateCategoryDetails.Size = new System.Drawing.Size(428, 56);
            this.btnUpdateCategoryDetails.TabIndex = 28;
            this.btnUpdateCategoryDetails.Text = "Update Category Details";
            this.btnUpdateCategoryDetails.UseVisualStyleBackColor = false;
            this.btnUpdateCategoryDetails.Click += new System.EventHandler(this.btnUpdateCategoryDetails_Click);
            // 
            // richTextBoxDescriptionUpdate
            // 
            this.richTextBoxDescriptionUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.richTextBoxDescriptionUpdate.Location = new System.Drawing.Point(234, 220);
            this.richTextBoxDescriptionUpdate.Name = "richTextBoxDescriptionUpdate";
            this.richTextBoxDescriptionUpdate.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxDescriptionUpdate.Size = new System.Drawing.Size(374, 131);
            this.richTextBoxDescriptionUpdate.TabIndex = 44;
            this.richTextBoxDescriptionUpdate.Text = "";
            this.richTextBoxDescriptionUpdate.TextChanged += new System.EventHandler(this.richTextBoxDescriptionUpdate_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(27, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 29);
            this.label4.TabIndex = 43;
            this.label4.Text = "Description:";
            // 
            // txtCategoryNameUpdate
            // 
            this.txtCategoryNameUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtCategoryNameUpdate.Location = new System.Drawing.Point(234, 163);
            this.txtCategoryNameUpdate.Name = "txtCategoryNameUpdate";
            this.txtCategoryNameUpdate.Size = new System.Drawing.Size(374, 35);
            this.txtCategoryNameUpdate.TabIndex = 48;
            this.txtCategoryNameUpdate.TextChanged += new System.EventHandler(this.txtCategoryNameUpdate_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(27, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 29);
            this.label6.TabIndex = 45;
            this.label6.Text = "Category ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(27, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 29);
            this.label7.TabIndex = 47;
            this.label7.Text = "Category Name:";
            // 
            // numericUpDownCategoryIDUpdate
            // 
            this.numericUpDownCategoryIDUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.numericUpDownCategoryIDUpdate.Location = new System.Drawing.Point(234, 104);
            this.numericUpDownCategoryIDUpdate.Name = "numericUpDownCategoryIDUpdate";
            this.numericUpDownCategoryIDUpdate.Size = new System.Drawing.Size(374, 35);
            this.numericUpDownCategoryIDUpdate.TabIndex = 46;
            this.numericUpDownCategoryIDUpdate.ValueChanged += new System.EventHandler(this.numericUpDownCategoryIDUpdate_ValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.YellowGreen;
            this.tabPage3.Controls.Add(this.btnBack3);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.pictureBox3);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(736, 640);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Delete Category";
            // 
            // btnBack3
            // 
            this.btnBack3.BackColor = System.Drawing.Color.Crimson;
            this.btnBack3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack3.Location = new System.Drawing.Point(530, 558);
            this.btnBack3.Name = "btnBack3";
            this.btnBack3.Size = new System.Drawing.Size(156, 41);
            this.btnBack3.TabIndex = 62;
            this.btnBack3.Text = "Back";
            this.btnBack3.UseVisualStyleBackColor = false;
            this.btnBack3.Click += new System.EventHandler(this.btnBack3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearchByCategoryNameDelete);
            this.groupBox3.Controls.Add(this.btnDeleteCategory);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtCategoryNameDelete);
            this.groupBox3.Location = new System.Drawing.Point(33, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(666, 334);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            // 
            // btnSearchByCategoryNameDelete
            // 
            this.btnSearchByCategoryNameDelete.BackColor = System.Drawing.Color.Orange;
            this.btnSearchByCategoryNameDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchByCategoryNameDelete.Location = new System.Drawing.Point(466, 112);
            this.btnSearchByCategoryNameDelete.Name = "btnSearchByCategoryNameDelete";
            this.btnSearchByCategoryNameDelete.Size = new System.Drawing.Size(157, 41);
            this.btnSearchByCategoryNameDelete.TabIndex = 21;
            this.btnSearchByCategoryNameDelete.Text = "Search";
            this.btnSearchByCategoryNameDelete.UseVisualStyleBackColor = false;
            this.btnSearchByCategoryNameDelete.Click += new System.EventHandler(this.btnSearchByCategoryNameDelete_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.BackColor = System.Drawing.Color.Crimson;
            this.btnDeleteCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteCategory.Location = new System.Drawing.Point(162, 229);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(349, 67);
            this.btnDeleteCategory.TabIndex = 20;
            this.btnDeleteCategory.Text = "Delete Category";
            this.btnDeleteCategory.UseVisualStyleBackColor = false;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(41, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(382, 40);
            this.label15.TabIndex = 19;
            this.label15.Text = "Search by Category Name:";
            // 
            // txtCategoryNameDelete
            // 
            this.txtCategoryNameDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtCategoryNameDelete.Location = new System.Drawing.Point(45, 115);
            this.txtCategoryNameDelete.Name = "txtCategoryNameDelete";
            this.txtCategoryNameDelete.Size = new System.Drawing.Size(406, 35);
            this.txtCategoryNameDelete.TabIndex = 17;
            this.txtCategoryNameDelete.TextChanged += new System.EventHandler(this.txtCategoryNameDelete_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(49, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(104, 101);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 60;
            this.pictureBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DimGray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(158, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(541, 56);
            this.label9.TabIndex = 59;
            this.label9.Text = "DELETE CATEGORY";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.YellowGreen;
            this.tabPage4.Controls.Add(this.numericUpDownsCategoryIDFilter);
            this.tabPage4.Controls.Add(this.txtCategoryNameFilter);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.btnResetSearchFilter);
            this.tabPage4.Controls.Add(this.btnSearchFilter);
            this.tabPage4.Controls.Add(this.btnBack4);
            this.tabPage4.Controls.Add(this.btnExport);
            this.tabPage4.Controls.Add(this.dataGridViewCategoriesList);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(736, 640);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "View Categories List";
            // 
            // numericUpDownsCategoryIDFilter
            // 
            this.numericUpDownsCategoryIDFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.numericUpDownsCategoryIDFilter.Location = new System.Drawing.Point(23, 77);
            this.numericUpDownsCategoryIDFilter.Name = "numericUpDownsCategoryIDFilter";
            this.numericUpDownsCategoryIDFilter.Size = new System.Drawing.Size(211, 35);
            this.numericUpDownsCategoryIDFilter.TabIndex = 58;
            this.numericUpDownsCategoryIDFilter.ValueChanged += new System.EventHandler(this.numericUpDownsCategoryIDFilter_ValueChanged);
            // 
            // txtCategoryNameFilter
            // 
            this.txtCategoryNameFilter.Location = new System.Drawing.Point(288, 78);
            this.txtCategoryNameFilter.Name = "txtCategoryNameFilter";
            this.txtCategoryNameFilter.Size = new System.Drawing.Size(249, 30);
            this.txtCategoryNameFilter.TabIndex = 57;
            this.txtCategoryNameFilter.TextChanged += new System.EventHandler(this.txtCategoryNameFilter_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(283, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(169, 25);
            this.label17.TabIndex = 55;
            this.label17.Text = "Category Name:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(238, 25);
            this.label16.TabIndex = 54;
            this.label16.Text = "Search by Category ID:";
            // 
            // btnResetSearchFilter
            // 
            this.btnResetSearchFilter.BackColor = System.Drawing.Color.Crimson;
            this.btnResetSearchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetSearchFilter.Location = new System.Drawing.Point(558, 77);
            this.btnResetSearchFilter.Name = "btnResetSearchFilter";
            this.btnResetSearchFilter.Size = new System.Drawing.Size(157, 41);
            this.btnResetSearchFilter.TabIndex = 53;
            this.btnResetSearchFilter.Text = "Reset";
            this.btnResetSearchFilter.UseVisualStyleBackColor = false;
            this.btnResetSearchFilter.Click += new System.EventHandler(this.btnResetSearchFilter_Click);
            // 
            // btnSearchFilter
            // 
            this.btnSearchFilter.BackColor = System.Drawing.Color.Orange;
            this.btnSearchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchFilter.Location = new System.Drawing.Point(558, 26);
            this.btnSearchFilter.Name = "btnSearchFilter";
            this.btnSearchFilter.Size = new System.Drawing.Size(157, 41);
            this.btnSearchFilter.TabIndex = 52;
            this.btnSearchFilter.Text = "Search";
            this.btnSearchFilter.UseVisualStyleBackColor = false;
            this.btnSearchFilter.Click += new System.EventHandler(this.btnSearchFilter_Click);
            // 
            // btnBack4
            // 
            this.btnBack4.BackColor = System.Drawing.Color.Crimson;
            this.btnBack4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack4.Location = new System.Drawing.Point(548, 576);
            this.btnBack4.Name = "btnBack4";
            this.btnBack4.Size = new System.Drawing.Size(156, 41);
            this.btnBack4.TabIndex = 42;
            this.btnBack4.Text = "Back";
            this.btnBack4.UseVisualStyleBackColor = false;
            this.btnBack4.Click += new System.EventHandler(this.btnBack4_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Orange;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new System.Drawing.Point(82, 485);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(580, 69);
            this.btnExport.TabIndex = 41;
            this.btnExport.Text = "Export to MS Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dataGridViewCategoriesList
            // 
            this.dataGridViewCategoriesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategoriesList.Location = new System.Drawing.Point(23, 136);
            this.dataGridViewCategoriesList.Name = "dataGridViewCategoriesList";
            this.dataGridViewCategoriesList.RowHeadersWidth = 62;
            this.dataGridViewCategoriesList.RowTemplate.Height = 28;
            this.dataGridViewCategoriesList.Size = new System.Drawing.Size(692, 333);
            this.dataGridViewCategoriesList.TabIndex = 40;
            this.dataGridViewCategoriesList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCategoriesList_CellContentClick);
            // 
            // frmCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(734, 673);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCategories";
            this.Text = "frmCategories";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCategoryIDUpdate)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownsCategoryIDFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoriesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnBack2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdateCategoryDetails;
        private System.Windows.Forms.RichTextBox richTextBoxDescriptionUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCategoryNameUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownCategoryIDUpdate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveCategory;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearchbyCategoryName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSearchByCategoryName;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBack3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearchByCategoryNameDelete;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCategoryNameDelete;
        private System.Windows.Forms.Button btnBack4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dataGridViewCategoriesList;
        private System.Windows.Forms.Button btnResetSearchFilter;
        private System.Windows.Forms.Button btnSearchFilter;
        private System.Windows.Forms.TextBox txtCategoryNameFilter;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownsCategoryIDFilter;
    }
}
namespace OnlineStoreManagement
{
    partial class frmReviews
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.richTextBoxReview = new System.Windows.Forms.RichTextBox();
            this.dataGridViewReviews = new System.Windows.Forms.DataGridView();
            this.btnAddReview = new System.Windows.Forms.Button();
            this.btnEditReview = new System.Windows.Forms.Button();
            this.btnDeleteReview = new System.Windows.Forms.Button();
            this.btnViewReviews = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblReview = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReviews)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Controls.Add(this.lblReview);
            this.panel1.Controls.Add(this.lblRating);
            this.panel1.Controls.Add(this.lblProduct);
            this.panel1.Controls.Add(this.lblCustomer);
            this.panel1.Controls.Add(this.btnViewReviews);
            this.panel1.Controls.Add(this.btnDeleteReview);
            this.panel1.Controls.Add(this.btnEditReview);
            this.panel1.Controls.Add(this.btnAddReview);
            this.panel1.Controls.Add(this.dataGridViewReviews);
            this.panel1.Controls.Add(this.richTextBoxReview);
            this.panel1.Controls.Add(this.numericUpDownRating);
            this.panel1.Controls.Add(this.comboBoxProduct);
            this.panel1.Controls.Add(this.comboBoxCustomer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 730);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(23, 65);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(329, 28);
            this.comboBoxCustomer.TabIndex = 0;
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(384, 65);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(329, 28);
            this.comboBoxProduct.TabIndex = 1;
            // 
            // numericUpDownRating
            // 
            this.numericUpDownRating.Location = new System.Drawing.Point(23, 164);
            this.numericUpDownRating.Name = "numericUpDownRating";
            this.numericUpDownRating.Size = new System.Drawing.Size(107, 26);
            this.numericUpDownRating.TabIndex = 2;
            // 
            // richTextBoxReview
            // 
            this.richTextBoxReview.Location = new System.Drawing.Point(197, 164);
            this.richTextBoxReview.Name = "richTextBoxReview";
            this.richTextBoxReview.Size = new System.Drawing.Size(516, 136);
            this.richTextBoxReview.TabIndex = 3;
            this.richTextBoxReview.Text = "";
            // 
            // dataGridViewReviews
            // 
            this.dataGridViewReviews.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReviews.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewReviews.Location = new System.Drawing.Point(12, 406);
            this.dataGridViewReviews.Name = "dataGridViewReviews";
            this.dataGridViewReviews.RowHeadersWidth = 62;
            this.dataGridViewReviews.RowTemplate.Height = 28;
            this.dataGridViewReviews.Size = new System.Drawing.Size(978, 312);
            this.dataGridViewReviews.TabIndex = 4;
            // 
            // btnAddReview
            // 
            this.btnAddReview.BackColor = System.Drawing.Color.Orange;
            this.btnAddReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddReview.Location = new System.Drawing.Point(810, 52);
            this.btnAddReview.Name = "btnAddReview";
            this.btnAddReview.Size = new System.Drawing.Size(162, 52);
            this.btnAddReview.TabIndex = 5;
            this.btnAddReview.Text = "Add Review";
            this.btnAddReview.UseVisualStyleBackColor = false;
            // 
            // btnEditReview
            // 
            this.btnEditReview.BackColor = System.Drawing.Color.Orange;
            this.btnEditReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditReview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditReview.Location = new System.Drawing.Point(810, 128);
            this.btnEditReview.Name = "btnEditReview";
            this.btnEditReview.Size = new System.Drawing.Size(162, 52);
            this.btnEditReview.TabIndex = 6;
            this.btnEditReview.Text = "Edit Review";
            this.btnEditReview.UseVisualStyleBackColor = false;
            // 
            // btnDeleteReview
            // 
            this.btnDeleteReview.BackColor = System.Drawing.Color.Crimson;
            this.btnDeleteReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteReview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteReview.Location = new System.Drawing.Point(810, 204);
            this.btnDeleteReview.Name = "btnDeleteReview";
            this.btnDeleteReview.Size = new System.Drawing.Size(162, 52);
            this.btnDeleteReview.TabIndex = 7;
            this.btnDeleteReview.Text = "Delete Review";
            this.btnDeleteReview.UseVisualStyleBackColor = false;
            // 
            // btnViewReviews
            // 
            this.btnViewReviews.BackColor = System.Drawing.Color.Orange;
            this.btnViewReviews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReviews.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnViewReviews.Location = new System.Drawing.Point(12, 337);
            this.btnViewReviews.Name = "btnViewReviews";
            this.btnViewReviews.Size = new System.Drawing.Size(162, 52);
            this.btnViewReviews.TabIndex = 8;
            this.btnViewReviews.Text = "View Reviews";
            this.btnViewReviews.UseVisualStyleBackColor = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.Color.DimGray;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCustomer.Location = new System.Drawing.Point(23, 30);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(86, 20);
            this.lblCustomer.TabIndex = 9;
            this.lblCustomer.Text = "Customer";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.BackColor = System.Drawing.Color.DimGray;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProduct.Location = new System.Drawing.Point(384, 30);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(71, 20);
            this.lblProduct.TabIndex = 10;
            this.lblProduct.Text = "Product";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.BackColor = System.Drawing.Color.DimGray;
            this.lblRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRating.Location = new System.Drawing.Point(23, 128);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(62, 20);
            this.lblRating.TabIndex = 11;
            this.lblRating.Text = "Rating";
            // 
            // lblReview
            // 
            this.lblReview.AutoSize = true;
            this.lblReview.BackColor = System.Drawing.Color.DimGray;
            this.lblReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblReview.Location = new System.Drawing.Point(197, 128);
            this.lblReview.Name = "lblReview";
            this.lblReview.Size = new System.Drawing.Size(66, 20);
            this.lblReview.TabIndex = 12;
            this.lblReview.Text = "Review";
            // 
            // frmReviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 730);
            this.Controls.Add(this.panel1);
            this.Name = "frmReviews";
            this.Text = "Review Management";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReviews)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnViewReviews;
        private System.Windows.Forms.Button btnDeleteReview;
        private System.Windows.Forms.Button btnEditReview;
        private System.Windows.Forms.Button btnAddReview;
        private System.Windows.Forms.DataGridView dataGridViewReviews;
        private System.Windows.Forms.RichTextBox richTextBoxReview;
        private System.Windows.Forms.NumericUpDown numericUpDownRating;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label lblReview;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblCustomer;
    }
}
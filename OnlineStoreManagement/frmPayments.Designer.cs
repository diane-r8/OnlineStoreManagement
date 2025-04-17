namespace OnlineStoreManagement
{
    partial class frmPayments
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
            this.comboBoxOrder = new System.Windows.Forms.ComboBox();
            this.dateTimePickerPayment = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownPayment = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            this.lblOrderPayment = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnEditPayment = new System.Windows.Forms.Button();
            this.btnDeletePayment = new System.Windows.Forms.Button();
            this.btnViewPayments = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Controls.Add(this.btnViewPayments);
            this.panel1.Controls.Add(this.btnDeletePayment);
            this.panel1.Controls.Add(this.btnEditPayment);
            this.panel1.Controls.Add(this.btnAddPayment);
            this.panel1.Controls.Add(this.lblPaymentAmount);
            this.panel1.Controls.Add(this.lblPaymentDate);
            this.panel1.Controls.Add(this.lblOrderPayment);
            this.panel1.Controls.Add(this.dataGridViewPayments);
            this.panel1.Controls.Add(this.numericUpDownPayment);
            this.panel1.Controls.Add(this.dateTimePickerPayment);
            this.panel1.Controls.Add(this.comboBoxOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 730);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxOrder
            // 
            this.comboBoxOrder.FormattingEnabled = true;
            this.comboBoxOrder.Location = new System.Drawing.Point(26, 65);
            this.comboBoxOrder.Name = "comboBoxOrder";
            this.comboBoxOrder.Size = new System.Drawing.Size(300, 28);
            this.comboBoxOrder.TabIndex = 0;
            // 
            // dateTimePickerPayment
            // 
            this.dateTimePickerPayment.Location = new System.Drawing.Point(375, 67);
            this.dateTimePickerPayment.Name = "dateTimePickerPayment";
            this.dateTimePickerPayment.Size = new System.Drawing.Size(310, 26);
            this.dateTimePickerPayment.TabIndex = 1;
            // 
            // numericUpDownPayment
            // 
            this.numericUpDownPayment.Location = new System.Drawing.Point(26, 171);
            this.numericUpDownPayment.Name = "numericUpDownPayment";
            this.numericUpDownPayment.Size = new System.Drawing.Size(198, 26);
            this.numericUpDownPayment.TabIndex = 2;
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.Location = new System.Drawing.Point(12, 324);
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.RowHeadersWidth = 62;
            this.dataGridViewPayments.RowTemplate.Height = 28;
            this.dataGridViewPayments.Size = new System.Drawing.Size(978, 394);
            this.dataGridViewPayments.TabIndex = 3;
            // 
            // lblOrderPayment
            // 
            this.lblOrderPayment.AutoSize = true;
            this.lblOrderPayment.BackColor = System.Drawing.Color.DimGray;
            this.lblOrderPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderPayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOrderPayment.Location = new System.Drawing.Point(22, 29);
            this.lblOrderPayment.Name = "lblOrderPayment";
            this.lblOrderPayment.Size = new System.Drawing.Size(54, 20);
            this.lblOrderPayment.TabIndex = 4;
            this.lblOrderPayment.Text = "Order";
            this.lblOrderPayment.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.BackColor = System.Drawing.Color.DimGray;
            this.lblPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPaymentDate.Location = new System.Drawing.Point(371, 29);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(122, 20);
            this.lblPaymentDate.TabIndex = 5;
            this.lblPaymentDate.Text = "Payment Date";
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.BackColor = System.Drawing.Color.DimGray;
            this.lblPaymentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentAmount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPaymentAmount.Location = new System.Drawing.Point(22, 133);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(145, 20);
            this.lblPaymentAmount.TabIndex = 6;
            this.lblPaymentAmount.Text = "Payment Amount";
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.BackColor = System.Drawing.Color.Orange;
            this.btnAddPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddPayment.Location = new System.Drawing.Point(807, 52);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(162, 52);
            this.btnAddPayment.TabIndex = 7;
            this.btnAddPayment.Text = "Add Payment";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            // 
            // btnEditPayment
            // 
            this.btnEditPayment.BackColor = System.Drawing.Color.Orange;
            this.btnEditPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditPayment.Location = new System.Drawing.Point(807, 125);
            this.btnEditPayment.Name = "btnEditPayment";
            this.btnEditPayment.Size = new System.Drawing.Size(162, 52);
            this.btnEditPayment.TabIndex = 8;
            this.btnEditPayment.Text = "Edit Payment";
            this.btnEditPayment.UseVisualStyleBackColor = false;
            // 
            // btnDeletePayment
            // 
            this.btnDeletePayment.BackColor = System.Drawing.Color.Crimson;
            this.btnDeletePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeletePayment.Location = new System.Drawing.Point(807, 196);
            this.btnDeletePayment.Name = "btnDeletePayment";
            this.btnDeletePayment.Size = new System.Drawing.Size(162, 52);
            this.btnDeletePayment.TabIndex = 9;
            this.btnDeletePayment.Text = "Delete Payment";
            this.btnDeletePayment.UseVisualStyleBackColor = false;
            // 
            // btnViewPayments
            // 
            this.btnViewPayments.BackColor = System.Drawing.Color.Orange;
            this.btnViewPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPayments.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnViewPayments.Location = new System.Drawing.Point(12, 253);
            this.btnViewPayments.Name = "btnViewPayments";
            this.btnViewPayments.Size = new System.Drawing.Size(162, 52);
            this.btnViewPayments.TabIndex = 10;
            this.btnViewPayments.Text = "View Payment";
            this.btnViewPayments.UseVisualStyleBackColor = false;
            // 
            // frmPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 730);
            this.Controls.Add(this.panel1);
            this.Name = "frmPayments";
            this.Text = "Payment Management";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblOrderPayment;
        private System.Windows.Forms.DataGridView dataGridViewPayments;
        private System.Windows.Forms.NumericUpDown numericUpDownPayment;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayment;
        private System.Windows.Forms.ComboBox comboBoxOrder;
        private System.Windows.Forms.Button btnViewPayments;
        private System.Windows.Forms.Button btnDeletePayment;
        private System.Windows.Forms.Button btnEditPayment;
        private System.Windows.Forms.Button btnAddPayment;
    }
}
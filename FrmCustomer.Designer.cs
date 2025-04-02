namespace _291_proj
{
    partial class FrmCustomer
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvCustomers = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtAddress = new TextBox();
            txtCity = new TextBox();
            txtProvince = new TextBox();
            label6 = new Label();
            btnAdd = new Button();
            btnModify = new Button();
            btnDelete = new Button();
            label7 = new Label();
            txtSSN = new TextBox();
            label8 = new Label();
            txtPostalCode = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            txtEmail = new TextBox();
            txtAccountNum = new TextBox();
            txtCreditCardNumber = new TextBox();
            txtExpiryDate = new TextBox();
            txtCVV = new TextBox();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(403, 32);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(304, 23);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(403, 61);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += button1_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(47, 102);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(924, 254);
            dgvCustomers.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 393);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 3;
            label1.Text = "First Name: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 422);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 4;
            label2.Text = "Last Name:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 480);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 5;
            label3.Text = "City:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 451);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 6;
            label4.Text = "Address:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(102, 510);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 7;
            label5.Text = "Province:";
            label5.Click += label5_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(208, 390);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 8;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(208, 419);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(208, 448);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 23);
            txtAddress.TabIndex = 10;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(208, 477);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(100, 23);
            txtCity.TabIndex = 11;
            // 
            // txtProvince
            // 
            txtProvince.Location = new Point(208, 506);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new Size(100, 23);
            txtProvince.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(103, 165, 169);
            label6.Location = new Point(47, 23);
            label6.Name = "label6";
            label6.Size = new Size(282, 32);
            label6.TabIndex = 13;
            label6.Text = "Customer Management";
            label6.Click += label6_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(128, 255, 128);
            btnAdd.Location = new Point(850, 400);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnModify
            // 
            btnModify.BackColor = SystemColors.ActiveCaption;
            btnModify.Location = new Point(850, 449);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 15;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = false;
            btnModify.Click += btnModify_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 128, 128);
            btnDelete.Location = new Point(850, 498);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(102, 370);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 17;
            label7.Text = "SSN: ";
            // 
            // txtSSN
            // 
            txtSSN.Location = new Point(208, 362);
            txtSSN.Name = "txtSSN";
            txtSSN.Size = new Size(100, 23);
            txtSSN.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(102, 538);
            label8.Name = "label8";
            label8.Size = new Size(73, 15);
            label8.TabIndex = 19;
            label8.Text = "Postal Code:";
            // 
            // txtPostalCode
            // 
            txtPostalCode.Location = new Point(208, 535);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(100, 23);
            txtPostalCode.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(486, 395);
            label9.Name = "label9";
            label9.Size = new Size(105, 15);
            label9.TabIndex = 22;
            label9.Text = "Account Number: ";
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(486, 370);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 23;
            label10.Text = "Email: ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(486, 424);
            label11.Name = "label11";
            label11.Size = new Size(120, 15);
            label11.TabIndex = 24;
            label11.Text = "Credit Card Number: ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(486, 453);
            label12.Name = "label12";
            label12.Size = new Size(72, 15);
            label12.TabIndex = 25;
            label12.Text = "Expiry Date: ";
            label12.Click += label12_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(486, 482);
            label13.Name = "label13";
            label13.Size = new Size(35, 15);
            label13.TabIndex = 26;
            label13.Text = "CVV: ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(626, 362);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 27;
            // 
            // txtAccountNum
            // 
            txtAccountNum.Location = new Point(626, 392);
            txtAccountNum.Name = "txtAccountNum";
            txtAccountNum.Size = new Size(100, 23);
            txtAccountNum.TabIndex = 28;
            // 
            // txtCreditCardNumber
            // 
            txtCreditCardNumber.Location = new Point(626, 419);
            txtCreditCardNumber.Name = "txtCreditCardNumber";
            txtCreditCardNumber.Size = new Size(100, 23);
            txtCreditCardNumber.TabIndex = 29;
            // 
            // txtExpiryDate
            // 
            txtExpiryDate.Location = new Point(626, 448);
            txtExpiryDate.Name = "txtExpiryDate";
            txtExpiryDate.Size = new Size(100, 23);
            txtExpiryDate.TabIndex = 30;
            // 
            // txtCVV
            // 
            txtCVV.Location = new Point(626, 477);
            txtCVV.Name = "txtCVV";
            txtCVV.Size = new Size(100, 23);
            txtCVV.TabIndex = 31;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(403, 9);
            label14.Name = "label14";
            label14.Size = new Size(129, 15);
            label14.TabIndex = 32;
            label14.Text = "Search For Customer: ";
            // 
            // FrmCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(93, 106, 112);
            ClientSize = new Size(1021, 570);
            Controls.Add(label14);
            Controls.Add(txtCVV);
            Controls.Add(txtExpiryDate);
            Controls.Add(txtCreditCardNumber);
            Controls.Add(txtAccountNum);
            Controls.Add(txtEmail);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtPostalCode);
            Controls.Add(label8);
            Controls.Add(txtSSN);
            Controls.Add(label7);
            Controls.Add(btnDelete);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(label6);
            Controls.Add(txtProvince);
            Controls.Add(txtCity);
            Controls.Add(txtAddress);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvCustomers);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Name = "FrmCustomer";
            Text = "FrmCustomer";
            Load += FrmCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvCustomers;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtAddress;
        private TextBox txtCity;
        private TextBox txtProvince;
        private Label label6;
        private Button btnAdd;
        private Button btnModify;
        private Button btnDelete;
        private Label label7;
        private TextBox txtSSN;
        private Label label8;
        private TextBox txtPostalCode;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txtEmail;
        private TextBox txtAccountNum;
        private TextBox txtCreditCardNumber;
        private TextBox txtExpiryDate;
        private TextBox txtCVV;
        private Label label14;
    }
}
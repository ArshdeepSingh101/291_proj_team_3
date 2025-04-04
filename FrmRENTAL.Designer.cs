namespace CS291_Proj
{
    partial class FrmRENTAL
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
            System.Windows.Forms.Label lblAvailability;
            this.lblMovieRental = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bttnMovies = new System.Windows.Forms.Button();
            this.bttnRENT = new System.Windows.Forms.Button();
            this.bttnSearch = new System.Windows.Forms.Button();
            this.bttnLOGIN = new System.Windows.Forms.Button();
            this.bttnSIGNOUT = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvCustomerQ = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ddMovies = new System.Windows.Forms.ComboBox();
            this.bttnCustomers = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numCopies = new System.Windows.Forms.Label();
            this.bttnQUEUE = new System.Windows.Forms.Button();
            lblAvailability = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerQ)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.Font = new System.Drawing.Font("MS UI Gothic", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAvailability.Location = new System.Drawing.Point(582, 566);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new System.Drawing.Size(412, 53);
            lblAvailability.TabIndex = 37;
            lblAvailability.Text = "Copies Available:";
            // 
            // lblMovieRental
            // 
            this.lblMovieRental.AutoSize = true;
            this.lblMovieRental.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.lblMovieRental.Font = new System.Drawing.Font("MS UI Gothic", 25.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieRental.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.lblMovieRental.Location = new System.Drawing.Point(11, 30);
            this.lblMovieRental.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMovieRental.Name = "lblMovieRental";
            this.lblMovieRental.Size = new System.Drawing.Size(417, 69);
            this.lblMovieRental.TabIndex = 0;
            this.lblMovieRental.Text = "Movie Rental";
            this.lblMovieRental.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.label2.Location = new System.Drawing.Point(-2, -8);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 147);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.label3.Location = new System.Drawing.Point(396, -8);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(406, 147);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.label4.Location = new System.Drawing.Point(794, -8);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(406, 147);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.label5.Location = new System.Drawing.Point(1196, -8);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(406, 147);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // bttnMovies
            // 
            this.bttnMovies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(123)))), ((int)(((byte)(133)))));
            this.bttnMovies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnMovies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnMovies.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnMovies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.bttnMovies.Location = new System.Drawing.Point(789, 33);
            this.bttnMovies.Margin = new System.Windows.Forms.Padding(4);
            this.bttnMovies.Name = "bttnMovies";
            this.bttnMovies.Size = new System.Drawing.Size(240, 66);
            this.bttnMovies.TabIndex = 22;
            this.bttnMovies.Text = "MOVIES";
            this.bttnMovies.UseVisualStyleBackColor = false;
            this.bttnMovies.Click += new System.EventHandler(this.bttnMovies_Click);
            // 
            // bttnRENT
            // 
            this.bttnRENT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.bttnRENT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnRENT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnRENT.Font = new System.Drawing.Font("MS UI Gothic", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnRENT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.bttnRENT.Location = new System.Drawing.Point(1111, 260);
            this.bttnRENT.Margin = new System.Windows.Forms.Padding(4);
            this.bttnRENT.Name = "bttnRENT";
            this.bttnRENT.Size = new System.Drawing.Size(388, 97);
            this.bttnRENT.TabIndex = 23;
            this.bttnRENT.Text = "RENT";
            this.bttnRENT.UseVisualStyleBackColor = false;
            this.bttnRENT.Click += new System.EventHandler(this.bttnRENT_Click);
            // 
            // bttnSearch
            // 
            this.bttnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(123)))), ((int)(((byte)(133)))));
            this.bttnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnSearch.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.bttnSearch.Location = new System.Drawing.Point(1057, 33);
            this.bttnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.bttnSearch.Name = "bttnSearch";
            this.bttnSearch.Size = new System.Drawing.Size(240, 66);
            this.bttnSearch.TabIndex = 24;
            this.bttnSearch.Text = "REPORT";
            this.bttnSearch.UseVisualStyleBackColor = false;
            this.bttnSearch.Click += new System.EventHandler(this.bttnSearch_Click);
            // 
            // bttnLOGIN
            // 
            this.bttnLOGIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(123)))), ((int)(((byte)(133)))));
            this.bttnLOGIN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnLOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnLOGIN.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnLOGIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.bttnLOGIN.Location = new System.Drawing.Point(1325, 33);
            this.bttnLOGIN.Margin = new System.Windows.Forms.Padding(4);
            this.bttnLOGIN.Name = "bttnLOGIN";
            this.bttnLOGIN.Size = new System.Drawing.Size(240, 66);
            this.bttnLOGIN.TabIndex = 25;
            this.bttnLOGIN.Text = "LOGIN";
            this.bttnLOGIN.UseVisualStyleBackColor = false;
            this.bttnLOGIN.Click += new System.EventHandler(this.bttnLOGIN_Click);
            // 
            // bttnSIGNOUT
            // 
            this.bttnSIGNOUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(123)))), ((int)(((byte)(133)))));
            this.bttnSIGNOUT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnSIGNOUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnSIGNOUT.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnSIGNOUT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.bttnSIGNOUT.Location = new System.Drawing.Point(1325, 33);
            this.bttnSIGNOUT.Margin = new System.Windows.Forms.Padding(4);
            this.bttnSIGNOUT.Name = "bttnSIGNOUT";
            this.bttnSIGNOUT.Size = new System.Drawing.Size(240, 66);
            this.bttnSIGNOUT.TabIndex = 26;
            this.bttnSIGNOUT.Text = "SIGN OUT";
            this.bttnSIGNOUT.UseVisualStyleBackColor = false;
            this.bttnSIGNOUT.Click += new System.EventHandler(this.bttnSIGNOUT_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 53);
            this.label6.TabIndex = 29;
            this.label6.Text = "Customer";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(44, 260);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(333, 44);
            this.txtCustomerID.TabIndex = 30;
            //this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 25);
            this.label7.TabIndex = 31;
            this.label7.Text = "Enter Customer ID";
            // 
            // dgvCustomerQ
            // 
            this.dgvCustomerQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerQ.Location = new System.Drawing.Point(44, 349);
            this.dgvCustomerQ.Name = "dgvCustomerQ";
            this.dgvCustomerQ.RowHeadersWidth = 82;
            this.dgvCustomerQ.RowTemplate.Height = 33;
            this.dgvCustomerQ.Size = new System.Drawing.Size(333, 452);
            this.dgvCustomerQ.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 19.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(582, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 53);
            this.label1.TabIndex = 34;
            this.label1.Text = "Movie Selection";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(586, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 25);
            this.label8.TabIndex = 35;
            this.label8.Text = "Select a Movie";
            // 
            // ddMovies
            // 
            this.ddMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddMovies.FormattingEnabled = true;
            this.ddMovies.Location = new System.Drawing.Point(591, 259);
            this.ddMovies.Name = "ddMovies";
            this.ddMovies.Size = new System.Drawing.Size(333, 45);
            this.ddMovies.TabIndex = 36;
            this.ddMovies.SelectedIndexChanged += new System.EventHandler(this.ddMovies_SelectedIndexChanged);
            // 
            // bttnCustomers
            // 
            this.bttnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(123)))), ((int)(((byte)(133)))));
            this.bttnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnCustomers.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.bttnCustomers.Location = new System.Drawing.Point(520, 33);
            this.bttnCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.bttnCustomers.Name = "bttnCustomers";
            this.bttnCustomers.Size = new System.Drawing.Size(240, 66);
            this.bttnCustomers.TabIndex = 38;
            this.bttnCustomers.Text = "CUSTOMERS";
            this.bttnCustomers.UseVisualStyleBackColor = false;
            this.bttnCustomers.Click += new System.EventHandler(this.bttnCustomers_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 0;
            // 
            // numCopies
            // 
            this.numCopies.AutoSize = true;
            this.numCopies.BackColor = System.Drawing.Color.White;
            this.numCopies.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCopies.Location = new System.Drawing.Point(742, 638);
            this.numCopies.MaximumSize = new System.Drawing.Size(60, 60);
            this.numCopies.MinimumSize = new System.Drawing.Size(60, 60);
            this.numCopies.Name = "numCopies";
            this.numCopies.Size = new System.Drawing.Size(60, 60);
            this.numCopies.TabIndex = 39;
            // 
            // bttnQUEUE
            // 
            this.bttnQUEUE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.bttnQUEUE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnQUEUE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnQUEUE.Font = new System.Drawing.Font("MS UI Gothic", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnQUEUE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.bttnQUEUE.Location = new System.Drawing.Point(1111, 537);
            this.bttnQUEUE.Margin = new System.Windows.Forms.Padding(4);
            this.bttnQUEUE.Name = "bttnQUEUE";
            this.bttnQUEUE.Size = new System.Drawing.Size(388, 97);
            this.bttnQUEUE.TabIndex = 40;
            this.bttnQUEUE.Text = "QUEUE";
            this.bttnQUEUE.UseVisualStyleBackColor = false;
            this.bttnQUEUE.Click += new System.EventHandler(this.bttnQUEUE_Click);
            // 
            // FrmRENTAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(106)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.bttnQUEUE);
            this.Controls.Add(this.numCopies);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bttnCustomers);
            this.Controls.Add(lblAvailability);
            this.Controls.Add(this.ddMovies);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCustomerQ);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bttnSIGNOUT);
            this.Controls.Add(this.bttnLOGIN);
            this.Controls.Add(this.bttnSearch);
            this.Controls.Add(this.bttnRENT);
            this.Controls.Add(this.bttnMovies);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMovieRental);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmRENTAL";
            this.Text = "FrmRENTAL";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMovieRental;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bttnMovies;
        private System.Windows.Forms.Button bttnRENT;
        private System.Windows.Forms.Button bttnSearch;
        private System.Windows.Forms.Button bttnLOGIN;
        private System.Windows.Forms.Button bttnSIGNOUT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvCustomerQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddMovies;
        private System.Windows.Forms.Button bttnCustomers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label numCopies;
        private System.Windows.Forms.Button bttnQUEUE;
    }
}

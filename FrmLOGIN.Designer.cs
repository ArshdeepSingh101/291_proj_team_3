﻿namespace CS291_Proj
{
    partial class FrmLOGIN
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bttnCLEAR = new System.Windows.Forms.Button();
            this.bttnLOGIN = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.LblCrtAcct = new System.Windows.Forms.Label();
            this.CrtAcct = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(212, 870);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 19);
            this.label5.TabIndex = 23;
            this.label5.Text = "Create Account";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(167, 833);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 19);
            this.label4.TabIndex = 22;
            this.label4.Text = "Don\'t Have An Account?";
            // 
            // bttnCLEAR
            // 
            this.bttnCLEAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(106)))), ((int)(((byte)(112)))));
            this.bttnCLEAR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnCLEAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnCLEAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.bttnCLEAR.Location = new System.Drawing.Point(30, 346);
            this.bttnCLEAR.Name = "bttnCLEAR";
            this.bttnCLEAR.Size = new System.Drawing.Size(220, 43);
            this.bttnCLEAR.TabIndex = 21;
            this.bttnCLEAR.Text = "CLEAR";
            this.bttnCLEAR.UseVisualStyleBackColor = false;
            // 
            // bttnLOGIN
            // 
            this.bttnLOGIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.bttnLOGIN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnLOGIN.FlatAppearance.BorderSize = 0;
            this.bttnLOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnLOGIN.ForeColor = System.Drawing.Color.White;
            this.bttnLOGIN.Location = new System.Drawing.Point(30, 297);
            this.bttnLOGIN.Name = "bttnLOGIN";
            this.bttnLOGIN.Size = new System.Drawing.Size(220, 43);
            this.bttnLOGIN.TabIndex = 20;
            this.bttnLOGIN.Text = "LOGIN";
            this.bttnLOGIN.UseVisualStyleBackColor = false;
            this.bttnLOGIN.Click += new System.EventHandler(this.bttnLOGIN_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.Location = new System.Drawing.Point(26, 171);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(73, 19);
            this.txtPassword.TabIndex = 15;
            this.txtPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("MS UI Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(30, 126);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(220, 29);
            this.txtUsername.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(26, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(25, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "Welcome Back";
            // 
            // txtPW
            // 
            this.txtPW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPW.Font = new System.Drawing.Font("MS UI Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPW.Location = new System.Drawing.Point(30, 193);
            this.txtPW.Multiline = true;
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(220, 29);
            this.txtPW.TabIndex = 24;
            // 
            // LblCrtAcct
            // 
            this.LblCrtAcct.AutoSize = true;
            this.LblCrtAcct.ForeColor = System.Drawing.Color.Gainsboro;
            this.LblCrtAcct.Location = new System.Drawing.Point(53, 404);
            this.LblCrtAcct.Name = "LblCrtAcct";
            this.LblCrtAcct.Size = new System.Drawing.Size(169, 19);
            this.LblCrtAcct.TabIndex = 25;
            this.LblCrtAcct.Text = "Don\'t Have An Account?";
            // 
            // CrtAcct
            // 
            this.CrtAcct.AutoSize = true;
            this.CrtAcct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CrtAcct.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrtAcct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.CrtAcct.Location = new System.Drawing.Point(82, 423);
            this.CrtAcct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CrtAcct.Name = "CrtAcct";
            this.CrtAcct.Size = new System.Drawing.Size(111, 19);
            this.CrtAcct.TabIndex = 26;
            this.CrtAcct.Text = "Create Account";
            this.CrtAcct.Click += new System.EventHandler(this.CrtAcct_Click);
            // 
            // FrmLOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(123)))), ((int)(((byte)(133)))));
            this.ClientSize = new System.Drawing.Size(284, 489);
            this.Controls.Add(this.CrtAcct);
            this.Controls.Add(this.LblCrtAcct);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bttnCLEAR);
            this.Controls.Add(this.bttnLOGIN);
           // this.Controls.Add(this.CheckbxShowPW);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmLOGIN";
            //this.Load += new System.EventHandler(this.FrmLOGIN_Load); 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bttnCLEAR;
        private System.Windows.Forms.Button bttnLOGIN;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Label LblCrtAcct;
        private System.Windows.Forms.Label CrtAcct;
    }
}

namespace CS291_Proj
{
    partial class FrmSIGNUP_EMP
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.LblLOGIN = new System.Windows.Forms.Label();
            this.LblAcct = new System.Windows.Forms.Label();
            this.bttnCLEAR = new System.Windows.Forms.Button();
            this.bttnREGISTER = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.Label();
            this.txtIDNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPWCreate = new System.Windows.Forms.TextBox();
            this.txtCnfrmPW = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // LblAcct
            this.LblAcct.AutoSize = true;
            this.LblAcct.Font = new System.Drawing.Font("Nirmala UI", 10.125F, FontStyle.Bold);
            this.LblAcct.ForeColor = System.Drawing.Color.Gainsboro;
            this.LblAcct.Location = new System.Drawing.Point(54, 391);
            this.LblAcct.Name = "LblAcct";
            this.LblAcct.Size = new System.Drawing.Size(187, 19);
            this.LblAcct.TabIndex = 22;
            this.LblAcct.Text = "Already Have An Account?";

            // Other component initializations...

            // Form controls
            this.Controls.Add(this.txtCnfrmPW);
            this.Controls.Add(this.txtPWCreate);
            this.Controls.Add(this.LblLOGIN);
            this.Controls.Add(this.LblAcct);
            this.Controls.Add(this.bttnCLEAR);
            this.Controls.Add(this.bttnREGISTER);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtIDNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label LblLOGIN;
        private System.Windows.Forms.Label LblAcct;
        private System.Windows.Forms.Button bttnCLEAR;
        private System.Windows.Forms.Button bttnREGISTER;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.TextBox txtIDNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPWCreate;
        private System.Windows.Forms.TextBox txtCnfrmPW;
    }
}

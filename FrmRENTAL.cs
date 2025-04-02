using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS291_Proj
{
    public partial class FrmRENTAL : Form
    {
        public FrmRENTAL()
        {
            InitializeComponent();
        }

        private void FrmRental_Load(object sender, EventArgs e)
        {
            bttnRENT.Visible = false;
            bttnMovies.Visible = false;
            bttnSIGNOUT.Visible = false;
        }

        private void bttnRENT_Click(object sender, EventArgs e)
        {
            //Customer_form customersForm = new Customer_form();
            //customersForm.Show();
            //this.Hide();
        }
        private void bttnCustomers_Click(object sender, EventArgs e)
        {
            FrmCustomer customersForm = new FrmCustomer();
            customersForm.Show();
            this.Hide();
        }
        private void bttnMovies_Click(object sender, EventArgs e)
        {
            Movie_form moviesForm = new Movie_form();
            moviesForm.Show();
            this.Hide();
        }
        private void bttnSearch_Click(object sender, EventArgs e)
        {
            FrmReport reportForm = new FrmReport();
            reportForm.Show();
            this.Hide();
        }
        private void bttnLOGIN_Click(object sender, EventArgs e)
        {
            using (FrmLOGIN loginForm = new FrmLOGIN())
            {
                loginForm.ShowDialog();
                if (loginForm.IsLoggedIn)
                {
                    bttnRENT.Visible = true;
                    bttnSIGNOUT.Visible = true;
                    bttnLOGIN.Visible = false;
                }
            }
        }
        private void bttnSIGNOUT_Click(object sender, EventArgs e)
        {
            bttnRENT.Visible=false;
            bttnSIGNOUT.Visible=false;
            bttnLOGIN.Visible=true;

            MessageBox.Show("Logged out successfully");
        }


        private void dgvCustomerQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ddMovies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}

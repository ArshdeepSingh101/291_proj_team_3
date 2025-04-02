using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _291project
{
    public partial class Form2 : Form
    {
        private string connStr = "Server=Localhost;Database=DB291;Trusted_Connection=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int y = 2018; y <= 2025; y++)
            {
                comboBox1.Items.Add(y);
            }
            //  Month (1~12)
            for (int m = 1; m <= 12; m++)
            {
                comboBox2.Items.Add(m);
            }
            for (int y = 2018; y <= 2025; y++)
            {
                comboBox3.Items.Add(y);
            }
            for (int m = 1; m <= 12; m++)
            {
                comboBox4.Items.Add(m);
            }
            for (int y = 2018; y <= 2025; y++)
            {
                comboBox5.Items.Add(y);
            }
            //  Month (1~12)
            for (int m = 1; m <= 12; m++)
            {
                comboBox6.Items.Add(m);
            }
            for (int y = 2018; y <= 2025; y++)
            {
                comboBox7.Items.Add(y);
            }
            for (int m = 1; m <= 12; m++)
            {
                comboBox8.Items.Add(m);
            }
            for (int y = 2018; y <= 2025; y++)
            {
                comboBox9.Items.Add(y);
            }

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            comboBox9.SelectedIndex = -1;

            //  dataGridView1 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Generate  "Top 3 most rented movies"
        private void button1_Click(object sender, EventArgs e)
        {
            //  year/month
            int selectedYear = -1;
            int selectedMonth = -1;

            if (comboBox1.SelectedIndex != -1)  // Year
            {
                selectedYear = int.Parse(comboBox1.SelectedItem.ToString());
            }
            if (comboBox2.SelectedIndex != -1)  // Month
            {
                selectedMonth = int.Parse(comboBox2.SelectedItem.ToString());
            }

            // -1 for noe
            string sql = @"
        SELECT TOP 3
            M.MovieName,
            COUNT(*) AS RentalCount
        FROM RentalRecord R
        JOIN Movie M ON R.MovieID = M.MovieID
        WHERE (@year = -1 OR YEAR(R.CheckoutTime) = @year)
          AND (@month = -1 OR MONTH(R.CheckoutTime) = @month)
        GROUP BY M.MovieName
        ORDER BY RentalCount DESC;
    ";

            // 3) check
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@year", selectedYear);
                cmd.Parameters.AddWithValue("@month", selectedMonth);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // year / month
            int selectedYear = -1;
            int selectedMonth = -1;

            //  comboBoxYearCust 
            if (comboBox3.SelectedIndex != -1)
            {
                selectedYear = int.Parse(comboBox3.SelectedItem.ToString());
            }
            //  comboBoxMonthCust  int
            if (comboBox4.SelectedIndex != -1)
            {
                selectedMonth = int.Parse(comboBox4.SelectedItem.ToString());
            }

            // 2) SQL  Top 3 customers, with optional year/month filtering
            string sql = @"
        SELECT TOP 3
            (C.FirstName + ' ' + C.LastName) AS CustomerName,
            COUNT(*) AS RentalCount
        FROM RentalRecord R
        JOIN Customer C ON R.CustomerID = C.CustomerID
        WHERE (@year = -1 OR YEAR(R.CheckoutTime) = @year)
          AND (@month = -1 OR MONTH(R.CheckoutTime) = @month)
        GROUP BY C.FirstName, C.LastName
        ORDER BY RentalCount DESC;
    ";

            // 3) check
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@year", selectedYear);
                cmd.Parameters.AddWithValue("@month", selectedMonth);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                dataGridView2.DataSource = dt;
            }
        }
            private void button5_Click_1(object sender, EventArgs e)
        {
            // 1) selectedYear / selectedMonth
            int selectedYear = -1;
            int selectedMonth = -1;

            if (comboBox5.SelectedIndex != -1)
                selectedYear = int.Parse(comboBox5.SelectedItem.ToString());
            if (comboBox6.SelectedIndex != -1)
                selectedMonth = int.Parse(comboBox6.SelectedItem.ToString());

            // 2) SQL
            string sql = @"
        SELECT TOP 5
            A.ActorID,
            A.Name AS ActorName,
            COUNT(*) AS TotalRentals
        FROM Actor A
        JOIN ActorAppear AA ON A.ActorID = AA.ActorID
        JOIN RentalRecord R ON R.MovieID = AA.MovieID
        WHERE (@year = -1 OR YEAR(R.CheckoutTime) = @year)
          AND (@month = -1 OR MONTH(R.CheckoutTime) = @month)
        GROUP BY A.ActorID, A.Name
        ORDER BY TotalRentals DESC;
    ";

            // 3)  DataGridView3
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@year", selectedYear);
                cmd.Parameters.AddWithValue("@month", selectedMonth);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView3.DataSource = dt;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            // 1) 解析 year / month
            int selectedYear = -1;
            int selectedMonth = -1;

            if (comboBox7.SelectedIndex != -1)
            {
                selectedYear = int.Parse(comboBox7.SelectedItem.ToString());
            }
            if (comboBox8.SelectedIndex != -1)
            {
                selectedMonth = int.Parse(comboBox8.SelectedItem.ToString());
            }

            // 2) SQL: top 3 rated movies
            string sql = @"
        SELECT TOP 3
            M.MovieName,
            AVG(R.MovieRate) AS AvgRating
        FROM RentalRecord R
        JOIN Movie M ON R.MovieID = M.MovieID
        WHERE R.MovieRate IS NOT NULL
          AND (@year = -1 OR YEAR(R.CheckoutTime) = @year)
          AND (@month = -1 OR MONTH(R.CheckoutTime) = @month)
        GROUP BY M.MovieName
        ORDER BY AvgRating DESC;
    ";

            // 3) 执行查询
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@year", selectedYear);
                cmd.Parameters.AddWithValue("@month", selectedMonth);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 4) 显示到 DataGridView
                dataGridView4.DataSource = dt;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 1) 获取所选Year
            if (comboBox9.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a year.");
                return;
            }

            int selectedYear = int.Parse(comboBox9.SelectedItem.ToString());

            // 2) SQL
            string sql = @"
        SELECT 
            MONTH(R.CheckoutTime) AS [Month],
            SUM(M.Fee) AS TotalIncome
        FROM RentalRecord R
        JOIN Movie M ON R.MovieID = M.MovieID
        WHERE YEAR(R.CheckoutTime) = @year
        GROUP BY MONTH(R.CheckoutTime)
        ORDER BY [Month];
    ";

            // 3) 执行查询
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@year", selectedYear);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView5.DataSource = dt;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            dataGridView4.DataSource = null;
            dataGridView4.Rows.Clear();
            dataGridView4.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  
        private void button10_Click(object sender, EventArgs e)
        {
            comboBox9.SelectedIndex = -1;
            dataGridView5.DataSource = null;
            dataGridView5.Rows.Clear();
            dataGridView5.Refresh();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

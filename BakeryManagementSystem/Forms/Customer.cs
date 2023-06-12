using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem
{
    public partial class Customer : Form
    {
        private OrdersFilter ordersFilter;
        public Customer()
        {
            InitializeComponent();
            ordersFilter = new OrdersFilter();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\3)Third Year\ADBMS\db\BakeryManagementSystem.mdf"";Integrated Security=True;Connect Timeout=30");


        private void Customer_Load(object sender, EventArgs e)
        {
            this.Refresh();
            conn.Open();
            string query = "select * from customerDetails";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader row = cmd.ExecuteReader();

            cmbId.Items.Clear();
            cmbId.Items.Add("New Register");

            while (row.Read())
            {
                cmbId.Items.Add(row[0].ToString());
            }
            conn.Close();
            cmbId.SelectedIndex = 0;

            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            lblAddress.ForeColor = ThemeColor.PrimaryColor;
            lblId.ForeColor = ThemeColor.PrimaryColor;
            lblPno.ForeColor = ThemeColor.PrimaryColor;
            lblName.ForeColor = ThemeColor.SecondaryColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                string name = txtName.Text;
                string address = txtAddress.Text;
                int mPhone = int.Parse(txtPno.Text);

                string query = "insert into customerDetails values('" + name + "','" + mPhone + "','" + address + "')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record added Successfully!", "Registered Customer!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            DataTable orders = ordersFilter.GetOrdersByDateRange(startDate, endDate);

            dataGridView1.DataSource = orders;
        }
    }
}

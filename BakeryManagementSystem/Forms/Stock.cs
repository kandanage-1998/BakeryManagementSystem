using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BakeryManagementSystem.Forms
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private ComboBox selectItemBox;

        private void Stock_Load(object sender, EventArgs e)
        {
            LoadTheme();
            PopulateProductItems();

            SqlConnection conn = new SqlConnection(@"Data Source=DILSHAN-ROG\MSSQLSERVER01;Initial Catalog=BakeryManagementSystem;User ID=root1;Password=1234");

            string Query = "SELECT * FROM Stock";

            SqlDataAdapter adapter = new SqlDataAdapter(Query, conn);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "Stock");
            dataGridView1.DataSource = ds.Tables["Stock"];
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
            label1.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
            lblSelect.ForeColor = ThemeColor.SecondaryColor;
        }
        private void PopulateProductItems()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DILSHAN-ROG\MSSQLSERVER01;Initial Catalog=BakeryManagementSystem;User ID=root1;Password=1234");
            {
                connection.Open();

                string query = "SELECT name FROM Product";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        comboBox1.Items.Clear();

                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["name"].ToString());
                        }
                    }



                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

<<<<<<< Updated upstream
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DILSHAN-ROG\MSSQLSERVER01;Initial Catalog=BakeryManagementSystem;User ID=root1;Password=1234");

            string name = comboBox1.SelectedItem.ToString();
            decimal price = decimal.Parse(textBox1.Text);
            decimal quantity = numericUpDown1.Value;
            decimal total = decimal.Parse(textBox3.Text);

            string query = "INSERT INTO Stock values('" + name + "','" + price + "','" + quantity + "','" + total + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record added Successfully!", "Stock Added...!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = comboBox1.SelectedItem.ToString();

            SqlConnection connection = new SqlConnection(@"Data Source=DILSHAN-ROG\MSSQLSERVER01;Initial Catalog=BakeryManagementSystem;User ID=root1;Password=1234");

            {
                connection.Open();

                string query = "SELECT price FROM Product WHERE name = @productName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productName", selectedProduct);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        textBox1.Text = result.ToString();
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal quantity = numericUpDown1.Value;
            decimal itemPrice = decimal.Parse(textBox1.Text);
            decimal totalPrice;

            SqlConnection connection = new SqlConnection(@"Data Source=DILSHAN-ROG\MSSQLSERVER01;Initial Catalog=BakeryManagementSystem;User ID=root1;Password=1234");

            {
                SqlCommand command = new SqlCommand("CalculateTotalPrice", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@ItemPrice", itemPrice);

                SqlParameter totalPriceParam = new SqlParameter("@TotalPrice", SqlDbType.Decimal);
                totalPriceParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(totalPriceParam);

                connection.Open();
                command.ExecuteNonQuery();

                totalPrice = (decimal)totalPriceParam.Value;
            }

            textBox3.Text = totalPrice.ToString();
=======
        private void btnAdd_Click(object sender, EventArgs e)
        {

>>>>>>> Stashed changes
        }
    }
}

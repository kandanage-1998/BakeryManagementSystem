using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem
{
    public class OrderItem
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return $"Item: {GetItemName()}, Quantity: {Quantity}, Price:{Price}";
        }

        private string GetCustomerName()
        {
            string customerName = string.Empty;

            SqlConnection connection = new SqlConnection(@"Data Source=DILSHAN-ROG\MSSQLSERVER01;Initial Catalog=BakeryManagementSystem;User ID=root1;Password=1234");

            {
                connection.Open();

                string query = "SELECT Name FROM CustomerDetails WHERE Id = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);

                // Execute the query and retrieve the customer name
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    customerName = result.ToString();
                }
            }

            return customerName;
        }

        private string GetItemName()
        {
            string itemName = string.Empty;

            // Establish a connection to the database
            SqlConnection connection = new SqlConnection(@"Data Source=DILSHAN-ROG\MSSQLSERVER01;Initial Catalog=BakeryManagementSystem;User ID=root1;Password=1234");

            {
                connection.Open();

                string query = "SELECT Name FROM Product WHERE Id = @ItemID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemID", ItemID);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    itemName = result.ToString();
                }
            }

            return itemName;
        }

        
    }


}

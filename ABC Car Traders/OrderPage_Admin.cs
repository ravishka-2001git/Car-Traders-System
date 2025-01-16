using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ABC_Car_Traders
{
    public partial class OrderPage_Admin : Form
    {
        public OrderPage_Admin()
        {
            InitializeComponent();
        }

        // Initialize the SQL connection string
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True");


        private void OrderPage_Admin_Load(object sender, EventArgs e)
        {
            bind_data(); // Call the data binding method when the form loads
        }

        private void bind_data()
        {
            try
            {
                // Create the SQL command to select relevant columns from the Registration_Table
                SqlCommand cmd0 = new SqlCommand("SELECT OrderID AS [Order ID], CustomerName AS [Customer Name], CustomerPhone AS [Phone Number], CustomerAddress AS [Address], Orders AS [Orders], TotalPrice AS [Total Price],  OrderDate AS [Order Date], O_Status AS [Order Status] FROM Orders", conn);

                // Create a new data adapter and assign the command to it
                SqlDataAdapter daO = new SqlDataAdapter(cmd0);

                // Create a new data table to hold the results
                DataTable dt = new DataTable();
                dt.Clear(); // Clear any previous data

                // Fill the data table with the results of the SQL command
                daO.Fill(dt);

                Order_DataGrid.RowTemplate.Height = 45;

                // Bind the data table to the DataGridView
                Order_DataGrid.DataSource = dt;

                Order_DataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btn_Orders_Delete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (Order_DataGrid.CurrentRow != null)
            {
                // Get the Full Name of the selected row
                string selectedFullName = Order_DataGrid.CurrentRow.Cells["Order ID"].Value.ToString();

                // Confirm the deletion action
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Prepare the DELETE query using the Full Name as a condition
                    SqlCommand Cmd4 = new SqlCommand("Delete from Orders where OrderID=@OrderID", conn);
                    Cmd4.Parameters.AddWithValue("@OrderID", selectedFullName);

                    // Execute the query
                    conn.Open();
                    Cmd4.ExecuteNonQuery();
                    conn.Close();

                    // Remove the row from the DataGridView
                    Order_DataGrid.Rows.RemoveAt(Order_DataGrid.CurrentCell.RowIndex);

                    // Optionally, refresh the DataGridView to ensure data consistency
                    bind_data();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Orders_Update_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (Order_DataGrid.CurrentRow != null)
            {
                // Get the values from the selected row in DataGridView
                string OrderID = Order_DataGrid.CurrentRow.Cells["Order ID"].Value.ToString();
                string CustomerName = Order_DataGrid.CurrentRow.Cells["Customer Name"].Value.ToString();
                string CustomerPhone = Order_DataGrid.CurrentRow.Cells["Phone Number"].Value.ToString();
                string CustomerAddress = Order_DataGrid.CurrentRow.Cells["Address"].Value.ToString();
                string Orders = Order_DataGrid.CurrentRow.Cells["Orders"].Value.ToString();
                string TotalPrice = Order_DataGrid.CurrentRow.Cells["Total Price"].Value.ToString();
                string OrderDate = Order_DataGrid.CurrentRow.Cells["Order Date"].Value.ToString();
                string O_Status = Order_DataGrid.CurrentRow.Cells["Order Status"].Value.ToString();
                // Prepare the UPDATE SQL query
                SqlCommand cmd7 = new SqlCommand("UPDATE Orders SET CustomerName = @CustomerName, CustomerPhone = @CustomerPhone, CustomerAddress = @CustomerAddress, Orders = @Orders, TotalPrice = @TotalPrice, OrderDate = @OrderDate, O_Status = @O_Status WHERE OrderID = @OrderID", conn);

                // Add parameters with values
                cmd7.Parameters.AddWithValue("@OrderID", OrderID);
                cmd7.Parameters.AddWithValue("@CustomerName", CustomerName);
                cmd7.Parameters.AddWithValue("@CustomerPhone", CustomerPhone);
                cmd7.Parameters.AddWithValue("@CustomerAddress", CustomerAddress);
                cmd7.Parameters.AddWithValue("@Orders", Orders);
                cmd7.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                cmd7.Parameters.AddWithValue("@OrderDate", OrderDate);
                cmd7.Parameters.AddWithValue("@O_Status", O_Status);

                // Execute the query
                conn.Open();
                cmd7.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Row Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally, refresh the DataGridView to ensure data consistency
                bind_data();
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_Orders_Search_Click(object sender, EventArgs e)
        {
            string searchText = textSearch_Orders.Text.Trim();  // Get the text from the search TextBox

            if (!string.IsNullOrEmpty(searchText))
            {
                // SQL query to search for the entered text in various columns
                string query = "SELECT OrderID, CustomerName AS [Customer Name], CustomerPhone AS [Phone Number], CustomerAddress AS [Address], Orders AS [Orders], TotalPrice AS [Total Price],  OrderDate AS [Order Date], O_Status AS [Order Status] FROM Orders " +
"WHERE OrderID LIKE @SearchText OR CustomerName LIKE @SearchText OR CustomerPhone LIKE @SearchText OR CustomerAddress LIKE @SearchText OR Orders LIKE @SearchText OR TotalPrice LIKE @SearchText OR OrderDate LIKE @SearchText OR O_Status LIKE @SearchText";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Order_DataGrid.DataSource = dt;  // Bind the filtered data to the DataGridView
            }
            else
            {
                // If the search text is empty, reload all the data
                bind_data();
            }

        }

        private void btn_Orders_Refresh_Click(object sender, EventArgs e)
        {
            {
                // Clear the search textbox (optional, if you want to reset the search field)
                textSearch_Orders.Text = string.Empty;

                // Reload the full data into the DataGridView
                bind_data();

            }
        }

        private void Order_DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}

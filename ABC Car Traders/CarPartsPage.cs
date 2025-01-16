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

namespace ABC_Car_Traders
{
    public partial class CarPartsPage : Form
    {
        public CarPartsPage()
        {
            InitializeComponent();
        }

        // Initialize the SQL connection string
        private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True");

        private void CarPartsPage_Load(object sender, EventArgs e)
        {
            bind_data1(); // Call the data binding method when the form loads
        }

        private void bind_data1()
        {
            try
            {
                // Create the SQL command to select relevant columns from the CarPartsTable
                SqlCommand cmd3 = new SqlCommand("SELECT ID AS [P ID], PartName AS [Part Name], Category AS [Category], Quantity AS [Quantity], Price AS [Price], Supplier AS [Supplier], PartCode AS [Part Code], VehicleModel AS [Vehicle Model], Warranty AS [Warranty], PartImage AS [Part Image], Description AS [Description] FROM CarPartsTable", conn);

                // Create a new data adapter and assign the command to it
                SqlDataAdapter daa = new SqlDataAdapter(cmd3);

                // Create a new data table to hold the results
                DataTable dat = new DataTable();
                dat.Clear(); // Clear any previous data

                // Fill the data table with the results of the SQL command
                daa.Fill(dat);

                CarParts_dataGrid.RowTemplate.Height = 45;

                // Bind the data table to the DataGridView
                CarParts_dataGrid.DataSource = dat;

                CarParts_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btn_CarParts_Add_Click(object sender, EventArgs e)
        {
            AddCarPartsPage obj = new AddCarPartsPage();
            obj.Show();
        }

        private void btn_CarParts_Delete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (CarParts_dataGrid.CurrentRow != null)
            {
                // Get the ID of the selected row
                string selectedID = CarParts_dataGrid.CurrentRow.Cells["P ID"].Value.ToString();

                // Confirm the deletion action
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Prepare the DELETE query using the ID as a condition
                        SqlCommand Cmd5 = new SqlCommand("DELETE FROM CarPartsTable WHERE ID=@ID", conn);
                        Cmd5.Parameters.AddWithValue("@ID", selectedID);

                        // Execute the query
                        conn.Open();
                        int rowsAffected = Cmd5.ExecuteNonQuery();
                        conn.Close();

                        if (rowsAffected > 0)
                        {
                            // Remove the row from the DataGridView
                            CarParts_dataGrid.Rows.RemoveAt(CarParts_dataGrid.CurrentCell.RowIndex);

                            // Optionally, refresh the DataGridView to ensure data consistency
                            bind_data1();
                        }
                        else
                        {
                            MessageBox.Show("No records were deleted. Please check the ID and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Ensure the connection is closed if an exception occurs
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CarParts_Update_Click(object sender, EventArgs e)
        {
            if (CarParts_dataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = CarParts_dataGrid.SelectedRows[0];

                // Ensure the correct column name is used
                string CarPartsId = selectedRow.Cells["P ID"].Value.ToString();

                // Pass other details similarly
                string PartName = selectedRow.Cells["Part Name"].Value.ToString();
                string Category = selectedRow.Cells["Category"].Value.ToString();
                string Quantity = selectedRow.Cells["Quantity"].Value.ToString();
                string Price = selectedRow.Cells["Price"].Value.ToString();
                string Supplier = selectedRow.Cells["Supplier"].Value.ToString();
                string PartCode = selectedRow.Cells["Part Code"].Value.ToString();
                string VehicleModel = selectedRow.Cells["Vehicle Model"].Value.ToString();
                string Warranty = selectedRow.Cells["Warranty"].Value.ToString();
                string PartImage = selectedRow.Cells["Part Image"].Value.ToString();
                string Description = selectedRow.Cells["Description"].Value.ToString();

                // Create an instance of the UpdateCarPartsPage
                UpdateCarPartsPage updatePage1 = new UpdateCarPartsPage();

                // Initialize the form with the selected car Parts details
                updatePage1.InitializeForm1(CarPartsId, PartName, Category, Quantity, Price, Supplier, PartCode, VehicleModel, Warranty, PartImage, Description);

                // Show the update form
                updatePage1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Car Part to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_CarParts_Search_Click(object sender, EventArgs e)
        {
            string searchText = textSearch_CarParts.Text.Trim();  // Get the text from the search TextBox 

            if (!string.IsNullOrEmpty(searchText))
            {
                // SQL query to search for the entered text in various columns
                string query = "SELECT ID AS [P ID], PartName AS [Part Name], Category AS [Category]," +
                  " Quantity AS [Quantity], Price AS [Price], Supplier AS [Supplier], PartCode AS [Part Code], VehicleModel AS [Vehicle Model], Warranty AS [Warranty], PartImage AS [Part Image], Description AS [Description] FROM CarPartsTable " +  // Added space before WHERE

                  "WHERE ID LIKE @SearchText OR PartName LIKE @SearchText OR Category LIKE @SearchText OR " +
                  "Quantity LIKE @SearchText OR Price LIKE @SearchText OR Supplier LIKE @SearchText OR PartCode LIKE @SearchText OR VehicleModel " +  // Added space before LIKE
                  "LIKE @SearchText OR Warranty LIKE @SearchText";

                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    SqlCommand cmd5 = new SqlCommand(query, conn);
                    cmd5.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    SqlDataAdapter dcs = new SqlDataAdapter(cmd5);
                    DataTable dta = new DataTable();
                    dcs.Fill(dta);

                    CarParts_dataGrid.DataSource = dta;  // Bind the filtered data to the DataGridView
                }
            }
            else
            {
                // If the search text is empty, reload all the data
                bind_data1();
            }
        }

        private void btn_CarParts_Refresh_Click(object sender, EventArgs e)
        {
            // Clear the search textbox (optional, if you want to reset the search field)
            textSearch_CarParts.Text = string.Empty;

            // Reload the full data into the DataGridView
            bind_data1();
        }
    }
}
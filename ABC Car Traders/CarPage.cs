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
    public partial class CarPage : Form
    {
        public CarPage()
        {
            InitializeComponent();
        }
        // Initialize the SQL connection string
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True");

        private void CarPage_Load(object sender, EventArgs e)
        {
            bind_data(); // Call the data binding method when the form loads
        }

        private void bind_data()
        {
            try
            {
                // Create the SQL command to select relevant columns from the VehicleDetails
                SqlCommand cmd2 = new SqlCommand("SELECT ID AS [V ID], Brand AS [Brand], Model AS [Model], Year AS [Year], Price AS [Price], Color AS [Color], EnergyCapacity AS [Energy Capacity CC], Status AS [Status (R or UnR)], MileageKmh AS [Mileage Kmh], Stokes AS [Stokes], Transmission AS [Transmission], Fuel AS [Fuel], VehicleImage AS [Vehicle Image], Description AS [Description] FROM VehicleDetails", conn);

                // Create a new data adapter and assign the command to it
                SqlDataAdapter da = new SqlDataAdapter(cmd2);

                // Create a new data table to hold the results
                DataTable dt = new DataTable();
                dt.Clear(); // Clear any previous data

                // Fill the data table with the results of the SQL command
                da.Fill(dt);

                CarsDataGrid.RowTemplate.Height = 45;

                // Bind the data table to the DataGridView
                CarsDataGrid.DataSource = dt;

                CarsDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btn_Car_Add_Click(object sender, EventArgs e)
        {
            AddCarsPage obj = new AddCarsPage();
            obj.Show();
        }

        private void btn_Car_Delete_Click(object sender, EventArgs e)
        {

            // Ensure a row is selected in the DataGridView
            if (CarsDataGrid.CurrentRow != null)
            {
                // Get the Full Name of the selected row
                string selectedFullName = CarsDataGrid.CurrentRow.Cells["V ID"].Value.ToString();

                // Confirm the deletion action
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Prepare the DELETE query using the Full Name as a condition
                    SqlCommand Cmd5 = new SqlCommand("Delete from VehicleDetails where ID=@ID", conn);
                    Cmd5.Parameters.AddWithValue("ID", selectedFullName);

                    // Execute the query
                    conn.Open();
                    Cmd5.ExecuteNonQuery();
                    conn.Close();

                    // Remove the row from the DataGridView
                    CarsDataGrid.Rows.RemoveAt(CarsDataGrid.CurrentCell.RowIndex);

                    // Optionally, refresh the DataGridView to ensure data consistency
                    bind_data();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Car_Update_Click(object sender, EventArgs e)
        {
            if (CarsDataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = CarsDataGrid.SelectedRows[0];

                // Ensure the correct column name is used
                string carId = selectedRow.Cells["V ID"].Value.ToString();

                // Pass other details similarly
                string brand = selectedRow.Cells["Brand"].Value.ToString();
                string model = selectedRow.Cells["Model"].Value.ToString();
                string year = selectedRow.Cells["Year"].Value.ToString();
                string price = selectedRow.Cells["Price"].Value.ToString();
                string color = selectedRow.Cells["Color"].Value.ToString();
                string energyCapacity = selectedRow.Cells["Energy Capacity CC"].Value.ToString();
                string status = selectedRow.Cells["Status (R or UnR)"].Value.ToString();
                string mileageKmh = selectedRow.Cells["Mileage Kmh"].Value.ToString();
                string stokes = selectedRow.Cells["Stokes"].Value.ToString();
                string transmission = selectedRow.Cells["Transmission"].Value.ToString();
                string fuel = selectedRow.Cells["Fuel"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();

                // Retrieve the VehicleImage as a byte array from the database or directly from the DataGridView if stored correctly
                byte[] vehicleImage = (byte[])selectedRow.Cells["Vehicle Image"].Value;

                // Create an instance of the UpdateCarsPage
                UpdateCarsPage updatePage = new UpdateCarsPage();

                // Initialize the form with the selected car's details
                updatePage.InitializeForm(carId, brand, model, year, price, color, energyCapacity, status, mileageKmh, stokes, transmission, fuel, vehicleImage, description);

                // Show the update form
                updatePage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a car to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btn_Car_Search_Click(object sender, EventArgs e)
        {
            string searchText = textSearch_Car.Text.Trim();  // Get the text from the search TextBox 

            if (!string.IsNullOrEmpty(searchText))
            {
                // SQL query to search for the entered text in various columns
                string query = "SELECT ID AS [V ID], Brand AS [Brand], Model AS [Model]," +
                    " Year AS [Year], Price AS [Price], Color AS [Color], EnergyCapacity AS [Energy Capacity CC], Status AS [Status (R or UnR)], MileageKmh AS [Mileage Kmh], Stokes AS [Stokes], Transmission AS [Transmission]," +
                    " Fuel AS [Fuel], VehicleImage AS [Vehicle Image], Description AS [Description] FROM VehicleDetails " +  // Added space before WHERE

                    "WHERE ID LIKE @SearchText OR Brand LIKE @SearchText OR Model LIKE @SearchText OR " +
                    "Year LIKE @SearchText OR Price LIKE @SearchText OR Color LIKE @SearchText OR EnergyCapacity LIKE @SearchText OR Status " +  // Added space before LIKE
                    "LIKE @SearchText OR MileageKmh LIKE @SearchText OR Stokes LIKE @SearchText OR Transmission LIKE @SearchText OR Fuel LIKE @SearchText";

                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    SqlDataAdapter dc = new SqlDataAdapter(cmd);
                    DataTable dta = new DataTable();
                    dc.Fill(dta);

                    CarsDataGrid.DataSource = dta;  // Bind the filtered data to the DataGridView
                }
            }
            else
            {
                // If the search text is empty, reload all the data
                bind_data();
            }

        }

        private void btn_Car_Refresh_Click(object sender, EventArgs e)
        {
            // Clear the search textbox (optional, if you want to reset the search field)
            textSearch_Car.Text = string.Empty;

            // Reload the full data into the DataGridView
            bind_data();

        }

        private void textSearch_Car_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

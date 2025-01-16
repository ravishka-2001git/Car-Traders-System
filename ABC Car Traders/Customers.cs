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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        // Initialize the SQL connection string
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True");

        private void Customers_Load(object sender, EventArgs e)
        {
            bind_data(); // Call the data binding method when the form loads
        }

        private void bind_data()
        {
            try
            {
                // Create the SQL command to select relevant columns from the Registration_Table
                SqlCommand cmd1 = new SqlCommand("SELECT Full_Name AS [Full Name], Username AS [User Name], Phone_Number AS [Phone Number], Address AS [Address], Email AS [Email], Password AS [Password], Confirm_Password AS [Confirm Password], AdminOrUser AS [Admin/User] FROM Registration_Table", conn);

                // Create a new data adapter and assign the command to it
                SqlDataAdapter da = new SqlDataAdapter(cmd1);

                // Create a new data table to hold the results
                DataTable dt = new DataTable();
                dt.Clear(); // Clear any previous data

                // Fill the data table with the results of the SQL command
                da.Fill(dt);

                CustomersData.RowTemplate.Height = 45;

                // Bind the data table to the DataGridView
                CustomersData.DataSource = dt;

                CustomersData.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btn_Cust_Delete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (CustomersData.CurrentRow != null)
            {
                // Get the Full Name of the selected row
                string selectedFullName = CustomersData.CurrentRow.Cells["Full Name"].Value.ToString();

                // Confirm the deletion action
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Prepare the DELETE query using the Full Name as a condition
                    SqlCommand Cmd4 = new SqlCommand("Delete from Registration_Table where Full_Name=@Full_Name", conn);
                    Cmd4.Parameters.AddWithValue("@Full_Name", selectedFullName);

                    // Execute the query
                    conn.Open();
                    Cmd4.ExecuteNonQuery();
                    conn.Close();

                    // Remove the row from the DataGridView
                    CustomersData.Rows.RemoveAt(CustomersData.CurrentCell.RowIndex);

                    // Optionally, refresh the DataGridView to ensure data consistency
                    bind_data();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_Cust_Update_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (CustomersData.CurrentRow != null)
            {
                // Get the values from the selected row in DataGridView
                string fullName = CustomersData.CurrentRow.Cells["Full Name"].Value.ToString();
                string username = CustomersData.CurrentRow.Cells["User Name"].Value.ToString();
                string phoneNumber = CustomersData.CurrentRow.Cells["Phone Number"].Value.ToString();
                string address = CustomersData.CurrentRow.Cells["Address"].Value.ToString();
                string email = CustomersData.CurrentRow.Cells["Email"].Value.ToString();
                string password = CustomersData.CurrentRow.Cells["Password"].Value.ToString();
                string confirmPassword = CustomersData.CurrentRow.Cells["Confirm Password"].Value.ToString();
                string AdminOrUser = CustomersData.CurrentRow.Cells["Admin/User"].Value.ToString();

                // Prepare the UPDATE SQL query
                SqlCommand cmd2 = new SqlCommand("UPDATE Registration_Table SET Username = @Username, Phone_Number = @PhoneNumber, Address = @Address, Email = @Email, Password = @Password, Confirm_Password = @ConfirmPassword, AdminOrUser =@AdminOrUser WHERE Full_Name = @FullName", conn);

                // Add parameters with values
                cmd2.Parameters.AddWithValue("@Username", username);
                cmd2.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd2.Parameters.AddWithValue("@Address", address);
                cmd2.Parameters.AddWithValue("@Email", email);
                cmd2.Parameters.AddWithValue("@Password", password);
                cmd2.Parameters.AddWithValue("@ConfirmPassword", confirmPassword);
                cmd2.Parameters.AddWithValue("@AdminOrUser", AdminOrUser);
                cmd2.Parameters.AddWithValue("@FullName", fullName);

                // Execute the query
                conn.Open();
                cmd2.ExecuteNonQuery();
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

        private void btn_Cust_Search_Click(object sender, EventArgs e)
        {
           string searchText = textSearch_Cust.Text.Trim();  // Get the text from the search TextBox

              if (!string.IsNullOrEmpty(searchText))
                {
                    // SQL query to search for the entered text in various columns
                    string query = "SELECT Full_Name, Username AS [User Name], Phone_Number AS [Phone Number], " +
                                   "Address AS [Address], Email AS [Email], Password AS [Password], Confirm_Password AS [Confirm Password], AdminOrUser AS [Admin/User] " +
                                   "FROM Registration_Table " +
                                   "WHERE Full_Name LIKE @SearchText OR Username LIKE @SearchText OR Phone_Number LIKE @SearchText OR " +
                                   "Address LIKE @SearchText OR Email LIKE @SearchText OR AdminOrUser LIKE @SearchText";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    CustomersData.DataSource = dt;  // Bind the filtered data to the DataGridView
              }
              else
              {
                    // If the search text is empty, reload all the data
                    bind_data();
              }

        }

        private void btn_Cust_Refresh_Click(object sender, EventArgs e)
        {
             // Clear the search textbox (optional, if you want to reset the search field)
             textSearch_Cust.Text = string.Empty;

            // Reload the full data into the DataGridView
             bind_data();

        }

        private void CustomersData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btn_newAdmin_Click(object sender, EventArgs e)
        {
            AddNewAdmin obj = new AddNewAdmin();
            obj.Show();
        }
    }
}


using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class AddCarsPage : Form
    {
        public AddCarsPage()
        {
            InitializeComponent();

            // Initially hide Mileage KMH and Stokes components
            labelMileageKmh.Visible = false;
            textBoxMileageKmh.Visible = false;
            labelStokes.Visible = false;
            textBoxStokes.Visible = false;

            // Subscribe to the ComboBox SelectedIndexChanged event
            CBox_Status.SelectedIndexChanged += new EventHandler(CBox_Status_SelectedIndexChanged);
        }

        private void btn_AddNewCars_Click(object sender, EventArgs e)
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(txt_Brand.Text) ||
                string.IsNullOrWhiteSpace(txt_Model.Text) ||
                string.IsNullOrWhiteSpace(txt_Year.Text) ||
                string.IsNullOrWhiteSpace(txt_Price.Text) ||
                string.IsNullOrWhiteSpace(txt_Color.Text) ||
                string.IsNullOrWhiteSpace(txt_EnergyCC.Text) ||
                string.IsNullOrWhiteSpace(CBox_Status.Text) ||
                string.IsNullOrWhiteSpace(CBox_Transmission.Text) ||
                string.IsNullOrWhiteSpace(CBox_Fuel.Text) ||
                pictureBox_AddCar.Image == null)
            {
                // Show a message box if any field is empty
                MessageBox.Show("Please fill in the blank box", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Convert the image to a byte array
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox_AddCar.Image.Save(ms, ImageFormat.Jpeg); // Use appropriate image format
                imageBytes = ms.ToArray();
            }

            // If all validations pass, proceed with saving to the database
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            String InsertQuery = "INSERT INTO VehicleDetails (Brand, Model, Year, Price, Color, EnergyCapacity, Status, MileageKmh, Stokes, Transmission, Fuel, VehicleImage, Description) " +
                                 "VALUES (@Brand, @Model, @Year, @Price, @Color, @EnergyCapacity, @Status, @MileageKmh, @Stokes, @Transmission, @Fuel, @VehicleImage, @Description)";
            SqlCommand cmd = new SqlCommand(InsertQuery, con);
            cmd.Parameters.AddWithValue("@Brand", txt_Brand.Text);
            cmd.Parameters.AddWithValue("@Model", txt_Model.Text);
            cmd.Parameters.AddWithValue("@Year", txt_Year.Text);
            cmd.Parameters.AddWithValue("@Price", txt_Price.Text);
            cmd.Parameters.AddWithValue("@Color", txt_Color.Text);
            cmd.Parameters.AddWithValue("@EnergyCapacity", txt_EnergyCC.Text);
            cmd.Parameters.AddWithValue("@Status", CBox_Status.Text);
            cmd.Parameters.AddWithValue("@MileageKmh", textBoxMileageKmh.Text);
            cmd.Parameters.AddWithValue("@Stokes", textBoxStokes.Text);
            cmd.Parameters.AddWithValue("@Transmission", CBox_Transmission.Text);
            cmd.Parameters.AddWithValue("@Fuel", CBox_Fuel.Text);
            cmd.Parameters.AddWithValue("@VehicleImage", imageBytes);
            cmd.Parameters.AddWithValue("@Description", txt_Description.Text);
            cmd.ExecuteNonQuery();

            // Show a success message after saving to the database
            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optionally, clear the fields after successful registration
            ClearFields();

            con.Close();
        }

        // Function to clear all textboxes
        private void ClearFields()
        {
            txt_Brand.Clear();
            txt_Model.Clear();
            txt_Year.Clear();
            txt_Price.Clear();
            txt_Color.Clear();
            txt_EnergyCC.Clear();
            textBoxMileageKmh.Clear();
            textBoxStokes.Clear();
            txt_Description.Clear();
            pictureBox_AddCar.Image = null;
        }

        private void btn_CarImgAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_AddCar.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void CBox_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = CBox_Status.SelectedItem.ToString();

            if (selectedStatus.ToLower() == "registered")
            {
                // Show Mileage Kmh components
                labelMileageKmh.Visible = true;
                textBoxMileageKmh.Visible = true;

                // Hide Stokes components
                labelStokes.Visible = false;
                textBoxStokes.Visible = false;

                // Set Stokes to 1 when status is registered
                textBoxStokes.Text = "1";
            }
            else if (selectedStatus.ToLower() == "unregistered")
            {
                // Hide Mileage Kmh components
                labelMileageKmh.Visible = false;
                textBoxMileageKmh.Visible = false;

                // Show Stokes components
                labelStokes.Visible = true;
                textBoxStokes.Visible = true;

            }
        }

    }
}
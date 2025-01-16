using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class UpdateCarsPage : Form
    {
        private string carId;

        public UpdateCarsPage()
        {
            InitializeComponent();

            // Initially hide Mileage KMH and Stokes components
            labelMileageKmh.Visible = false;
            textBoxUpdateMileageKmh.Visible = false;
            labelStokes.Visible = false;
            textBoxUpdateStokes.Visible = false;

            // Subscribe to the ComboBox SelectedIndexChanged event
            CBox_UpdateStatus.SelectedIndexChanged += new EventHandler(CBox_UpdateStatus_SelectedIndexChanged);
        }

        public void InitializeForm(string id, string brand, string model, string year, string price, string color, string energyCapacity, string status, string mileageKmh, string stokes,
                                   string transmission, string fuel, byte[] vehicleImage, string description)
        {
            carId = id;

            // Populate the fields with the existing data
            txt_UpdateBrand.Text = brand;
            txt_UpdateModel.Text = model;
            txt_UpdateYear.Text = year;
            txt_UpdatePrice.Text = price;
            txt_UpdateColor.Text = color;
            txt_UpdateEnergyCC.Text = energyCapacity;
            CBox_UpdateStatus.Text = status;
            textBoxUpdateMileageKmh.Text = mileageKmh;
            textBoxUpdateStokes.Text = stokes;
            CBox_UpdateTransmission.Text = transmission;
            CBox_UpdateFuel.Text = fuel;
            txt_UpdateDescription.Text = description;

            // Load the image into the pictureBox if available
            if (vehicleImage != null && vehicleImage.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(vehicleImage))
                    {
                        pictureBox_UpdateCar.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load image: " + ex.Message);
                }
            }
        }

        private void btn_UpdateNewCars_Click(object sender, EventArgs e)
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(txt_UpdateBrand.Text) ||
                string.IsNullOrWhiteSpace(txt_UpdateModel.Text) ||
                string.IsNullOrWhiteSpace(txt_UpdateYear.Text) ||
                string.IsNullOrWhiteSpace(txt_UpdatePrice.Text) ||
                string.IsNullOrWhiteSpace(txt_UpdateColor.Text) ||
                string.IsNullOrWhiteSpace(txt_UpdateEnergyCC.Text) ||
                string.IsNullOrWhiteSpace(CBox_UpdateStatus.Text) ||
                string.IsNullOrWhiteSpace(CBox_UpdateTransmission.Text) ||
                string.IsNullOrWhiteSpace(CBox_UpdateFuel.Text) ||
                pictureBox_UpdateCar.Image == null ||
                string.IsNullOrWhiteSpace(txt_UpdateDescription.Text))
            {
                MessageBox.Show("Please fill in the blank box", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            if (!int.TryParse(txt_UpdateYear.Text, out _) || !decimal.TryParse(txt_UpdatePrice.Text, out _))
            {
                MessageBox.Show("Year and Price must be valid numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convert the image to a byte array
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox_UpdateCar.Image.Save(ms, ImageFormat.Jpeg); // Use appropriate image format
                imageBytes = ms.ToArray();
            }

            UpdateCar();
        }

        private void UpdateCar()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string updateQuery = "UPDATE VehicleDetails SET Brand=@Brand, Model=@Model, Year=@Year, Price=@Price, Color=@Color, " +
                                         "EnergyCapacity=@EnergyCapacity, Status=@Status, MileageKmh=@MileageKmh, Stokes=@Stokes, " +
                                         "Transmission=@Transmission, Fuel=@Fuel, VehicleImage=@VehicleImage, Description=@Description " +
                                         "WHERE ID=@ID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", carId);
                        cmd.Parameters.AddWithValue("@Brand", txt_UpdateBrand.Text);
                        cmd.Parameters.AddWithValue("@Model", txt_UpdateModel.Text);
                        cmd.Parameters.AddWithValue("@Year", txt_UpdateYear.Text);
                        cmd.Parameters.AddWithValue("@Price", txt_UpdatePrice.Text);
                        cmd.Parameters.AddWithValue("@Color", txt_UpdateColor.Text);
                        cmd.Parameters.AddWithValue("@EnergyCapacity", txt_UpdateEnergyCC.Text);
                        cmd.Parameters.AddWithValue("@Status", CBox_UpdateStatus.Text);
                        cmd.Parameters.AddWithValue("@MileageKmh", textBoxUpdateMileageKmh.Text);
                        cmd.Parameters.AddWithValue("@Stokes", textBoxUpdateStokes.Text);
                        cmd.Parameters.AddWithValue("@Transmission", CBox_UpdateTransmission.Text);
                        cmd.Parameters.AddWithValue("@Fuel", CBox_UpdateFuel.Text);

                        // Convert image to byte array and add as a parameter
                        if (pictureBox_UpdateCar.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox_UpdateCar.Image.Save(ms, pictureBox_UpdateCar.Image.RawFormat);
                                cmd.Parameters.AddWithValue("VehicleImage", ms.ToArray());
                            }
                        }
                        else
                        {
                            // Set the image parameter to null if no image is provided
                            cmd.Parameters.AddWithValue("@VehicleImage", DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("@Description", txt_UpdateDescription.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Car updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the car: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_UpdateImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Dispose of the existing image in the PictureBox to avoid memory leaks
                if (pictureBox_UpdateCar.Image != null)
                {
                    pictureBox_UpdateCar.Image.Dispose();
                    pictureBox_UpdateCar.Image = null;
                }

                // Load the selected image file into the PictureBox
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    pictureBox_UpdateCar.Image = Image.FromStream(fs);
                }
            }
        }

        private void CBox_UpdateStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = CBox_UpdateStatus.SelectedItem.ToString();

            if (selectedStatus.ToLower() == "registered")
            {
                // Show Mileage Kmh components
                labelMileageKmh.Visible = true;
                textBoxUpdateMileageKmh.Visible = true;

                // Hide Stokes components
                labelStokes.Visible = false;
                textBoxUpdateStokes.Visible = false;

                // Set Stokes to 1 when status is registered
                textBoxUpdateStokes.Text = "1";
            }
            else if (selectedStatus.ToLower() == "unregistered")
            {
                // Hide Mileage Kmh components
                labelMileageKmh.Visible = false;
                textBoxUpdateMileageKmh.Visible = false;

                // Show Stokes components
                labelStokes.Visible = true;
                textBoxUpdateStokes.Visible = true;
            }
        }

        private void btn_DeleteImg_Click(object sender, EventArgs e)
        {
            // Dispose of the existing image in the PictureBox to avoid memory leaks
            if (pictureBox_UpdateCar.Image != null)
            {
                pictureBox_UpdateCar.Image.Dispose();
                pictureBox_UpdateCar.Image = null;
            }
        }

        private void pictureBox_UpdateCar_Click(object sender, EventArgs e)
        {

        }
    }
}

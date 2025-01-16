using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class AddCarPartsPage : Form
    {
        public AddCarPartsPage()
        {
            InitializeComponent();
        }

        private void btn_AddCarParts_Click(object sender, EventArgs e)
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(txt_PartName.Text) ||
                string.IsNullOrWhiteSpace(txt_PartsQuantity.Text) ||
                string.IsNullOrWhiteSpace(txt_PartsPartCode.Text) ||
                string.IsNullOrWhiteSpace(txt_PartsPrice.Text) ||
                string.IsNullOrWhiteSpace(CBox_PartsCategory.Text) ||
                string.IsNullOrWhiteSpace(txt_VehicleModel.Text) ||
                pictureBox_Parts.Image == null)
            {
                // Show a message box if any field is empty
                MessageBox.Show("Please fill in all the required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Validate numeric fields
            if (!int.TryParse(txt_PartsQuantity.Text, out int quantity) ||
                !decimal.TryParse(txt_PartsPrice.Text, out decimal price) ||
                !int.TryParse(txt_PartsWarranty.Text, out int warranty))
            {
                MessageBox.Show("Please enter valid numbers for Quantity, Price, and Warranty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convert the image to a byte array
            byte[] imageBytes1;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox_Parts.Image.Save(ms, ImageFormat.Jpeg); // Use appropriate image format
                imageBytes1 = ms.ToArray();
            }

            // If all validations pass, proceed with saving to the database
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                string InsertQuery = "INSERT INTO CarPartsTable (PartName, Category, Quantity, Price, Supplier, PartCode, VehicleModel, Warranty, PartImage, Description) " +
                                     "VALUES (@PartName, @Category, @Quantity, @Price, @Supplier, @PartCode, @VehicleModel, @Warranty, @PartImage, @Description)";
                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@PartName", txt_PartName.Text);
                    cmd.Parameters.AddWithValue("@Category", CBox_PartsCategory.Text);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Supplier", txt_PartsSupplier.Text);
                    cmd.Parameters.AddWithValue("@PartCode", txt_PartsPartCode.Text);
                    cmd.Parameters.AddWithValue("@VehicleModel", txt_VehicleModel.Text);
                    cmd.Parameters.AddWithValue("@Warranty", warranty);
                    cmd.Parameters.AddWithValue("@PartImage", imageBytes1);
                    cmd.Parameters.AddWithValue("@Description", txt_PartsDescription.Text);
                    cmd.ExecuteNonQuery();
                }

                // Show a success message after saving to the database
                MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally, clear the fields after successful registration
                ClearFields();
            }
        }

        // Function to clear all textboxes
        private void ClearFields()
        {
            txt_PartName.Clear();
            CBox_PartsCategory.SelectedIndex = -1;
            txt_PartsQuantity.Clear();
            txt_PartsPrice.Clear();
            txt_PartsSupplier.Clear();
            txt_PartsPartCode.Clear();
            txt_VehicleModel.Clear();
            txt_PartsWarranty.Clear();
            txt_PartsDescription.Clear();
            pictureBox_Parts.Image = null;
        }

        private void pictureBox_Parts_Click(object sender, EventArgs e)
        {
            // You can add additional logic here if needed
        }

        private void btn_CarPartsImgAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Parts.Image = new Bitmap(openFileDialog.FileName);
            }
        }
    }
}

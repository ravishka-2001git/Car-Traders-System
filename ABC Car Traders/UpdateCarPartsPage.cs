using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace ABC_Car_Traders
{
    public partial class UpdateCarPartsPage : Form
    {
        private string CarPartsId;

        public UpdateCarPartsPage()
        {
            InitializeComponent();
        }

        public void InitializeForm1(string ID, string PartName, string Category, string Quantity, string Price, string Supplier, string PartCode, string VehicleModel, string Warranty, string PartImage, string Description)
        {
            CarPartsId = ID;

            // Populate the fields with the existing data
            txt_UpPartName.Text = PartName;
            CBox_UpPartsCategory.Text = Category;
            txt_UpPartsQuantity.Text = Quantity;
            txt_UpPartsPrice.Text = Price;
            txt_UpPartsSupplier.Text = Supplier;
            txt_UpPartsPartCode.Text = PartCode;
            CBox_UpPartsVModel.Text = VehicleModel;
            txt_UpPartsWarranty.Text = Warranty;
            txt_UpPartsDescription.Text = Description;

            // Load the image from base64 string or file path if necessary
            if (!string.IsNullOrEmpty(PartImage))
            {
                // Example if PartImage is a base64 string:
                //byte[] imageBytes = Convert.FromBase64String(PartImage);
                //using (MemoryStream ms = new MemoryStream(imageBytes))
                //{
                //    pictureBox_UpParts.Image = Image.FromStream(ms);
                //}
            }
        }

        private void btn_UpCarParts_Click(object sender, EventArgs e)
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(txt_UpPartName.Text) ||
                string.IsNullOrWhiteSpace(CBox_UpPartsCategory.Text) ||
                string.IsNullOrWhiteSpace(txt_UpPartsQuantity.Text) ||
                string.IsNullOrWhiteSpace(txt_UpPartsSupplier.Text) ||
                string.IsNullOrWhiteSpace(txt_UpPartsPartCode.Text) ||
                string.IsNullOrWhiteSpace(CBox_UpPartsVModel.Text) ||
                string.IsNullOrWhiteSpace(txt_UpPartsWarranty.Text) ||
                string.IsNullOrWhiteSpace(txt_UpPartsDescription.Text))
            {
                MessageBox.Show("Please fill in all the required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_UpPartsPrice.Text, out _))
            {
                MessageBox.Show("Price must be valid numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateCarParts();
        }

        private void UpdateCarParts()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string updateQuery = "UPDATE CarPartsTable SET PartName=@PartName, Category=@Category, Quantity=@Quantity, Price=@Price, Supplier=@Supplier, PartCode=@PartCode, VehicleModel=@VehicleModel, Warranty=@Warranty, PartImage=@PartImage, Description=@Description WHERE ID=@ID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", CarPartsId);
                        cmd.Parameters.AddWithValue("@PartName", txt_UpPartName.Text);
                        cmd.Parameters.AddWithValue("@Category", CBox_UpPartsCategory.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txt_UpPartsQuantity.Text);
                        cmd.Parameters.AddWithValue("@Price", txt_UpPartsPrice.Text);
                        cmd.Parameters.AddWithValue("@Supplier", txt_UpPartsSupplier.Text);
                        cmd.Parameters.AddWithValue("@PartCode", txt_UpPartsPartCode.Text);
                        cmd.Parameters.AddWithValue("@VehicleModel", CBox_UpPartsVModel.Text);
                        cmd.Parameters.AddWithValue("@Warranty", txt_UpPartsWarranty.Text);

                        if (pictureBox_UpParts.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox_UpParts.Image.Save(ms, ImageFormat.Jpeg); // Use appropriate image format
                                byte[] imageBytes = ms.ToArray();
                                cmd.Parameters.Add("@PartImage", SqlDbType.VarBinary, -1).Value = imageBytes;
                            }
                        }
                        else
                        {
                            cmd.Parameters.Add("@PartImage", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                        }

                        cmd.Parameters.AddWithValue("@Description", txt_UpPartsDescription.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Car updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Optionally call a method to refresh the DataGridView in the parent form
                // For example:
                // ((MainForm)this.Owner).RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the car: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

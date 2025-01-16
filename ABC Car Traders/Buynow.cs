using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class Buynow : Form
    {
        private List<UserOrderPage.OrderItem> _orders;
        private decimal _totalPrice;

        public Buynow(List<UserOrderPage.OrderItem> orders, decimal totalPrice)
        {
            InitializeComponent();
            _orders = orders;
            _totalPrice = totalPrice;
            DisplayOrders(_orders);
            lblTotalPrice.Text = "Total Price: RS. " + _totalPrice.ToString("F2");
        }

        private void DisplayOrders(List<UserOrderPage.OrderItem> orders)
        {
            foreach (var order in orders)
            {
                listBoxOrders.Items.Add((order.Car?.Brand ?? order.CarParts?.PartName) + " - RS. " + order.Price.ToString("F2"));
            }
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            string customerName = txt_BuyN_Cname.Text;
            string customerPhone = txt_BuyN_CPhone.Text;
            string customerAddress = txt_BuyN_Address.Text;
            string orders = string.Join(", ", listBoxOrders.Items.Cast<string>().ToArray());
            decimal totalPrice = _totalPrice;
            string status = "pending";

            string connectionString = "Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Orders (CustomerName, CustomerPhone, CustomerAddress, Orders, TotalPrice, O_Status) " +
                               "VALUES (@CustomerName, @CustomerPhone, @CustomerAddress, @Orders, @TotalPrice, @O_Status)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                    cmd.Parameters.AddWithValue("@CustomerAddress", customerAddress);
                    cmd.Parameters.AddWithValue("@Orders", orders);
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    cmd.Parameters.AddWithValue("@O_Status", status);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            MessageBox.Show("Order placed successfully!");

            txt_BuyN_Cname.Clear();
            txt_BuyN_CPhone.Clear();
            txt_BuyN_Address.Clear();
            listBoxOrders.Items.Clear();
            lblTotalPrice.Text = "Total Price: RS. 0.00";
        }

        private void btn_Bill_Click(object sender, EventArgs e)
        {
            // Retrieve the details to include in the bill
            string customerName = txt_BuyN_Cname.Text;
            string customerPhone = txt_BuyN_CPhone.Text;
            string customerAddress = txt_BuyN_Address.Text;
            string orders = string.Join(", ", listBoxOrders.Items.Cast<string>().ToArray());
            decimal totalPrice = _totalPrice;

            // Create PDF document
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);

            // Define file path for PDF
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OrderBill.pdf");

            try
            {
                // Create PDF writer
                PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));

                // Open the document for writing
                pdfDoc.Open();

                // Add Title
                pdfDoc.Add(new Paragraph("ABC Car Traders - Order Bill"));
                pdfDoc.Add(new Paragraph(" "));

                // Add Customer Information
                pdfDoc.Add(new Paragraph("Customer Name: " + customerName));
                pdfDoc.Add(new Paragraph("Phone: " + customerPhone));
                pdfDoc.Add(new Paragraph("Address: " + customerAddress));
                pdfDoc.Add(new Paragraph(" "));

                // Add Order Items
                pdfDoc.Add(new Paragraph("Order Items:"));
                foreach (var order in listBoxOrders.Items)
                {
                    pdfDoc.Add(new Paragraph(order.ToString()));
                }

                pdfDoc.Add(new Paragraph(" "));

                // Add Total Price
                pdfDoc.Add(new Paragraph("Total Price: RS. " + totalPrice.ToString("F2")));

                // Close the document
                pdfDoc.Close();

                // Display success message and open PDF
                MessageBox.Show("Bill downloaded successfully!");
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message);
            }
        }
    }
}

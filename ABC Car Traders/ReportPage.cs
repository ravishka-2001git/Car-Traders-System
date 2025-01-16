using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

namespace ABC_Car_Traders
{
    public partial class ReportPage : Form
    {
        private string connectionString = "Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True";

        public ReportPage()
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged; // Event to handle date change
        }

        // Method to load report data
        private void LoadReportData(DateTime selectedDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string dateFilter = selectedDate.ToString("yyyy-MM-dd");

                    // Full Vehicle Count (no date filter since VehicleDetails doesn't have OrderDate)
                    string queryFullVehicleCount = "SELECT SUM(Stokes) FROM VehicleDetails";
                    SqlCommand cmdFullVehicleCount = new SqlCommand(queryFullVehicleCount, conn);
                    lblFullVehicleCount.Text = cmdFullVehicleCount.ExecuteScalar()?.ToString() ?? "0";

                    // Registered Vehicle Count (no date filter)
                    string queryRegisteredVehicleCount = "SELECT SUM(Stokes) FROM VehicleDetails WHERE Status = 'registered'";
                    SqlCommand cmdRegisteredVehicleCount = new SqlCommand(queryRegisteredVehicleCount, conn);
                    lblRegisteredVehicleCount.Text = cmdRegisteredVehicleCount.ExecuteScalar()?.ToString() ?? "0";

                    // Unregistered Vehicle Count (no date filter)
                    string queryUnregisteredVehicleCount = "SELECT SUM(Stokes) FROM VehicleDetails WHERE Status = 'unregistered'";
                    SqlCommand cmdUnregisteredVehicleCount = new SqlCommand(queryUnregisteredVehicleCount, conn);
                    lblUnregisteredVehicleCount.Text = cmdUnregisteredVehicleCount.ExecuteScalar()?.ToString() ?? "0";

                    // Full Parts Count (no date filter)
                    string queryFullPartsCount = "SELECT SUM(Quantity) FROM CarPartsTable";
                    SqlCommand cmdFullPartsCount = new SqlCommand(queryFullPartsCount, conn);
                    lblFullPartsCount.Text = cmdFullPartsCount.ExecuteScalar()?.ToString() ?? "0";

                    // Orders Count (filtered by OrderDate)
                    string queryOrdersCount = $"SELECT COUNT(*) FROM Orders WHERE CONVERT(DATE, OrderDate) = '{dateFilter}'";
                    SqlCommand cmdOrdersCount = new SqlCommand(queryOrdersCount, conn);
                    lblOrdersCount.Text = cmdOrdersCount.ExecuteScalar()?.ToString() ?? "0";

                    // Total Profit (filtered by OrderDate)
                    string queryTotalProfit = $"SELECT SUM(TotalPrice) FROM Orders WHERE CONVERT(DATE, OrderDate) = '{dateFilter}'";
                    SqlCommand cmdTotalProfit = new SqlCommand(queryTotalProfit, conn);
                    object result = cmdTotalProfit.ExecuteScalar();
                    decimal totalProfit = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    lblTotalProfit.Text = "RS. " + totalProfit.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report data: " + ex.Message);
            }
        }

        // Event handler for DateTimePicker value change
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadReportData(dateTimePicker1.Value); // Load data based on the selected date for the Orders table
        }

        // Method to export report to PDF
        private void ExportToPDF()
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF files|*.pdf", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Document doc = new Document(PageSize.A4);
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        Paragraph title = new Paragraph("Report Summary") { Alignment = Element.ALIGN_CENTER };
                        doc.Add(title);

                        doc.Add(new Paragraph(" "));
                        doc.Add(new Paragraph($"Date: {dateTimePicker1.Value.ToShortDateString()}"));
                        doc.Add(new Paragraph($"Full Vehicle Count: {lblFullVehicleCount.Text}"));
                        doc.Add(new Paragraph($"Registered Vehicle Count: {lblRegisteredVehicleCount.Text}"));
                        doc.Add(new Paragraph($"Unregistered Vehicle Count: {lblUnregisteredVehicleCount.Text}"));
                        doc.Add(new Paragraph($"Full Parts Count: {lblFullPartsCount.Text}"));
                        doc.Add(new Paragraph($"Orders Count: {lblOrdersCount.Text}"));
                        doc.Add(new Paragraph($"Total Profit: {lblTotalProfit.Text}"));

                        doc.Close();
                        MessageBox.Show("PDF Report Generated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message);
            }
        }

        // Method to export report to Excel
        private void ExportToExcel()
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Report");
                            worksheet.Cell(1, 1).Value = "Report Summary";
                            worksheet.Cell(2, 1).Value = $"Date: {dateTimePicker1.Value.ToShortDateString()}";
                            worksheet.Cell(3, 1).Value = $"Full Vehicle Count: {lblFullVehicleCount.Text}";
                            worksheet.Cell(4, 1).Value = $"Registered Vehicle Count: {lblRegisteredVehicleCount.Text}";
                            worksheet.Cell(5, 1).Value = $"Unregistered Vehicle Count: {lblUnregisteredVehicleCount.Text}";
                            worksheet.Cell(6, 1).Value = $"Full Parts Count: {lblFullPartsCount.Text}";
                            worksheet.Cell(7, 1).Value = $"Orders Count: {lblOrdersCount.Text}";
                            worksheet.Cell(8, 1).Value = $"Total Profit: {lblTotalProfit.Text}";

                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Excel Report Generated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Excel: " + ex.Message);
            }
        }

        // Event handler for Download button click
        private void btn_ReportDown_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to download the report as a PDF?", "Download Report", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ExportToPDF();
            }
            else
            {
                ExportToExcel();
            }
        }
    }
}

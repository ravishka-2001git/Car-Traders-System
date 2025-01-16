using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ABC_Car_Traders.CarPartsPage_User;

namespace ABC_Car_Traders
{
    public partial class CarPartsPage_User : Form
    {
        private List<CarParts> carsP = new List<CarParts>();
        private UserOrderPage orderPage;

        public CarPartsPage_User(UserOrderPage orderPage)
        {
            InitializeComponent();
            this.orderPage = orderPage;
            InitializePanel();
            LoadCarDetails();
        }

        private void InitializePanel()
        {
            CarParts_UserPanel.AutoScroll = true;
        }

        public class CarParts
        {
            public string Id { get; set; }
            public string PartName { get; set; }
            public string Category { get; set; }
            public string PartCode { get; set; }
            public int Price { get; set; }
            public string PartImage { get; set; }
            public int Quantity { get; set; }
            public string Description { get; set; }
        }

        private void LoadCarDetails()
        {
            CarParts_UserPanel.Controls.Clear();
            carsP.Clear();

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
            {
                string query = "SELECT ID AS [P ID], PartName AS [Part Name], Category AS [Category], Quantity AS [Quantity], Price AS [Price], Supplier AS [Supplier], PartCode AS [Part Code], VehicleModel AS [Vehicle Model], Warranty AS [Warranty], PartImage AS [Part Image], Description AS [Description] FROM CarPartsTable";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int yPos = 10;

                    while (reader.Read())
                    {
                        CarParts carparts = new CarParts
                        {
                            Id = reader["P ID"].ToString(),
                            PartName = reader["Part Name"].ToString(),
                            Category = reader["Category"].ToString(),
                            Price = Convert.ToInt32(reader["Price"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            PartImage = reader["Part Image"].ToString(),
                            PartCode = reader["Part Code"].ToString(),
                            Description = reader["Description"].ToString(),
                        };
                        carsP.Add(carparts);

                        Panel carPartsPanel = new Panel
                        {
                            Width = CarParts_UserPanel.Width - 40,
                            Height = 120,
                            Top = yPos,
                            Left = 10,
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.FromArgb(155, Color.Black),
                            ForeColor = Color.White
                        };

                        PictureBox carPartsImage = new PictureBox
                        {
                            Width = 150,
                            Height = 100,
                            Top = 10,
                            Left = 10,
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };

                        try
                        {
                            byte[] imageBytes = (byte[])reader["Part Image"];
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    carPartsImage.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                carPartsImage.Image = Properties.Resources.Partspic;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to load image: {ex.Message}");
                            carPartsImage.Image = Properties.Resources.Partspic;
                        }

                        carPartsPanel.Controls.Add(carPartsImage);

                        Label lblCarParstName = new Label
                        {
                            Text = carparts.PartName,
                            Top = 10,
                            Left = 180,
                            Width = 200,
                            Font = new Font("Arial", 14, FontStyle.Bold),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblCarParstName);

                        Label lblCategory = new Label
                        {
                            Text = carparts.Category,
                            Top = 40,
                            Left = 180,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblCategory);

                        Label lblPartCode = new Label
                        {
                            Text = carparts.PartCode,
                            Top = 65,
                            Left = 180,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblPartCode);

                        Label lblDescription = new Label
                        {
                            Text = carparts.Description,
                            Top = 90,
                            Left = 180,
                            Width = 200,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblDescription);

                        Label lblPrice = new Label
                        {
                            Text = "RS. " + carparts.Price.ToString(),
                            Top = 70,
                            Left = 400,
                            Width = 200,
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblPrice);

                        // Quantity Display
                        Label lblQuantity = new Label
                        {
                            Text = $"Available: {carparts.Quantity}",
                            Top = 10,
                            Left = 720,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblQuantity);

                        Label lblQty = new Label
                        {
                            Text = "Qty: ",
                            Top = 40,
                            Left = 695,
                            Width = 30,
                            Font = new Font("Arial", 8),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblQty);

                        // Customer Quantity Input
                        TextBox txtQuantity = new TextBox
                        {
                            Top = 40,
                            Left = 720,
                            Width = 41,
                            Font = new Font("Arial", 10),
                            Size = new Size(50, 22)
                        };
                        carPartsPanel.Controls.Add(txtQuantity);

                        Button btnOrder = new Button
                        {
                            Text = "Order",
                            Top = 80,
                            Left = 720,
                            Width = 100,
                            Font = new Font("Arial", 10)
                        };

                        btnOrder.Click += (s, eArgs) =>
                        {
                            int orderQuantity;
                            if (int.TryParse(txtQuantity.Text, out orderQuantity) && orderQuantity > 0)
                            {
                                if (orderQuantity <= carparts.Quantity)
                                {
                                    OrderCarParts(carparts.Id, orderQuantity);
                                    txtQuantity.Text = carparts.Quantity.ToString(); // Update displayed Quantity
                                }
                                else
                                {
                                    MessageBox.Show("Not enough stock available.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid quantity.");
                            }
                        };

                        carPartsPanel.Controls.Add(btnOrder);

                        CarParts_UserPanel.Controls.Add(carPartsPanel);

                        yPos += 130;
                    }
                }
            }
        }

        private void OrderCarParts(string carPartsId, int quantity)
        {
            CarParts selectedCarPaarts = carsP.Find(c => c.Id == carPartsId);
            if (selectedCarPaarts != null)
            {
                selectedCarPaarts.Quantity -= quantity;
                UpdateCarPartsQuantityInDatabase(selectedCarPaarts.Id, selectedCarPaarts.Quantity);

                if (orderPage == null)
                {
                    orderPage = new UserOrderPage();
                }

                orderPage.AddOrderItem(selectedCarPaarts, quantity);
                orderPage.BringToFront();
                LoadCarDetails(); // Refresh car details to show updated stock
            }
        }

        private void UpdateCarPartsQuantityInDatabase(string carPartsId, int newQuantity)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "UPDATE CarPartsTable SET Quantity = @Quantity WHERE ID = @PartsId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                    cmd.Parameters.AddWithValue("@PartsId", carPartsId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btn_CarPaers_SearchUser_Click(object sender, EventArgs e)
        {
            string searchText = textSearch_CarParts.Text.Trim();  // Get the text from the search TextBox 

            CarParts_UserPanel.Controls.Clear(); // Clear existing controls

            if (!string.IsNullOrEmpty(searchText))
            {
                string query = "SELECT * FROM CarPartsTable WHERE PartName LIKE @SearchText OR Category LIKE @SearchText OR PartCode LIKE @SearchText OR PartImage LIKE @SearchText OR Price LIKE @SearchText";

                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    int yPos = 10;

                    while (reader.Read())
                    {
                        Panel carPartsPanel = new Panel
                        {
                            Width = CarParts_UserPanel.Width - 40, // Leave space for scrollbar
                            Height = 120,
                            Top = yPos,
                            Left = 10,
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.FromArgb(155, Color.Black),
                            ForeColor = Color.White
                        };

                        PictureBox carPartsImage = new PictureBox
                        {
                            Width = 150,
                            Height = 100,
                            Top = 10,
                            Left = 10,
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };

                        try
                        {
                            byte[] imageBytes = (byte[])reader["PartImage"];
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    carPartsImage.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                carPartsImage.Image = Properties.Resources.Partspic;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to load image: {ex.Message}");
                            carPartsImage.Image = Properties.Resources.Partspic;
                        }

                        carPartsPanel.Controls.Add(carPartsImage);

                        Label lblCarParstName = new Label
                        {
                            Text = reader["PartName"].ToString(),
                            Top = 10,
                            Left = 180,
                            Width = 200,
                            Font = new Font("Arial", 14, FontStyle.Bold),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblCarParstName);

                        Label lblCategory = new Label
                        {
                            Text = reader["Category"].ToString(),
                            Top = 40,
                            Left = 180,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblCategory);

                        Label lblPartCode = new Label
                        {
                            Text = reader["PartCode"].ToString(),
                            Top = 65,
                            Left = 180,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblPartCode);

                        Label lblDescription = new Label
                        {
                            Text = reader["Description"].ToString(),
                            Top = 90,
                            Left = 180,
                            Width = 200,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblDescription);

                        Label lblPrice = new Label
                        {
                            Text = "RS. " + reader["Price"].ToString(),
                            Top = 70,
                            Left = 400,
                            Width = 200,
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblPrice);

                        // Get the ID and Quantity values outside of the event handler
                        string partId = reader["ID"].ToString();
                        int availableQuantity = Convert.ToInt32(reader["Quantity"]);

                        // Quantity label and text box
                        Label lblQuantity = new Label
                        {
                            Text = "Available : " + availableQuantity.ToString(),
                            Top = 10,
                            Left = 720,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblQuantity);

                        Label lblQty = new Label
                        {
                            Text = "Qty: ",
                            Top = 40,
                            Left = 695,
                            Width = 30,
                            Font = new Font("Arial", 8),
                            BackColor = Color.Transparent
                        };
                        carPartsPanel.Controls.Add(lblQty);

                        TextBox txtQuantity = new TextBox
                        {
                            Top = 40,
                            Left = 720,
                            Width = 41,
                            Font = new Font("Arial", 10),
                            Size = new Size(50, 22)
                        };
                        carPartsPanel.Controls.Add(txtQuantity);

                        Button btnOrder = new Button
                        {
                            Text = "Order",
                            Top = 80,
                            Left = 720,
                            Width = 100,
                            Font = new Font("Arial", 10)
                        };

                        btnOrder.Click += (s, eArgs) =>
                        {
                            int orderQuantity;
                            if (int.TryParse(txtQuantity.Text, out orderQuantity) && orderQuantity > 0)
                            {
                                if (orderQuantity <= availableQuantity)
                                {
                                    OrderCarParts(partId, orderQuantity);
                                    availableQuantity -= orderQuantity; // Decrease available quantity
                                    lblQuantity.Text = "Available : " + availableQuantity.ToString(); // Update displayed Quantity
                                }
                                else
                                {
                                    MessageBox.Show("Not enough stock available.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid quantity.");
                            }
                        };

                        carPartsPanel.Controls.Add(btnOrder);

                        CarParts_UserPanel.Controls.Add(carPartsPanel);

                        yPos += 130;
                    }

                    reader.Close();
                }
            }
            else
            {
                LoadCarDetails(); // If search text is empty, reload all car parts
            }
        }



        private void btn_CarParts_RefUser_Click(object sender, EventArgs e)
        {
            // Clear the search textbox (optional, if you want to reset the search field)
            textSearch_CarParts.Text = string.Empty;

            // Reload the full data into the DataGridView
            LoadCarDetails();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ABC_Car_Traders
{
    public partial class User_CarPage : Form
    {
        private List<Car> cars = new List<Car>();
        private UserOrderPage orderPage;

        public User_CarPage(UserOrderPage orderPage)
        {
            InitializeComponent();
            this.orderPage = orderPage;
            InitializePanel();
            LoadCarDetails();
        }

        private void InitializePanel()
        {
            Car_UserPanel.AutoScroll = true;
        }

        public class Car
        {
            public string Id { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public string VehicleImage { get; set; }
            public string Year { get; set; }
            public string Status { get; set; }
            public string Description { get; set; }
        }

        private void LoadCarDetails()
        {
            Car_UserPanel.Controls.Clear();
            cars.Clear();

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
            {
                string query = "SELECT ID AS [V ID], Brand AS [Brand], Model AS [Model], Year AS [Year], Price AS [Price], Status AS [Status (R or UnR)], " +
                               "Stokes AS [Stokes], Description AS [Description], VehicleImage AS [Vehicle Image] " +
                               "FROM VehicleDetails";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int yPos = 10;

                    while (reader.Read())
                    {
                        Car car = new Car
                        {
                            Id = reader["V ID"].ToString(),
                            Brand = reader["Brand"].ToString(),
                            Model = reader["Model"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Stock = Convert.ToInt32(reader["Stokes"]),
                            VehicleImage = reader["Vehicle Image"].ToString(),
                            Year = reader["Year"].ToString(),
                            Status = reader["Status (R or UnR)"].ToString(),
                            Description = reader["Description"].ToString(),
                        };
                        cars.Add(car);

                        Panel carPanel = new Panel
                        {
                            Width = Car_UserPanel.Width - 40,
                            Height = 120,
                            Top = yPos,
                            Left = 10,
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.FromArgb(155, Color.Black),
                            ForeColor = Color.White
                        };

                        PictureBox carImage = new PictureBox
                        {
                            Width = 150,
                            Height = 100,
                            Top = 10,
                            Left = 10,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                        };

                        try
                        {
                            byte[] imageBytes = (byte[])reader["Vehicle Image"];
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    carImage.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                carImage.Image = Properties.Resources.images;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to load image: {ex.Message}");
                            carImage.Image = Properties.Resources.images;
                        }

                        carPanel.Controls.Add(carImage);

                        Label lblCarName = new Label
                        {
                            Text = car.Brand,
                            Top = 10,
                            Left = 180,
                            Width = 200,
                            Font = new Font("Arial", 14, FontStyle.Bold),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblCarName);

                        Label lblModel = new Label
                        {
                            Text = car.Model,
                            Top = 40,
                            Left = 180,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblModel);

                        Label lblYear = new Label
                        {
                            Text = car.Year,
                            Top = 65,
                            Left = 180,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblYear);

                        Label lblDescription = new Label
                        {
                            Text = car.Description,
                            Top = 90,
                            Left = 180,
                            Width = 400,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblDescription);

                        Label lblStatus = new Label
                        {
                            Text = car.Status,
                            Top = 40,
                            Left = 400,
                            Width = 200,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblStatus);

                        Label lblPrice = new Label
                        {
                            Text = "RS. " + car.Price.ToString(),
                            Top = 70,
                            Left = 400,
                            Width = 200,
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblPrice);

                        // Stock Display
                        Label lblStock = new Label
                        {
                            Text = $"Available: {car.Stock}",
                            Top = 10,
                            Left = 720,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblStock);

                        Label lblQuantity = new Label
                        {
                            Text = "Qty: ",
                            Top = 40,
                            Left = 695,
                            Width = 30,
                            Font = new Font("Arial", 8),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblQuantity);

                        // Customer Quantity Input
                        TextBox txtOrderQuantity = new TextBox
                        {
                            Top = 40,
                            Left = 720,
                            Width = 50,
                            Font = new Font("Arial", 10),
                            Size = new Size(50, 22)
                        };
                        carPanel.Controls.Add(txtOrderQuantity);

                        // Order button
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
                            if (int.TryParse(txtOrderQuantity.Text, out orderQuantity) && orderQuantity > 0)
                            {
                                if (orderQuantity <= car.Stock)
                                {
                                    OrderCar(car.Id, orderQuantity);
                                    lblStock.Text = $"Available: {car.Stock}"; // Update displayed stock
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

                        carPanel.Controls.Add(btnOrder);

                        Car_UserPanel.Controls.Add(carPanel);

                        yPos += 130;
                    }
                }
            }
        }

        private void OrderCar(string carId, int quantity)
        {
            Car selectedCar = cars.Find(c => c.Id == carId);
            if (selectedCar != null)
            {
                selectedCar.Stock -= quantity;
                UpdateCarStockInDatabase(selectedCar.Id, selectedCar.Stock);

                if (orderPage == null)
                {
                    orderPage = new UserOrderPage();
                }

                orderPage.AddOrderItem(selectedCar, quantity);
                orderPage.BringToFront();
                LoadCarDetails(); // Refresh car details to show updated stock
            }
        }

        private void UpdateCarStockInDatabase(string carId, int newStock)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();
                string query = "UPDATE VehicleDetails SET Stokes = @Stokes WHERE ID = @CarId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Stokes", newStock);
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void btn_Car_Search_Click(object sender, EventArgs e)
        {
            string searchText = textSearch_CarUser.Text.Trim();  // Get the text from the search TextBox 

            Car_UserPanel.Controls.Clear(); // Clear existing controls

            if (!string.IsNullOrEmpty(searchText))
            {
                // SQL query to search for the entered text in various columns
                string query = "SELECT * FROM VehicleDetails WHERE Brand LIKE @SearchText OR Model LIKE @SearchText OR " +
                               "Year LIKE @SearchText OR Price LIKE @SearchText OR Status LIKE @SearchText OR Stokes LIKE @SearchText OR Description LIKE @SearchText";

                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JL1GD2G\\SQLEXPRESS;Initial Catalog=LoginPage;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    int yPos = 10;

                    while (reader.Read())
                    {
                        // Store necessary values from the reader before closing it
                        string carId = reader["ID"].ToString();
                        int availableStock = Convert.ToInt32(reader["Stokes"]);

                        Panel carPanel = new Panel
                        {
                            Width = Car_UserPanel.Width - 40, // Leave space for scrollbar
                            Height = 120,
                            Top = yPos,
                            Left = 10,
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.FromArgb(155, Color.Black),
                            ForeColor = Color.White
                        };

                        PictureBox carImage = new PictureBox
                        {
                            Width = 150,
                            Height = 100,
                            Top = 10,
                            Left = 10,
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };

                        try
                        {
                            byte[] imageBytes = (byte[])reader["VehicleImage"];
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    carImage.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                carImage.Image = Properties.Resources.images; // Default image if no data
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to load image: {ex.Message}");
                            carImage.Image = Properties.Resources.images; // Default image on error
                        }

                        carPanel.Controls.Add(carImage);

                        Label lblCarName = new Label
                        {
                            Text = reader["Brand"].ToString(),
                            Top = 10,
                            Left = 180,
                            Width = 200,
                            Font = new Font("Arial", 14, FontStyle.Bold),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblCarName);

                        Label lblModel = new Label
                        {
                            Text = reader["Model"].ToString(),
                            Top = 40,
                            Left = 180,
                            Width = 200,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblModel);

                        Label lblYear = new Label
                        {
                            Text = reader["Year"].ToString(),
                            Top = 65,
                            Left = 180,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblYear);

                        Label lblDescription = new Label
                        {
                            Text = reader["Description"].ToString(),
                            Top = 90,
                            Left = 180,
                            Width = 400,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblDescription);

                        Label lblStatus = new Label
                        {
                            Text = reader["Status"].ToString(),
                            Top = 40,
                            Left = 400,
                            Width = 200,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblStatus);

                        Label lblPrice = new Label
                        {
                            Text = "RS. " + reader["Price"].ToString(),
                            Top = 70,
                            Left = 400,
                            Width = 200,
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblPrice);

                        // Quantity label and text box
                        Label lblQuantity = new Label
                        {
                            Text = "Available : " + reader["Stokes"].ToString(),
                            Top = 10,
                            Left = 720,
                            Width = 100,
                            Font = new Font("Arial", 10),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblQuantity);

                        Label lblQty = new Label
                        {
                            Text = "Qty: ",
                            Top = 40,
                            Left = 695,
                            Width = 30,
                            Font = new Font("Arial", 8),
                            BackColor = Color.Transparent
                        };
                        carPanel.Controls.Add(lblQty);

                        TextBox txtOrderQuantity = new TextBox
                        {
                            Top = 40,
                            Left = 720,
                            Width = 41,
                            Font = new Font("Arial", 10),
                            Size = new Size(50, 22)
                        };
                        carPanel.Controls.Add(txtOrderQuantity);

                        // Order button
                        Button btnOrder = new Button
                        {
                            Text = "Order",
                            Top = 80,
                            Left = 720,
                            Width = 100,
                            Font = new Font("Arial", 10)
                        };

                        // Attach the event handler for the Order button
                        btnOrder.Tag = new { CarId = carId, AvailableStock = availableStock, QuantityTextBox = txtOrderQuantity };

                        btnOrder.Click += (s, eventArgs) =>
                        {
                            var button = (Button)s;
                            var data = (dynamic)button.Tag;

                            string id = data.CarId;
                            int stock = data.AvailableStock;
                            TextBox quantityTextBox = data.QuantityTextBox;  // This is now correctly referencing the TextBox

                            if (int.TryParse(quantityTextBox.Text, out int requestedQuantity) && stock >= requestedQuantity)
                            {
                                // Call your order method with the stored carId and requested quantity
                                OrderCar(id, requestedQuantity);
                            }
                            else
                            {
                                MessageBox.Show("Insufficient stock or invalid quantity.", "Order Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        };


                        carPanel.Controls.Add(btnOrder);
                        Car_UserPanel.Controls.Add(carPanel);

                        yPos += 130;

                    }
                }
            }
            else
            {
                // If the search text is empty, reload all the data
                LoadCarDetails();
            }
        }



        private void btn_Car_RefUser_Click_1(object sender, EventArgs e)
        {
            // Clear the search textbox (optional, if you want to reset the search field)
            textSearch_CarUser.Text = string.Empty;

            // Reload the full data into the DataGridView
            LoadCarDetails();
        }
    }
}

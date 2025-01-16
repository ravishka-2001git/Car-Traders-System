using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static ABC_Car_Traders.CarPartsPage_User;
using static ABC_Car_Traders.User_CarPage;

namespace ABC_Car_Traders
{
    public partial class UserOrderPage : Form
    {
        private string fullName;
        private List<OrderItem> orderItems;
        private decimal totalPrice;
        private Label lblTotalPrice;

        public UserOrderPage()
        {
            InitializeComponent();
            InitializePanel();
            InitializeTotalPriceLabel();
            InitializeClearOrderButton();
            this.fullName = fullName;
            SetFullName();

            // Load orders from the singleton OrderManager
            orderItems = OrderManager.Instance.OrderItems;
            totalPrice = OrderManager.Instance.TotalPrice;
            DisplayOrderItems();
        }
        private void SetFullName()
        {
            UserName_Label.Text = fullName;
        }

        private void UserOrderPage_Load(object sender, EventArgs e)
        {

        }
        private void InitializeClearOrderButton()
        {
            Button btnClearOrder = new Button
            {
                Text = "Clear Orders",
                Top = 510,
                Left = 80,
                Width = 100,
                Height = 30,
                Font = new Font("Arial", 9),
                ForeColor = Color.White,
                BackColor = Color.Black
            };
            btnClearOrder.Click += (s, e) => ResetOrder();
            Controls.Add(btnClearOrder);
        }

        private void InitializePanel()
        {
            userOrderPanel.AutoScroll = true;
            userOrderPanel.VerticalScroll.Visible = true;
            userOrderPanel.HorizontalScroll.Visible = false;
        }


        private void InitializeTotalPriceLabel()
        {
            lblTotalPrice = new Label
            {
                Text = "Total Price: RS. 0.00",
                Top = 520,
                Left = 550,
                Width = 300,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            Controls.Add(lblTotalPrice);
        }

        // Add order item from User_CarPage
        public void AddOrderItem(User_CarPage.Car car, int quantity)
        {
            OrderManager.Instance.AddOrderItem(car, quantity);
            UpdateOrderItemsAndDisplay();
        }

        // Add order item from CarPartsPage_User
        public void AddOrderItem(CarPartsPage_User.CarParts carParts, int quantity)
        {
            OrderManager.Instance.AddOrderItem(carParts, quantity);
            UpdateOrderItemsAndDisplay();
        }

        private void UpdateOrderItemsAndDisplay()
        {
            orderItems = OrderManager.Instance.OrderItems;
            totalPrice = OrderManager.Instance.TotalPrice;
            DisplayOrderItems();
            UpdateTotalPriceLabel(); // This ensures the latest total price is shown
        }

        public bool IsBase64String(string base64)
        {
            base64 = base64.Trim();
            if ((base64.Length % 4) != 0)
            {
                return false;
            }

            string pattern = @"^[a-zA-Z0-9\+/]*={0,2}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(base64, pattern))
            {
                return false;
            }

            try
            {
                Convert.FromBase64String(base64);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        private void DisplayOrderItems()
        {
            userOrderPanel.Controls.Clear();

            int yPos = 10;

            foreach (var orderItem in orderItems)
            {
                Panel orderPanel = new Panel
                {
                    Width = userOrderPanel.Width - 40,
                    Height = 120,
                    Top = yPos,
                    Left = 10,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(155, Color.Black),
                    ForeColor = Color.White
                };

                PictureBox itemImage = new PictureBox
                {
                    Width = 150,
                    Height = 100,
                    Top = 10,
                    Left = 10,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                try
                {
                    if (orderItem.Car != null && !string.IsNullOrEmpty(orderItem.Car.VehicleImage) && IsBase64String(orderItem.Car.VehicleImage))
                    {
                        byte[] imageBytes = Convert.FromBase64String(orderItem.Car.VehicleImage);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            itemImage.Image = Image.FromStream(ms);
                        }
                    }
                    else if (orderItem.CarParts != null && !string.IsNullOrEmpty(orderItem.CarParts.PartImage) && IsBase64String(orderItem.CarParts.PartImage))
                    {
                        byte[] imageBytes = Convert.FromBase64String(orderItem.CarParts.PartImage);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            itemImage.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Display default image if no valid image is found
                        itemImage.Image = Properties.Resources.orderPic;
                    }
                }
                catch (Exception ex)
                {
                    // Log the error details
                    MessageBox.Show($"Failed to load image: {ex.Message}");
                    itemImage.Image = Properties.Resources.orderPic; // Display default image on error
                }

                orderPanel.Controls.Add(itemImage);

                // Display item details
                Label lblItemName = new Label
                {
                    Text = orderItem.Car?.Brand ?? orderItem.CarParts?.PartName ?? "Unknown",
                    Top = 10,
                    Left = 180,
                    Width = 200,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    BackColor = Color.Transparent
                };
                orderPanel.Controls.Add(lblItemName);

                Label lblModelOrPart = new Label
                {
                    Text = orderItem.Car?.Model ?? orderItem.CarParts?.Category ?? "Unknown",
                    Top = 40,
                    Left = 180,
                    Width = 200,
                    Font = new Font("Arial", 10),
                    BackColor = Color.Transparent
                };
                orderPanel.Controls.Add(lblModelOrPart);

                Label lblYearOrManufacturer = new Label
                {
                    Text = orderItem.Car?.Year ?? orderItem.CarParts?.PartCode ?? "Unknown",
                    Top = 65,
                    Left = 180,
                    Width = 200,
                    Font = new Font("Arial", 10),
                    BackColor = Color.Transparent
                };
                orderPanel.Controls.Add(lblYearOrManufacturer);

                Label lblQuantity = new Label
                {
                    Text = "Quantity: " + orderItem.Quantity,
                    Top = 90,
                    Left = 180,
                    Width = 200,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    BackColor = Color.Transparent
                };
                orderPanel.Controls.Add(lblQuantity);

                Label lblPrice = new Label
                {
                    Text = "Price: RS. " + orderItem.Price.ToString("F2"),
                    Top = 70,
                    Left = 400,
                    Width = 200,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    BackColor = Color.Transparent
                };
                orderPanel.Controls.Add(lblPrice);

                Label lblTotalPrice = new Label
                {
                    Text = "Total: RS. " + orderItem.TotalPrice.ToString("F2"),
                    Top = 90,
                    Left = 400,
                    Width = 200,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    BackColor = Color.Transparent
                };
                orderPanel.Controls.Add(lblTotalPrice);

                // Remove order button
                Button btnRemoveOrder = new Button
                {
                    Text = "Remove",
                    Top = 80,
                    Left = 720,
                    Width = 100,
                    Font = new Font("Arial", 10)
                };

                btnRemoveOrder.Click += (s, eArgs) =>
                {
                    OrderManager.Instance.RemoveOrderItem(orderItem);
                    UpdateOrderItemsAndDisplay();
                };

                orderPanel.Controls.Add(btnRemoveOrder);

                userOrderPanel.Controls.Add(orderPanel);

                yPos += 130;
            }

            UpdateTotalPriceLabel();
        }

        private void UpdateTotalPriceLabel()
        {
            lblTotalPrice.Text = "Total Price: RS. " + totalPrice.ToString("F2");
        }

        private void ResetOrder()
        {
            OrderManager.Instance.ResetOrder();
            orderItems = OrderManager.Instance.OrderItems;
            totalPrice = OrderManager.Instance.TotalPrice;
            userOrderPanel.Controls.Clear();
            UpdateTotalPriceLabel();
        }

        public class OrderItem
        {
            public User_CarPage.Car Car { get; set; }
            public CarPartsPage_User.CarParts CarParts { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal TotalPrice => Quantity * Price;
        }

        private void btnBuyNow_Click(object sender, EventArgs e)
        {
            List<OrderItem> orders = orderItems;
            decimal totalPrice = this.totalPrice;

            Buynow buyNowForm = new Buynow(orders, totalPrice);
            buyNowForm.ShowDialog(); // or Show() if you don't want to block the current form
        }

        private void btn_Order_RefUser_Click(object sender, EventArgs e)
        {
            // Clear the search textbox (optional, if you want to reset the search field)
            textSearch_OrderUser.Text = string.Empty;

            // Reload the full data into the DataGridView
            DisplayOrderItems();
            InitializeTotalPriceLabel();

        }

        
    }

    public class OrderManager
    {
        private static OrderManager instance = null;
        public List<UserOrderPage.OrderItem> OrderItems { get; private set; }
        public decimal TotalPrice { get; private set; }

        private OrderManager()
        {
            OrderItems = new List<UserOrderPage.OrderItem>();
        }

        public static OrderManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderManager();
                }
                return instance;
            }
        }

        public void AddOrderItem(User_CarPage.Car car, int quantity)
        {
            var existingOrderItem = OrderItems.Find(item => item.Car?.Id == car.Id);

            if (existingOrderItem != null)
            {
                existingOrderItem.Quantity += quantity;
            }
            else
            {
                UserOrderPage.OrderItem orderItem = new UserOrderPage.OrderItem
                {
                    Car = car,
                    Quantity = quantity,
                    Price = car.Price
                };
                OrderItems.Add(orderItem);
            }

            TotalPrice += car.Price * quantity;
        }

        public void AddOrderItem(CarPartsPage_User.CarParts carParts, int quantity)
        {
            var existingOrderItem = OrderItems.Find(item => item.CarParts?.Id == carParts.Id);

            if (existingOrderItem != null)
            {
                existingOrderItem.Quantity += quantity;
            }
            else
            {
                UserOrderPage.OrderItem orderItem = new UserOrderPage.OrderItem
                {
                    CarParts = carParts,
                    Quantity = quantity,
                    Price = carParts.Price
                };
                OrderItems.Add(orderItem);
            }

            TotalPrice += carParts.Price * quantity;
        }

        public void RemoveOrderItem(UserOrderPage.OrderItem orderItem)
        {
            if (OrderItems.Contains(orderItem))
            {
                TotalPrice -= orderItem.TotalPrice;
                OrderItems.Remove(orderItem);
                // Ensure TotalPrice doesn't drop below 0
                if (TotalPrice < 0)
                {
                    TotalPrice = 0;
                }
            }
        }


        public void ResetOrder()
        {
            OrderItems.Clear();
            TotalPrice = 0;
        }
    }
}


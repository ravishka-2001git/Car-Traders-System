namespace ABC_Car_Traders
{
    partial class OrderPage_Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPage_Admin));
            this.textSearch_Orders = new System.Windows.Forms.TextBox();
            this.btn_Orders_Update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Order_DataGrid = new System.Windows.Forms.DataGridView();
            this.btn_Orders_Delete = new System.Windows.Forms.Button();
            this.btn_Orders_Refresh = new System.Windows.Forms.Button();
            this.btn_Orders_Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Order_DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // textSearch_Orders
            // 
            this.textSearch_Orders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch_Orders.Location = new System.Drawing.Point(951, 38);
            this.textSearch_Orders.Name = "textSearch_Orders";
            this.textSearch_Orders.Size = new System.Drawing.Size(225, 27);
            this.textSearch_Orders.TabIndex = 16;
            // 
            // btn_Orders_Update
            // 
            this.btn_Orders_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Orders_Update.BackColor = System.Drawing.Color.Transparent;
            this.btn_Orders_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Orders_Update.Location = new System.Drawing.Point(51, 590);
            this.btn_Orders_Update.Name = "btn_Orders_Update";
            this.btn_Orders_Update.Size = new System.Drawing.Size(108, 52);
            this.btn_Orders_Update.TabIndex = 14;
            this.btn_Orders_Update.Text = "Update";
            this.btn_Orders_Update.UseVisualStyleBackColor = false;
            this.btn_Orders_Update.Click += new System.EventHandler(this.btn_Orders_Update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 40);
            this.label1.TabIndex = 11;
            this.label1.Text = "Orders Page";
            // 
            // Order_DataGrid
            // 
            this.Order_DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Order_DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Order_DataGrid.BackgroundColor = System.Drawing.Color.Black;
            this.Order_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Order_DataGrid.GridColor = System.Drawing.Color.DarkGreen;
            this.Order_DataGrid.Location = new System.Drawing.Point(12, 73);
            this.Order_DataGrid.Name = "Order_DataGrid";
            this.Order_DataGrid.RowHeadersWidth = 51;
            this.Order_DataGrid.RowTemplate.Height = 24;
            this.Order_DataGrid.Size = new System.Drawing.Size(1298, 482);
            this.Order_DataGrid.TabIndex = 10;
            this.Order_DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Order_DataGrid_CellContentClick);
            // 
            // btn_Orders_Delete
            // 
            this.btn_Orders_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Orders_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_Orders_Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Orders_Delete.BackgroundImage")));
            this.btn_Orders_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Orders_Delete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Orders_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Orders_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Orders_Delete.ForeColor = System.Drawing.Color.Red;
            this.btn_Orders_Delete.Location = new System.Drawing.Point(204, 593);
            this.btn_Orders_Delete.Name = "btn_Orders_Delete";
            this.btn_Orders_Delete.Size = new System.Drawing.Size(56, 49);
            this.btn_Orders_Delete.TabIndex = 15;
            this.btn_Orders_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Orders_Delete.UseVisualStyleBackColor = false;
            this.btn_Orders_Delete.Click += new System.EventHandler(this.btn_Orders_Delete_Click);
            // 
            // btn_Orders_Refresh
            // 
            this.btn_Orders_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Orders_Refresh.BackColor = System.Drawing.Color.Transparent;
            this.btn_Orders_Refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Orders_Refresh.BackgroundImage")));
            this.btn_Orders_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Orders_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Orders_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Orders_Refresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Orders_Refresh.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_Orders_Refresh.Location = new System.Drawing.Point(1236, 27);
            this.btn_Orders_Refresh.Name = "btn_Orders_Refresh";
            this.btn_Orders_Refresh.Size = new System.Drawing.Size(48, 40);
            this.btn_Orders_Refresh.TabIndex = 13;
            this.btn_Orders_Refresh.UseVisualStyleBackColor = false;
            this.btn_Orders_Refresh.Click += new System.EventHandler(this.btn_Orders_Refresh_Click);
            // 
            // btn_Orders_Search
            // 
            this.btn_Orders_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Orders_Search.BackColor = System.Drawing.Color.Transparent;
            this.btn_Orders_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Orders_Search.BackgroundImage")));
            this.btn_Orders_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Orders_Search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Orders_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Orders_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Orders_Search.Location = new System.Drawing.Point(1182, 27);
            this.btn_Orders_Search.Name = "btn_Orders_Search";
            this.btn_Orders_Search.Size = new System.Drawing.Size(48, 40);
            this.btn_Orders_Search.TabIndex = 12;
            this.btn_Orders_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Orders_Search.UseVisualStyleBackColor = false;
            this.btn_Orders_Search.Click += new System.EventHandler(this.btn_Orders_Search_Click);
            // 
            // OrderPage_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImage = global::ABC_Car_Traders.Properties.Resources._360_F_571834789_ujYbUnH190iUokdDhZq7GXeTBRgqYVwa;
            this.ClientSize = new System.Drawing.Size(1322, 649);
            this.ControlBox = false;
            this.Controls.Add(this.textSearch_Orders);
            this.Controls.Add(this.btn_Orders_Delete);
            this.Controls.Add(this.btn_Orders_Update);
            this.Controls.Add(this.btn_Orders_Refresh);
            this.Controls.Add(this.btn_Orders_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Order_DataGrid);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OrderPage_Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OrderPage_Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Order_DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSearch_Orders;
        private System.Windows.Forms.Button btn_Orders_Delete;
        private System.Windows.Forms.Button btn_Orders_Update;
        private System.Windows.Forms.Button btn_Orders_Refresh;
        private System.Windows.Forms.Button btn_Orders_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Order_DataGrid;
    }
}
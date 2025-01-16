namespace ABC_Car_Traders
{
    partial class CarPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarPage));
            this.CarsDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textSearch_Car = new System.Windows.Forms.TextBox();
            this.btn_Car_Search = new System.Windows.Forms.Button();
            this.btn_Car_Delete = new System.Windows.Forms.Button();
            this.btn_Car_Update = new System.Windows.Forms.Button();
            this.btn_Car_Refresh = new System.Windows.Forms.Button();
            this.btn_Car_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CarsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CarsDataGrid
            // 
            this.CarsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CarsDataGrid.BackgroundColor = System.Drawing.Color.Black;
            this.CarsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarsDataGrid.Location = new System.Drawing.Point(12, 73);
            this.CarsDataGrid.Name = "CarsDataGrid";
            this.CarsDataGrid.RowHeadersWidth = 51;
            this.CarsDataGrid.RowTemplate.Height = 24;
            this.CarsDataGrid.Size = new System.Drawing.Size(1298, 467);
            this.CarsDataGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Car Page";
            // 
            // textSearch_Car
            // 
            this.textSearch_Car.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch_Car.Location = new System.Drawing.Point(951, 38);
            this.textSearch_Car.Name = "textSearch_Car";
            this.textSearch_Car.Size = new System.Drawing.Size(225, 27);
            this.textSearch_Car.TabIndex = 11;
            this.textSearch_Car.TextChanged += new System.EventHandler(this.textSearch_Car_TextChanged);
            // 
            // btn_Car_Search
            // 
            this.btn_Car_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Car_Search.BackColor = System.Drawing.Color.Transparent;
            this.btn_Car_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Car_Search.BackgroundImage")));
            this.btn_Car_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Car_Search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Car_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Car_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Car_Search.Location = new System.Drawing.Point(1182, 27);
            this.btn_Car_Search.Name = "btn_Car_Search";
            this.btn_Car_Search.Size = new System.Drawing.Size(48, 40);
            this.btn_Car_Search.TabIndex = 10;
            this.btn_Car_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Car_Search.UseVisualStyleBackColor = false;
            this.btn_Car_Search.Click += new System.EventHandler(this.btn_Car_Search_Click);
            // 
            // btn_Car_Delete
            // 
            this.btn_Car_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Car_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_Car_Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Car_Delete.BackgroundImage")));
            this.btn_Car_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Car_Delete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Car_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Car_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Car_Delete.ForeColor = System.Drawing.Color.Red;
            this.btn_Car_Delete.Location = new System.Drawing.Point(312, 560);
            this.btn_Car_Delete.Name = "btn_Car_Delete";
            this.btn_Car_Delete.Size = new System.Drawing.Size(56, 49);
            this.btn_Car_Delete.TabIndex = 14;
            this.btn_Car_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Car_Delete.UseVisualStyleBackColor = false;
            this.btn_Car_Delete.Click += new System.EventHandler(this.btn_Car_Delete_Click);
            // 
            // btn_Car_Update
            // 
            this.btn_Car_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Car_Update.BackColor = System.Drawing.Color.Transparent;
            this.btn_Car_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Car_Update.Location = new System.Drawing.Point(169, 557);
            this.btn_Car_Update.Name = "btn_Car_Update";
            this.btn_Car_Update.Size = new System.Drawing.Size(108, 52);
            this.btn_Car_Update.TabIndex = 13;
            this.btn_Car_Update.Text = "Update";
            this.btn_Car_Update.UseVisualStyleBackColor = false;
            this.btn_Car_Update.Click += new System.EventHandler(this.btn_Car_Update_Click);
            // 
            // btn_Car_Refresh
            // 
            this.btn_Car_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Car_Refresh.BackColor = System.Drawing.Color.Transparent;
            this.btn_Car_Refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Car_Refresh.BackgroundImage")));
            this.btn_Car_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Car_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Car_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Car_Refresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Car_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Car_Refresh.Location = new System.Drawing.Point(1236, 27);
            this.btn_Car_Refresh.Name = "btn_Car_Refresh";
            this.btn_Car_Refresh.Size = new System.Drawing.Size(49, 40);
            this.btn_Car_Refresh.TabIndex = 12;
            this.btn_Car_Refresh.UseVisualStyleBackColor = false;
            this.btn_Car_Refresh.Click += new System.EventHandler(this.btn_Car_Refresh_Click);
            // 
            // btn_Car_Add
            // 
            this.btn_Car_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Car_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_Car_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Car_Add.Location = new System.Drawing.Point(31, 557);
            this.btn_Car_Add.Name = "btn_Car_Add";
            this.btn_Car_Add.Size = new System.Drawing.Size(108, 52);
            this.btn_Car_Add.TabIndex = 15;
            this.btn_Car_Add.Text = "Add New";
            this.btn_Car_Add.UseVisualStyleBackColor = false;
            this.btn_Car_Add.Click += new System.EventHandler(this.btn_Car_Add_Click);
            // 
            // CarPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::ABC_Car_Traders.Properties.Resources._360_F_571834789_ujYbUnH190iUokdDhZq7GXeTBRgqYVwa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1322, 649);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Car_Add);
            this.Controls.Add(this.btn_Car_Delete);
            this.Controls.Add(this.btn_Car_Update);
            this.Controls.Add(this.btn_Car_Refresh);
            this.Controls.Add(this.textSearch_Car);
            this.Controls.Add(this.btn_Car_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CarsDataGrid);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CarPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CarPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CarsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CarsDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSearch_Car;
        private System.Windows.Forms.Button btn_Car_Search;
        private System.Windows.Forms.Button btn_Car_Delete;
        private System.Windows.Forms.Button btn_Car_Update;
        private System.Windows.Forms.Button btn_Car_Refresh;
        private System.Windows.Forms.Button btn_Car_Add;
    }
}
namespace ABC_Car_Traders
{
    partial class from1
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
            this.components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(from1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Myprogress = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(guna2CirclePictureBox1)).BeginInit();
            this.Myprogress.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new System.Drawing.Point(6, 3);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new System.Drawing.Size(298, 260);
            guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            guna2CirclePictureBox1.TabIndex = 0;
            guna2CirclePictureBox1.TabStop = false;
            guna2CirclePictureBox1.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // Myprogress
            // 
            this.Myprogress.BackColor = System.Drawing.Color.Transparent;
            this.Myprogress.Controls.Add(guna2CirclePictureBox1);
            this.Myprogress.FillColor = System.Drawing.Color.Black;
            this.Myprogress.FillThickness = 10;
            this.Myprogress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Myprogress.ForeColor = System.Drawing.Color.White;
            this.Myprogress.Location = new System.Drawing.Point(38, 26);
            this.Myprogress.Minimum = 0;
            this.Myprogress.Name = "Myprogress";
            this.Myprogress.ProgressColor = System.Drawing.Color.Black;
            this.Myprogress.ProgressColor2 = System.Drawing.Color.White;
            this.Myprogress.ProgressThickness = 8;
            this.Myprogress.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Myprogress.Size = new System.Drawing.Size(304, 304);
            this.Myprogress.TabIndex = 1;
            this.Myprogress.Text = "guna2CircleProgressBar1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Castellar", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(430, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "ABC Car Traders ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // from1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(943, 511);
            this.Controls.Add(this.Myprogress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "from1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(guna2CirclePictureBox1)).EndInit();
            this.Myprogress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar Myprogress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}


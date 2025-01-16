namespace ABC_Car_Traders
{
    partial class Loginpage
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
            Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loginpage));
            this.btnSingup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUName = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_Login = new System.Windows.Forms.CheckBox();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Back)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new System.Drawing.Point(405, -107);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new System.Drawing.Size(503, 392);
            guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            guna2CirclePictureBox1.TabIndex = 61;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // btnSingup
            // 
            this.btnSingup.BackColor = System.Drawing.Color.Transparent;
            this.btnSingup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSingup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSingup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSingup.Location = new System.Drawing.Point(1118, 38);
            this.btnSingup.Name = "btnSingup";
            this.btnSingup.Size = new System.Drawing.Size(135, 50);
            this.btnSingup.TabIndex = 53;
            this.btnSingup.Text = "Sign up";
            this.btnSingup.UseVisualStyleBackColor = false;
            this.btnSingup.Click += new System.EventHandler(this.btnSingup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(415, 538);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 32);
            this.label2.TabIndex = 57;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(415, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 32);
            this.label1.TabIndex = 56;
            this.label1.Text = "User Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(598, 541);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(244, 30);
            this.txtPassword.TabIndex = 55;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUName
            // 
            this.txtUName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUName.Location = new System.Drawing.Point(598, 476);
            this.txtUName.Name = "txtUName";
            this.txtUName.Size = new System.Drawing.Size(244, 30);
            this.txtUName.TabIndex = 54;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DimGray;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Lavender;
            this.btnLogin.Location = new System.Drawing.Point(598, 670);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(132, 45);
            this.btnLogin.TabIndex = 59;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.Transparent;
            this.btn_Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_Back.Image")));
            this.btn_Back.Location = new System.Drawing.Point(21, 28);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(122, 60);
            this.btn_Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Back.TabIndex = 60;
            this.btn_Back.TabStop = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe Script", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(528, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 95);
            this.label4.TabIndex = 62;
            this.label4.Text = "Login...";
            // 
            // checkBox_Login
            // 
            this.checkBox_Login.AutoSize = true;
            this.checkBox_Login.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Login.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox_Login.Location = new System.Drawing.Point(865, 550);
            this.checkBox_Login.Name = "checkBox_Login";
            this.checkBox_Login.Size = new System.Drawing.Size(62, 20);
            this.checkBox_Login.TabIndex = 63;
            this.checkBox_Login.Text = "Show";
            this.checkBox_Login.UseVisualStyleBackColor = false;
            this.checkBox_Login.CheckedChanged += new System.EventHandler(this.checkBox_Login_CheckedChanged);
            // 
            // Loginpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1300, 850);
            this.Controls.Add(this.checkBox_Login);
            this.Controls.Add(this.label4);
            this.Controls.Add(guna2CirclePictureBox1);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUName);
            this.Controls.Add(this.btnSingup);
            this.Name = "Loginpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login_Page";
            ((System.ComponentModel.ISupportInitialize)(guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSingup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox btn_Back;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_Login;
    }
}
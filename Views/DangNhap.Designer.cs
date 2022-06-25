
namespace QuanLyNhaTro.Views
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.button1 = new System.Windows.Forms.Button();
            this.pnDangnhap = new System.Windows.Forms.Panel();
            this.lblanpass = new System.Windows.Forms.Label();
            this.txtPassword = new ZBobb.AlphaBlendTextBox();
            this.txtUsername = new ZBobb.AlphaBlendTextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblhienpass = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnDangnhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1965, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 58);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnDangnhap
            // 
            this.pnDangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnDangnhap.Controls.Add(this.lblanpass);
            this.pnDangnhap.Controls.Add(this.txtPassword);
            this.pnDangnhap.Controls.Add(this.txtUsername);
            this.pnDangnhap.Controls.Add(this.btnLogin);
            this.pnDangnhap.Controls.Add(this.lblhienpass);
            this.pnDangnhap.Controls.Add(this.label4);
            this.pnDangnhap.Controls.Add(this.label3);
            this.pnDangnhap.Controls.Add(this.label2);
            this.pnDangnhap.Font = new System.Drawing.Font("Source Sans Pro", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnDangnhap.Location = new System.Drawing.Point(653, 199);
            this.pnDangnhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnDangnhap.Name = "pnDangnhap";
            this.pnDangnhap.Size = new System.Drawing.Size(752, 639);
            this.pnDangnhap.TabIndex = 0;
            // 
            // lblanpass
            // 
            this.lblanpass.BackColor = System.Drawing.Color.Transparent;
            this.lblanpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblanpass.Font = new System.Drawing.Font("Source Sans Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblanpass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblanpass.Image = ((System.Drawing.Image)(resources.GetObject("lblanpass.Image")));
            this.lblanpass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblanpass.Location = new System.Drawing.Point(509, 315);
            this.lblanpass.Name = "lblanpass";
            this.lblanpass.Size = new System.Drawing.Size(91, 34);
            this.lblanpass.TabIndex = 23;
            this.lblanpass.Text = "Hide";
            this.lblanpass.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblanpass.Visible = false;
            this.lblanpass.Click += new System.EventHandler(this.lblanpass_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackAlpha = 1;
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.Location = new System.Drawing.Point(122, 357);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(488, 45);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.BackAlpha = 1;
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtUsername.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtUsername.Location = new System.Drawing.Point(122, 233);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(488, 45);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(123)))), ((int)(((byte)(53)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Source Sans Pro", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Location = new System.Drawing.Point(122, 487);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(488, 63);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblhienpass
            // 
            this.lblhienpass.BackColor = System.Drawing.Color.Transparent;
            this.lblhienpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblhienpass.Font = new System.Drawing.Font("Source Sans Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhienpass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblhienpass.Image = ((System.Drawing.Image)(resources.GetObject("lblhienpass.Image")));
            this.lblhienpass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblhienpass.Location = new System.Drawing.Point(509, 315);
            this.lblhienpass.Name = "lblhienpass";
            this.lblhienpass.Size = new System.Drawing.Size(101, 34);
            this.lblhienpass.TabIndex = 20;
            this.lblhienpass.Text = "Show";
            this.lblhienpass.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblhienpass.UseMnemonic = false;
            this.lblhienpass.Click += new System.EventHandler(this.lblhienpass_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Source Sans Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(115, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 41);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Source Sans Pro", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(114, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 41);
            this.label3.TabIndex = 1;
            this.label3.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Source Sans Pro", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(272, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 88);
            this.label2.TabIndex = 0;
            this.label2.Text = "Login";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1942, 1000);
            this.Controls.Add(this.pnDangnhap);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DangNhap";
            this.Text = "ss";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnDangnhap.ResumeLayout(false);
            this.pnDangnhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnDangnhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblhienpass;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnLogin;
        private ZBobb.AlphaBlendTextBox txtPassword;
        private ZBobb.AlphaBlendTextBox txtUsername;
        private System.Windows.Forms.Label lblanpass;
    }
}
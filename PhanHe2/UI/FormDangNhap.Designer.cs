namespace PhanHe2
{
    partial class FormDangNhap
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
            this.label_title = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Bahnschrift", 19.8F, System.Drawing.FontStyle.Bold);
            this.label_title.Location = new System.Drawing.Point(128, 85);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(512, 40);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "Hệ Thống Quản Lý Dữ Liệu Nội Bộ";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Bold);
            this.label_username.Location = new System.Drawing.Point(235, 182);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(117, 21);
            this.label_username.TabIndex = 1;
            this.label_username.Text = "Tên đăng nhập";
            // 
            // txt_username
            // 
            this.txt_username.Font = new System.Drawing.Font("Bahnschrift", 13.8F);
            this.txt_username.Location = new System.Drawing.Point(239, 206);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(300, 35);
            this.txt_username.TabIndex = 2;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Bold);
            this.label_password.Location = new System.Drawing.Point(235, 271);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(79, 21);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "Mật khẩu";
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Bahnschrift", 13.8F);
            this.txt_password.Location = new System.Drawing.Point(235, 295);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(300, 35);
            this.txt_password.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(309, 370);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(152, 41);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FormDangNhap
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.label_title);
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Màn hình đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btnLogin;
    }
}


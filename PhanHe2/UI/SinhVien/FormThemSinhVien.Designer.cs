namespace PhanHe2.UI.SinhVien
{
    partial class FormThemSinhVien
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
            this.txtBoxHoTen = new System.Windows.Forms.TextBox();
            this.labelMaNV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxPhai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxDiaChi = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dateNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtBoxSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNgaySinh = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxMaCT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxMaNganh = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBoxHoTen
            // 
            this.txtBoxHoTen.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxHoTen.Location = new System.Drawing.Point(28, 52);
            this.txtBoxHoTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxHoTen.Name = "txtBoxHoTen";
            this.txtBoxHoTen.Size = new System.Drawing.Size(202, 28);
            this.txtBoxHoTen.TabIndex = 4;
            // 
            // labelMaNV
            // 
            this.labelMaNV.AutoSize = true;
            this.labelMaNV.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.labelMaNV.Location = new System.Drawing.Point(24, 27);
            this.labelMaNV.Name = "labelMaNV";
            this.labelMaNV.Size = new System.Drawing.Size(83, 21);
            this.labelMaNV.TabIndex = 3;
            this.labelMaNV.Text = "Họ và tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label1.Location = new System.Drawing.Point(24, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Phái";
            // 
            // txtBoxPhai
            // 
            this.txtBoxPhai.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxPhai.Location = new System.Drawing.Point(28, 122);
            this.txtBoxPhai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxPhai.Name = "txtBoxPhai";
            this.txtBoxPhai.Size = new System.Drawing.Size(202, 28);
            this.txtBoxPhai.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label2.Location = new System.Drawing.Point(24, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Địa chỉ";
            // 
            // txtBoxDiaChi
            // 
            this.txtBoxDiaChi.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxDiaChi.Location = new System.Drawing.Point(28, 200);
            this.txtBoxDiaChi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxDiaChi.Name = "txtBoxDiaChi";
            this.txtBoxDiaChi.Size = new System.Drawing.Size(202, 28);
            this.txtBoxDiaChi.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.btnOk.Location = new System.Drawing.Point(311, 400);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 39);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.btnCancel.Location = new System.Drawing.Point(184, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dateNgaySinh
            // 
            this.dateNgaySinh.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.dateNgaySinh.Location = new System.Drawing.Point(28, 285);
            this.dateNgaySinh.MaxDate = new System.DateTime(2015, 12, 31, 0, 0, 0, 0);
            this.dateNgaySinh.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateNgaySinh.Name = "dateNgaySinh";
            this.dateNgaySinh.Size = new System.Drawing.Size(200, 28);
            this.dateNgaySinh.TabIndex = 27;
            this.dateNgaySinh.Value = new System.DateTime(2015, 12, 31, 0, 0, 0, 0);
            // 
            // txtBoxSDT
            // 
            this.txtBoxSDT.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxSDT.Location = new System.Drawing.Point(311, 52);
            this.txtBoxSDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxSDT.Name = "txtBoxSDT";
            this.txtBoxSDT.Size = new System.Drawing.Size(202, 28);
            this.txtBoxSDT.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label3.Location = new System.Drawing.Point(307, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "Số điện thoại";
            // 
            // labelNgaySinh
            // 
            this.labelNgaySinh.AutoSize = true;
            this.labelNgaySinh.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.labelNgaySinh.Location = new System.Drawing.Point(24, 255);
            this.labelNgaySinh.Name = "labelNgaySinh";
            this.labelNgaySinh.Size = new System.Drawing.Size(84, 21);
            this.labelNgaySinh.TabIndex = 24;
            this.labelNgaySinh.Text = "Ngày sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label4.Location = new System.Drawing.Point(307, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 21);
            this.label4.TabIndex = 25;
            this.label4.Text = "Mã chương trình";
            // 
            // txtBoxMaCT
            // 
            this.txtBoxMaCT.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxMaCT.Location = new System.Drawing.Point(311, 122);
            this.txtBoxMaCT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxMaCT.Name = "txtBoxMaCT";
            this.txtBoxMaCT.Size = new System.Drawing.Size(202, 28);
            this.txtBoxMaCT.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label5.Location = new System.Drawing.Point(307, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Mã ngành";
            // 
            // txtBoxMaNganh
            // 
            this.txtBoxMaNganh.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxMaNganh.Location = new System.Drawing.Point(311, 200);
            this.txtBoxMaNganh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxMaNganh.Name = "txtBoxMaNganh";
            this.txtBoxMaNganh.Size = new System.Drawing.Size(202, 28);
            this.txtBoxMaNganh.TabIndex = 26;
            // 
            // FormThemSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 462);
            this.Controls.Add(this.dateNgaySinh);
            this.Controls.Add(this.txtBoxMaNganh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxMaCT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxSDT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelNgaySinh);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtBoxDiaChi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxPhai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxHoTen);
            this.Controls.Add(this.labelMaNV);
            this.Name = "FormThemSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxHoTen;
        private System.Windows.Forms.Label labelMaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxPhai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxDiaChi;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dateNgaySinh;
        private System.Windows.Forms.TextBox txtBoxSDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNgaySinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxMaCT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxMaNganh;
    }
}
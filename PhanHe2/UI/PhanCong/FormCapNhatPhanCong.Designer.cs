namespace PhanHe2.UI.PhanCong
{
    partial class FormCapNhatPhanCong
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.numHK = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxMaGV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxMaCT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxMaHP = new System.Windows.Forms.TextBox();
            this.labelMaNV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHK)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.btnOk.Location = new System.Drawing.Point(283, 277);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 39);
            this.btnOk.TabIndex = 47;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.btnCancel.Location = new System.Drawing.Point(156, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 39);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numNam
            // 
            this.numNam.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.numNam.Location = new System.Drawing.Point(294, 152);
            this.numNam.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numNam.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numNam.Name = "numNam";
            this.numNam.ReadOnly = true;
            this.numNam.Size = new System.Drawing.Size(187, 28);
            this.numNam.TabIndex = 44;
            this.numNam.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // numHK
            // 
            this.numHK.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.numHK.Location = new System.Drawing.Point(294, 81);
            this.numHK.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numHK.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHK.Name = "numHK";
            this.numHK.ReadOnly = true;
            this.numHK.Size = new System.Drawing.Size(187, 28);
            this.numHK.TabIndex = 45;
            this.numHK.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label3.Location = new System.Drawing.Point(290, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label2.Location = new System.Drawing.Point(290, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 37;
            this.label2.Text = "Học kì";
            // 
            // txtBoxMaGV
            // 
            this.txtBoxMaGV.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxMaGV.Location = new System.Drawing.Point(45, 226);
            this.txtBoxMaGV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxMaGV.Name = "txtBoxMaGV";
            this.txtBoxMaGV.ReadOnly = true;
            this.txtBoxMaGV.Size = new System.Drawing.Size(202, 28);
            this.txtBoxMaGV.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label4.Location = new System.Drawing.Point(41, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 21);
            this.label4.TabIndex = 38;
            this.label4.Text = "Mã giảng viên";
            // 
            // txtBoxMaCT
            // 
            this.txtBoxMaCT.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxMaCT.Location = new System.Drawing.Point(45, 153);
            this.txtBoxMaCT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxMaCT.Name = "txtBoxMaCT";
            this.txtBoxMaCT.ReadOnly = true;
            this.txtBoxMaCT.Size = new System.Drawing.Size(202, 28);
            this.txtBoxMaCT.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label1.Location = new System.Drawing.Point(41, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 39;
            this.label1.Text = "Mã chương trình";
            // 
            // txtBoxMaHP
            // 
            this.txtBoxMaHP.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxMaHP.Location = new System.Drawing.Point(45, 81);
            this.txtBoxMaHP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxMaHP.Name = "txtBoxMaHP";
            this.txtBoxMaHP.ReadOnly = true;
            this.txtBoxMaHP.Size = new System.Drawing.Size(202, 28);
            this.txtBoxMaHP.TabIndex = 43;
            // 
            // labelMaNV
            // 
            this.labelMaNV.AutoSize = true;
            this.labelMaNV.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.labelMaNV.Location = new System.Drawing.Point(41, 56);
            this.labelMaNV.Name = "labelMaNV";
            this.labelMaNV.Size = new System.Drawing.Size(104, 21);
            this.labelMaNV.TabIndex = 40;
            this.labelMaNV.Text = "Mã học phần";
            // 
            // FormCapNhatPhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 372);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numNam);
            this.Controls.Add(this.numHK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxMaGV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxMaCT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxMaHP);
            this.Controls.Add(this.labelMaNV);
            this.Name = "FormCapNhatPhanCong";
            this.Text = "FormCapNhatPhanCong";
            this.Load += new System.EventHandler(this.FormCapNhatPhanCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.NumericUpDown numHK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxMaGV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxMaCT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxMaHP;
        private System.Windows.Forms.Label labelMaNV;
    }
}
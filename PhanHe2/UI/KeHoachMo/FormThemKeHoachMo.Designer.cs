namespace PhanHe2.UI.KeHoachMo
{
    partial class FormThemKeHoachMo
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
            this.btnOk.Location = new System.Drawing.Point(272, 221);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 39);
            this.btnOk.TabIndex = 25;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.btnCancel.Location = new System.Drawing.Point(145, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 39);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numNam
            // 
            this.numNam.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.numNam.Location = new System.Drawing.Point(283, 145);
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
            this.numNam.Size = new System.Drawing.Size(187, 28);
            this.numNam.TabIndex = 22;
            this.numNam.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // numHK
            // 
            this.numHK.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.numHK.Location = new System.Drawing.Point(283, 74);
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
            this.numHK.Size = new System.Drawing.Size(187, 28);
            this.numHK.TabIndex = 23;
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
            this.label3.Location = new System.Drawing.Point(279, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label2.Location = new System.Drawing.Point(279, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Học kì";
            // 
            // txtBoxMaCT
            // 
            this.txtBoxMaCT.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxMaCT.Location = new System.Drawing.Point(34, 146);
            this.txtBoxMaCT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxMaCT.Name = "txtBoxMaCT";
            this.txtBoxMaCT.Size = new System.Drawing.Size(202, 28);
            this.txtBoxMaCT.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label1.Location = new System.Drawing.Point(30, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã chương trình";
            // 
            // txtBoxMaHP
            // 
            this.txtBoxMaHP.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxMaHP.Location = new System.Drawing.Point(34, 74);
            this.txtBoxMaHP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxMaHP.Name = "txtBoxMaHP";
            this.txtBoxMaHP.Size = new System.Drawing.Size(202, 28);
            this.txtBoxMaHP.TabIndex = 21;
            // 
            // labelMaNV
            // 
            this.labelMaNV.AutoSize = true;
            this.labelMaNV.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.labelMaNV.Location = new System.Drawing.Point(30, 49);
            this.labelMaNV.Name = "labelMaNV";
            this.labelMaNV.Size = new System.Drawing.Size(104, 21);
            this.labelMaNV.TabIndex = 19;
            this.labelMaNV.Text = "Mã học phần";
            // 
            // FormThemKeHoachMo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 291);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numNam);
            this.Controls.Add(this.numHK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxMaCT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxMaHP);
            this.Controls.Add(this.labelMaNV);
            this.Name = "FormThemKeHoachMo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Kế hoạch mở";
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
        private System.Windows.Forms.TextBox txtBoxMaCT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxMaHP;
        private System.Windows.Forms.Label labelMaNV;
    }
}
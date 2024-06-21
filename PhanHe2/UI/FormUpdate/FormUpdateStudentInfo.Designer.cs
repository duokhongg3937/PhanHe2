namespace PhanHe2.UI.FormUpdate
{
    partial class FormUpdateStudentInfo
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
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.diaChi_TextBox = new System.Windows.Forms.TextBox();
            this.sdt_TextBox = new System.Windows.Forms.TextBox();
            this.updateInfo_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Địa chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "SĐT";
            // 
            // diaChi_TextBox
            // 
            this.diaChi_TextBox.Location = new System.Drawing.Point(92, 97);
            this.diaChi_TextBox.Multiline = true;
            this.diaChi_TextBox.Name = "diaChi_TextBox";
            this.diaChi_TextBox.Size = new System.Drawing.Size(327, 22);
            this.diaChi_TextBox.TabIndex = 28;
            // 
            // sdt_TextBox
            // 
            this.sdt_TextBox.Location = new System.Drawing.Point(92, 41);
            this.sdt_TextBox.Name = "sdt_TextBox";
            this.sdt_TextBox.Size = new System.Drawing.Size(168, 20);
            this.sdt_TextBox.TabIndex = 29;
            // 
            // updateInfo_Btn
            // 
            this.updateInfo_Btn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.updateInfo_Btn.Location = new System.Drawing.Point(294, 207);
            this.updateInfo_Btn.Name = "updateInfo_Btn";
            this.updateInfo_Btn.Size = new System.Drawing.Size(125, 35);
            this.updateInfo_Btn.TabIndex = 34;
            this.updateInfo_Btn.Text = "Cập nhật";
            this.updateInfo_Btn.UseVisualStyleBackColor = false;
            this.updateInfo_Btn.Click += new System.EventHandler(this.updateInfo_Btn_Click);
            // 
            // FormUpdateStudentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 254);
            this.Controls.Add(this.updateInfo_Btn);
            this.Controls.Add(this.sdt_TextBox);
            this.Controls.Add(this.diaChi_TextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Name = "FormUpdateStudentInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật thông tin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox diaChi_TextBox;
        private System.Windows.Forms.TextBox sdt_TextBox;
        private System.Windows.Forms.Button updateInfo_Btn;
    }
}
namespace PhanHe2.UI.DonVi
{
    partial class FormThemDonVi
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
            this.txtBoxTenDV = new System.Windows.Forms.TextBox();
            this.labelMaNV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxTRGDV = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxTenDV
            // 
            this.txtBoxTenDV.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxTenDV.Location = new System.Drawing.Point(46, 66);
            this.txtBoxTenDV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxTenDV.Name = "txtBoxTenDV";
            this.txtBoxTenDV.ReadOnly = true;
            this.txtBoxTenDV.Size = new System.Drawing.Size(202, 28);
            this.txtBoxTenDV.TabIndex = 4;
            // 
            // labelMaNV
            // 
            this.labelMaNV.AutoSize = true;
            this.labelMaNV.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.labelMaNV.Location = new System.Drawing.Point(42, 41);
            this.labelMaNV.Name = "labelMaNV";
            this.labelMaNV.Size = new System.Drawing.Size(85, 21);
            this.labelMaNV.TabIndex = 3;
            this.labelMaNV.Text = "Tên đơn vị";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.label1.Location = new System.Drawing.Point(42, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã trưởng đơn vị";
            // 
            // txtBoxTRGDV
            // 
            this.txtBoxTRGDV.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtBoxTRGDV.Location = new System.Drawing.Point(46, 155);
            this.txtBoxTRGDV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxTRGDV.Name = "txtBoxTRGDV";
            this.txtBoxTRGDV.ReadOnly = true;
            this.txtBoxTRGDV.Size = new System.Drawing.Size(202, 28);
            this.txtBoxTRGDV.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.btnOk.Location = new System.Drawing.Point(173, 220);
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
            this.btnCancel.Location = new System.Drawing.Point(46, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormThemDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 314);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtBoxTRGDV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxTenDV);
            this.Controls.Add(this.labelMaNV);
            this.Name = "FormThemDonVi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm đơn vị";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxTenDV;
        private System.Windows.Forms.Label labelMaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxTRGDV;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
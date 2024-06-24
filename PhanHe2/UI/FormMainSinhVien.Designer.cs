﻿namespace PhanHe2.UI
{
    partial class FormMainSinhVien
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
            this.formMainSVTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.updateInfo_Btn = new System.Windows.Forms.Button();
            this.dtbtl_TextBox = new System.Windows.Forms.TextBox();
            this.stctl_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maNganh_TextBox = new System.Windows.Forms.TextBox();
            this.maCT_TextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SDT_TextBox = new System.Windows.Forms.TextBox();
            this.ngaySinh_TextBox = new System.Windows.Forms.TextBox();
            this.diaChi_TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gioiTinh_TextBox = new System.Windows.Forms.TextBox();
            this.hoTen_TextBox = new System.Windows.Forms.TextBox();
            this.maSV_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maSV_label = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.resultLookup_dataGridView = new System.Windows.Forms.DataGridView();
            this.lookUp_Btn = new System.Windows.Forms.Button();
            this.semester_ComboBox = new System.Windows.Forms.ComboBox();
            this.year_ComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.KHMO_dataGridView = new System.Windows.Forms.DataGridView();
            this.lookupKHMO_Btn = new System.Windows.Forms.Button();
            this.semesterKHMO_ComboBox = new System.Windows.Forms.ComboBox();
            this.yearKHM_ComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DKHP_heading2_label = new System.Windows.Forms.Label();
            this.courseRegister2_dataGridView = new System.Windows.Forms.DataGridView();
            this.unRegister_Btn = new System.Windows.Forms.Button();
            this.courseRegister_Btn = new System.Windows.Forms.Button();
            this.DKHP_heading1_label = new System.Windows.Forms.Label();
            this.courseRegister1_dataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.resultCourseRegister_dataGridView = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.oracleCommandBuilder1 = new Oracle.ManagedDataAccess.Client.OracleCommandBuilder();
            this.button1 = new System.Windows.Forms.Button();
            this.formMainSVTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultLookup_dataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KHMO_dataGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseRegister2_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseRegister1_dataGridView)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultCourseRegister_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // formMainSVTabControl
            // 
            this.formMainSVTabControl.Controls.Add(this.tabPage1);
            this.formMainSVTabControl.Controls.Add(this.tabPage2);
            this.formMainSVTabControl.Controls.Add(this.tabPage3);
            this.formMainSVTabControl.Controls.Add(this.tabPage4);
            this.formMainSVTabControl.Controls.Add(this.tabPage5);
            this.formMainSVTabControl.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formMainSVTabControl.ItemSize = new System.Drawing.Size(105, 32);
            this.formMainSVTabControl.Location = new System.Drawing.Point(-3, -1);
            this.formMainSVTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.formMainSVTabControl.Name = "formMainSVTabControl";
            this.formMainSVTabControl.SelectedIndex = 0;
            this.formMainSVTabControl.Size = new System.Drawing.Size(1388, 680);
            this.formMainSVTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.updateInfo_Btn);
            this.tabPage1.Controls.Add(this.dtbtl_TextBox);
            this.tabPage1.Controls.Add(this.stctl_TextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.maNganh_TextBox);
            this.tabPage1.Controls.Add(this.maCT_TextBox);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.SDT_TextBox);
            this.tabPage1.Controls.Add(this.ngaySinh_TextBox);
            this.tabPage1.Controls.Add(this.diaChi_TextBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.gioiTinh_TextBox);
            this.tabPage1.Controls.Add(this.hoTen_TextBox);
            this.tabPage1.Controls.Add(this.maSV_TextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.maSV_label);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1380, 640);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin sinh  viên";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // updateInfo_Btn
            // 
            this.updateInfo_Btn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.updateInfo_Btn.Location = new System.Drawing.Point(812, 487);
            this.updateInfo_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.updateInfo_Btn.Name = "updateInfo_Btn";
            this.updateInfo_Btn.Size = new System.Drawing.Size(167, 43);
            this.updateInfo_Btn.TabIndex = 33;
            this.updateInfo_Btn.Text = "Cập nhật";
            this.updateInfo_Btn.UseVisualStyleBackColor = false;
            this.updateInfo_Btn.Click += new System.EventHandler(this.updateInfo_Btn_Click);
            // 
            // dtbtl_TextBox
            // 
            this.dtbtl_TextBox.Location = new System.Drawing.Point(776, 322);
            this.dtbtl_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.dtbtl_TextBox.Name = "dtbtl_TextBox";
            this.dtbtl_TextBox.ReadOnly = true;
            this.dtbtl_TextBox.Size = new System.Drawing.Size(201, 26);
            this.dtbtl_TextBox.TabIndex = 32;
            // 
            // stctl_TextBox
            // 
            this.stctl_TextBox.Location = new System.Drawing.Point(776, 274);
            this.stctl_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.stctl_TextBox.Name = "stctl_TextBox";
            this.stctl_TextBox.ReadOnly = true;
            this.stctl_TextBox.Size = new System.Drawing.Size(201, 26);
            this.stctl_TextBox.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(556, 325);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Điểm trung bình tích lũy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(556, 274);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Số tín chỉ tích lũy";
            // 
            // maNganh_TextBox
            // 
            this.maNganh_TextBox.Location = new System.Drawing.Point(173, 322);
            this.maNganh_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.maNganh_TextBox.Name = "maNganh_TextBox";
            this.maNganh_TextBox.ReadOnly = true;
            this.maNganh_TextBox.Size = new System.Drawing.Size(227, 26);
            this.maNganh_TextBox.TabIndex = 28;
            // 
            // maCT_TextBox
            // 
            this.maCT_TextBox.Location = new System.Drawing.Point(173, 272);
            this.maCT_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.maCT_TextBox.Name = "maCT_TextBox";
            this.maCT_TextBox.ReadOnly = true;
            this.maCT_TextBox.Size = new System.Drawing.Size(227, 26);
            this.maCT_TextBox.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(48, 325);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "Mã ngành";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(48, 274);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Mã CT";
            // 
            // SDT_TextBox
            // 
            this.SDT_TextBox.Location = new System.Drawing.Point(705, 27);
            this.SDT_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SDT_TextBox.Name = "SDT_TextBox";
            this.SDT_TextBox.ReadOnly = true;
            this.SDT_TextBox.Size = new System.Drawing.Size(272, 26);
            this.SDT_TextBox.TabIndex = 24;
            // 
            // ngaySinh_TextBox
            // 
            this.ngaySinh_TextBox.Location = new System.Drawing.Point(705, 75);
            this.ngaySinh_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ngaySinh_TextBox.Name = "ngaySinh_TextBox";
            this.ngaySinh_TextBox.ReadOnly = true;
            this.ngaySinh_TextBox.Size = new System.Drawing.Size(272, 26);
            this.ngaySinh_TextBox.TabIndex = 23;
            // 
            // diaChi_TextBox
            // 
            this.diaChi_TextBox.Location = new System.Drawing.Point(705, 126);
            this.diaChi_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.diaChi_TextBox.Multiline = true;
            this.diaChi_TextBox.Name = "diaChi_TextBox";
            this.diaChi_TextBox.ReadOnly = true;
            this.diaChi_TextBox.Size = new System.Drawing.Size(481, 26);
            this.diaChi_TextBox.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(556, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "SĐT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(556, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ngày sinh";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(556, 126);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Địa chỉ";
            // 
            // gioiTinh_TextBox
            // 
            this.gioiTinh_TextBox.Location = new System.Drawing.Point(173, 123);
            this.gioiTinh_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.gioiTinh_TextBox.Name = "gioiTinh_TextBox";
            this.gioiTinh_TextBox.ReadOnly = true;
            this.gioiTinh_TextBox.Size = new System.Drawing.Size(227, 26);
            this.gioiTinh_TextBox.TabIndex = 18;
            // 
            // hoTen_TextBox
            // 
            this.hoTen_TextBox.Location = new System.Drawing.Point(173, 75);
            this.hoTen_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.hoTen_TextBox.Name = "hoTen_TextBox";
            this.hoTen_TextBox.ReadOnly = true;
            this.hoTen_TextBox.Size = new System.Drawing.Size(227, 26);
            this.hoTen_TextBox.TabIndex = 17;
            // 
            // maSV_TextBox
            // 
            this.maSV_TextBox.Location = new System.Drawing.Point(173, 30);
            this.maSV_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.maSV_TextBox.Name = "maSV_TextBox";
            this.maSV_TextBox.ReadOnly = true;
            this.maSV_TextBox.Size = new System.Drawing.Size(227, 26);
            this.maSV_TextBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Họ tên";
            // 
            // maSV_label
            // 
            this.maSV_label.AutoSize = true;
            this.maSV_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maSV_label.Location = new System.Drawing.Point(37, 32);
            this.maSV_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maSV_label.Name = "maSV_label";
            this.maSV_label.Size = new System.Drawing.Size(59, 20);
            this.maSV_label.TabIndex = 13;
            this.maSV_label.Text = "Mã SV";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.resultLookup_dataGridView);
            this.tabPage2.Controls.Add(this.lookUp_Btn);
            this.tabPage2.Controls.Add(this.semester_ComboBox);
            this.tabPage2.Controls.Add(this.year_ComboBox);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1380, 685);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tra cứu kết quả học tập";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // resultLookup_dataGridView
            // 
            this.resultLookup_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultLookup_dataGridView.Location = new System.Drawing.Point(40, 103);
            this.resultLookup_dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.resultLookup_dataGridView.Name = "resultLookup_dataGridView";
            this.resultLookup_dataGridView.RowHeadersWidth = 51;
            this.resultLookup_dataGridView.Size = new System.Drawing.Size(1300, 556);
            this.resultLookup_dataGridView.TabIndex = 5;
            // 
            // lookUp_Btn
            // 
            this.lookUp_Btn.BackColor = System.Drawing.Color.Turquoise;
            this.lookUp_Btn.Location = new System.Drawing.Point(1216, 18);
            this.lookUp_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.lookUp_Btn.Name = "lookUp_Btn";
            this.lookUp_Btn.Size = new System.Drawing.Size(124, 36);
            this.lookUp_Btn.TabIndex = 4;
            this.lookUp_Btn.Text = "Tra cứu";
            this.lookUp_Btn.UseVisualStyleBackColor = false;
            this.lookUp_Btn.Click += new System.EventHandler(this.lookUp_Btn_Click);
            // 
            // semester_ComboBox
            // 
            this.semester_ComboBox.FormattingEnabled = true;
            this.semester_ComboBox.Location = new System.Drawing.Point(488, 23);
            this.semester_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.semester_ComboBox.Name = "semester_ComboBox";
            this.semester_ComboBox.Size = new System.Drawing.Size(160, 26);
            this.semester_ComboBox.TabIndex = 3;
            // 
            // year_ComboBox
            // 
            this.year_ComboBox.FormattingEnabled = true;
            this.year_ComboBox.Location = new System.Drawing.Point(140, 23);
            this.year_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.year_ComboBox.Name = "year_ComboBox";
            this.year_ComboBox.Size = new System.Drawing.Size(160, 26);
            this.year_ComboBox.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(379, 27);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 18);
            this.label12.TabIndex = 1;
            this.label12.Text = "Học kỳ:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 27);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Năm học:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.KHMO_dataGridView);
            this.tabPage3.Controls.Add(this.lookupKHMO_Btn);
            this.tabPage3.Controls.Add(this.semesterKHMO_ComboBox);
            this.tabPage3.Controls.Add(this.yearKHM_ComboBox);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Location = new System.Drawing.Point(4, 36);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1380, 685);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kế hoạch mở";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // KHMO_dataGridView
            // 
            this.KHMO_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KHMO_dataGridView.Location = new System.Drawing.Point(40, 108);
            this.KHMO_dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.KHMO_dataGridView.Name = "KHMO_dataGridView";
            this.KHMO_dataGridView.RowHeadersWidth = 51;
            this.KHMO_dataGridView.Size = new System.Drawing.Size(1309, 551);
            this.KHMO_dataGridView.TabIndex = 11;
            // 
            // lookupKHMO_Btn
            // 
            this.lookupKHMO_Btn.BackColor = System.Drawing.Color.Turquoise;
            this.lookupKHMO_Btn.Location = new System.Drawing.Point(1225, 21);
            this.lookupKHMO_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.lookupKHMO_Btn.Name = "lookupKHMO_Btn";
            this.lookupKHMO_Btn.Size = new System.Drawing.Size(124, 36);
            this.lookupKHMO_Btn.TabIndex = 10;
            this.lookupKHMO_Btn.Text = "Tra cứu";
            this.lookupKHMO_Btn.UseVisualStyleBackColor = false;
            this.lookupKHMO_Btn.Click += new System.EventHandler(this.lookupKHMO_Btn_Click);
            // 
            // semesterKHMO_ComboBox
            // 
            this.semesterKHMO_ComboBox.FormattingEnabled = true;
            this.semesterKHMO_ComboBox.Location = new System.Drawing.Point(497, 30);
            this.semesterKHMO_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.semesterKHMO_ComboBox.Name = "semesterKHMO_ComboBox";
            this.semesterKHMO_ComboBox.Size = new System.Drawing.Size(160, 26);
            this.semesterKHMO_ComboBox.TabIndex = 9;
            // 
            // yearKHM_ComboBox
            // 
            this.yearKHM_ComboBox.FormattingEnabled = true;
            this.yearKHM_ComboBox.Location = new System.Drawing.Point(149, 30);
            this.yearKHM_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.yearKHM_ComboBox.Name = "yearKHM_ComboBox";
            this.yearKHM_ComboBox.Size = new System.Drawing.Size(160, 26);
            this.yearKHM_ComboBox.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(388, 33);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 18);
            this.label13.TabIndex = 7;
            this.label13.Text = "Học kỳ:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 33);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 18);
            this.label14.TabIndex = 6;
            this.label14.Text = "Năm học:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DKHP_heading2_label);
            this.tabPage4.Controls.Add(this.courseRegister2_dataGridView);
            this.tabPage4.Controls.Add(this.unRegister_Btn);
            this.tabPage4.Controls.Add(this.courseRegister_Btn);
            this.tabPage4.Controls.Add(this.DKHP_heading1_label);
            this.tabPage4.Controls.Add(this.courseRegister1_dataGridView);
            this.tabPage4.Location = new System.Drawing.Point(4, 36);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(1380, 685);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Đăng ký học phần";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DKHP_heading2_label
            // 
            this.DKHP_heading2_label.AutoSize = true;
            this.DKHP_heading2_label.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DKHP_heading2_label.Location = new System.Drawing.Point(29, 334);
            this.DKHP_heading2_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DKHP_heading2_label.Name = "DKHP_heading2_label";
            this.DKHP_heading2_label.Size = new System.Drawing.Size(202, 23);
            this.DKHP_heading2_label.TabIndex = 18;
            this.DKHP_heading2_label.Text = "Danh sách môn còn lại";
            // 
            // courseRegister2_dataGridView
            // 
            this.courseRegister2_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseRegister2_dataGridView.Location = new System.Drawing.Point(33, 375);
            this.courseRegister2_dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.courseRegister2_dataGridView.Name = "courseRegister2_dataGridView";
            this.courseRegister2_dataGridView.RowHeadersWidth = 51;
            this.courseRegister2_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.courseRegister2_dataGridView.Size = new System.Drawing.Size(1309, 233);
            this.courseRegister2_dataGridView.TabIndex = 17;
            // 
            // unRegister_Btn
            // 
            this.unRegister_Btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.unRegister_Btn.Location = new System.Drawing.Point(1211, 272);
            this.unRegister_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.unRegister_Btn.Name = "unRegister_Btn";
            this.unRegister_Btn.Size = new System.Drawing.Size(132, 44);
            this.unRegister_Btn.TabIndex = 16;
            this.unRegister_Btn.Text = "Hủy đăng ký";
            this.unRegister_Btn.UseVisualStyleBackColor = false;
            this.unRegister_Btn.Click += new System.EventHandler(this.unRegister_Btn_Click);
            // 
            // courseRegister_Btn
            // 
            this.courseRegister_Btn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.courseRegister_Btn.Location = new System.Drawing.Point(1211, 615);
            this.courseRegister_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.courseRegister_Btn.Name = "courseRegister_Btn";
            this.courseRegister_Btn.Size = new System.Drawing.Size(132, 44);
            this.courseRegister_Btn.TabIndex = 15;
            this.courseRegister_Btn.Text = "Đăng ký";
            this.courseRegister_Btn.UseVisualStyleBackColor = false;
            this.courseRegister_Btn.Click += new System.EventHandler(this.courseRegister_Btn_Click);
            // 
            // DKHP_heading1_label
            // 
            this.DKHP_heading1_label.AutoSize = true;
            this.DKHP_heading1_label.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DKHP_heading1_label.Location = new System.Drawing.Point(29, 17);
            this.DKHP_heading1_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DKHP_heading1_label.Name = "DKHP_heading1_label";
            this.DKHP_heading1_label.Size = new System.Drawing.Size(236, 23);
            this.DKHP_heading1_label.TabIndex = 14;
            this.DKHP_heading1_label.Text = "Danh sách môn đã đăng ký";
            // 
            // courseRegister1_dataGridView
            // 
            this.courseRegister1_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseRegister1_dataGridView.Location = new System.Drawing.Point(33, 60);
            this.courseRegister1_dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.courseRegister1_dataGridView.Name = "courseRegister1_dataGridView";
            this.courseRegister1_dataGridView.RowHeadersWidth = 51;
            this.courseRegister1_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.courseRegister1_dataGridView.Size = new System.Drawing.Size(1309, 204);
            this.courseRegister1_dataGridView.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.resultCourseRegister_dataGridView);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Location = new System.Drawing.Point(4, 36);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(1380, 685);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Kết quả đăng ký học phần";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // resultCourseRegister_dataGridView
            // 
            this.resultCourseRegister_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultCourseRegister_dataGridView.Location = new System.Drawing.Point(39, 71);
            this.resultCourseRegister_dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.resultCourseRegister_dataGridView.Name = "resultCourseRegister_dataGridView";
            this.resultCourseRegister_dataGridView.RowHeadersWidth = 51;
            this.resultCourseRegister_dataGridView.Size = new System.Drawing.Size(1300, 569);
            this.resultCourseRegister_dataGridView.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(35, 25);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(341, 21);
            this.label17.TabIndex = 14;
            this.label17.Text = "Danh sách môn đã đăng ký trong học kỳ này";
            // 
            // oracleCommandBuilder1
            // 
            this.oracleCommandBuilder1.CatalogLocation = System.Data.Common.CatalogLocation.End;
            this.oracleCommandBuilder1.CatalogSeparator = "@";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(1246, 682);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Đăng xuất";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMainSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 718);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.formMainSVTabControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMainSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal - Cổng thông tin sinh viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainSinhVien_FormClosing);
            this.Load += new System.EventHandler(this.formSinhVien_Loaded);
            this.formMainSVTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultLookup_dataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KHMO_dataGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseRegister2_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseRegister1_dataGridView)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultCourseRegister_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl formMainSVTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private Oracle.ManagedDataAccess.Client.OracleCommandBuilder oracleCommandBuilder1;
        private System.Windows.Forms.TextBox SDT_TextBox;
        private System.Windows.Forms.TextBox ngaySinh_TextBox;
        private System.Windows.Forms.TextBox diaChi_TextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox gioiTinh_TextBox;
        private System.Windows.Forms.TextBox hoTen_TextBox;
        private System.Windows.Forms.TextBox maSV_TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label maSV_label;
        private System.Windows.Forms.TextBox dtbtl_TextBox;
        private System.Windows.Forms.TextBox stctl_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maNganh_TextBox;
        private System.Windows.Forms.TextBox maCT_TextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button updateInfo_Btn;
        private System.Windows.Forms.ComboBox year_ComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button lookUp_Btn;
        private System.Windows.Forms.ComboBox semester_ComboBox;
        private System.Windows.Forms.DataGridView resultLookup_dataGridView;
        private System.Windows.Forms.DataGridView KHMO_dataGridView;
        private System.Windows.Forms.Button lookupKHMO_Btn;
        private System.Windows.Forms.ComboBox semesterKHMO_ComboBox;
        private System.Windows.Forms.ComboBox yearKHM_ComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button courseRegister_Btn;
        private System.Windows.Forms.Label DKHP_heading1_label;
        private System.Windows.Forms.DataGridView courseRegister1_dataGridView;
        private System.Windows.Forms.DataGridView resultCourseRegister_dataGridView;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button unRegister_Btn;
        private System.Windows.Forms.DataGridView courseRegister2_dataGridView;
        private System.Windows.Forms.Label DKHP_heading2_label;
        private System.Windows.Forms.Button button1;
    }
}
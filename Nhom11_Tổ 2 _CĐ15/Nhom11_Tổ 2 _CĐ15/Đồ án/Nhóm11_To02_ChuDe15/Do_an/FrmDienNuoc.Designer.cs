namespace Do_an
{
    partial class FrmDienNuoc
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
            this.txtCSC_Dien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCSD_Nuoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgDS_DN = new System.Windows.Forms.DataGridView();
            this.txtCSC_Nuoc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTKiem_DN = new System.Windows.Forms.TextBox();
            this.btnSua_DN = new System.Windows.Forms.Button();
            this.btnThem_DN = new System.Windows.Forms.Button();
            this.btnXoa_DN = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCSD_Dien = new System.Windows.Forms.TextBox();
            this.txtMaDienNuoc_DN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoat_DN = new System.Windows.Forms.Button();
            this.btnLuu_DN = new System.Windows.Forms.Button();
            this.btnHuy_DN = new System.Windows.Forms.Button();
            this.btFind_DN = new System.Windows.Forms.Button();
            this.dtp_NBT_DN = new System.Windows.Forms.DateTimePicker();
            this.dtp_NKT_DN = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgDS_DN)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCSC_Dien
            // 
            this.txtCSC_Dien.Location = new System.Drawing.Point(185, 180);
            this.txtCSC_Dien.Margin = new System.Windows.Forms.Padding(5);
            this.txtCSC_Dien.Multiline = true;
            this.txtCSC_Dien.Name = "txtCSC_Dien";
            this.txtCSC_Dien.Size = new System.Drawing.Size(148, 30);
            this.txtCSC_Dien.TabIndex = 226;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(666, 147);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 23);
            this.label4.TabIndex = 225;
            this.label4.Text = "Ngày Kết Thúc: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(28, 188);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 23);
            this.label3.TabIndex = 224;
            this.label3.Text = "CS Cuối_Điện:";
            // 
            // txtCSD_Nuoc
            // 
            this.txtCSD_Nuoc.Location = new System.Drawing.Point(528, 101);
            this.txtCSD_Nuoc.Margin = new System.Windows.Forms.Padding(5);
            this.txtCSD_Nuoc.Multiline = true;
            this.txtCSD_Nuoc.Name = "txtCSD_Nuoc";
            this.txtCSD_Nuoc.Size = new System.Drawing.Size(113, 31);
            this.txtCSD_Nuoc.TabIndex = 223;
            this.txtCSD_Nuoc.TextChanged += new System.EventHandler(this.txtCSD_Nuoc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(354, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 222;
            this.label1.Text = "CS Cuối_Nước:";
            // 
            // dgDS_DN
            // 
            this.dgDS_DN.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgDS_DN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDS_DN.GridColor = System.Drawing.Color.Gray;
            this.dgDS_DN.Location = new System.Drawing.Point(32, 330);
            this.dgDS_DN.Name = "dgDS_DN";
            this.dgDS_DN.RowHeadersWidth = 51;
            this.dgDS_DN.RowTemplate.Height = 24;
            this.dgDS_DN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDS_DN.Size = new System.Drawing.Size(990, 210);
            this.dgDS_DN.TabIndex = 221;
            this.dgDS_DN.Click += new System.EventHandler(this.dgDS_DN_Click);
            // 
            // txtCSC_Nuoc
            // 
            this.txtCSC_Nuoc.Location = new System.Drawing.Point(528, 143);
            this.txtCSC_Nuoc.Margin = new System.Windows.Forms.Padding(5);
            this.txtCSC_Nuoc.Multiline = true;
            this.txtCSC_Nuoc.Name = "txtCSC_Nuoc";
            this.txtCSC_Nuoc.Size = new System.Drawing.Size(113, 31);
            this.txtCSC_Nuoc.TabIndex = 220;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(354, 105);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 23);
            this.label9.TabIndex = 219;
            this.label9.Text = "CS Đầu_Nước:";
            // 
            // txtTKiem_DN
            // 
            this.txtTKiem_DN.Location = new System.Drawing.Point(162, 290);
            this.txtTKiem_DN.Margin = new System.Windows.Forms.Padding(5);
            this.txtTKiem_DN.Multiline = true;
            this.txtTKiem_DN.Name = "txtTKiem_DN";
            this.txtTKiem_DN.Size = new System.Drawing.Size(171, 30);
            this.txtTKiem_DN.TabIndex = 218;
            // 
            // btnSua_DN
            // 
            this.btnSua_DN.BackColor = System.Drawing.Color.White;
            this.btnSua_DN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua_DN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSua_DN.Location = new System.Drawing.Point(919, 237);
            this.btnSua_DN.Name = "btnSua_DN";
            this.btnSua_DN.Size = new System.Drawing.Size(98, 38);
            this.btnSua_DN.TabIndex = 216;
            this.btnSua_DN.Text = "SỬA";
            this.btnSua_DN.UseVisualStyleBackColor = false;
            this.btnSua_DN.Click += new System.EventHandler(this.btnSua_DN_Click);
            // 
            // btnThem_DN
            // 
            this.btnThem_DN.BackColor = System.Drawing.Color.White;
            this.btnThem_DN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem_DN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnThem_DN.Location = new System.Drawing.Point(687, 237);
            this.btnThem_DN.Name = "btnThem_DN";
            this.btnThem_DN.Size = new System.Drawing.Size(98, 38);
            this.btnThem_DN.TabIndex = 215;
            this.btnThem_DN.Text = "THÊM";
            this.btnThem_DN.UseVisualStyleBackColor = false;
            this.btnThem_DN.Click += new System.EventHandler(this.btnThem_DN_Click);
            // 
            // btnXoa_DN
            // 
            this.btnXoa_DN.BackColor = System.Drawing.Color.White;
            this.btnXoa_DN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa_DN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnXoa_DN.Location = new System.Drawing.Point(803, 237);
            this.btnXoa_DN.Name = "btnXoa_DN";
            this.btnXoa_DN.Size = new System.Drawing.Size(98, 38);
            this.btnXoa_DN.TabIndex = 214;
            this.btnXoa_DN.Text = "XOÁ";
            this.btnXoa_DN.UseVisualStyleBackColor = false;
            this.btnXoa_DN.Click += new System.EventHandler(this.btnXoa_DN_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(400, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 42);
            this.label7.TabIndex = 213;
            this.label7.Text = "ĐIỆN NƯỚC";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtCSD_Dien
            // 
            this.txtCSD_Dien.Location = new System.Drawing.Point(185, 143);
            this.txtCSD_Dien.Margin = new System.Windows.Forms.Padding(5);
            this.txtCSD_Dien.Multiline = true;
            this.txtCSD_Dien.Name = "txtCSD_Dien";
            this.txtCSD_Dien.Size = new System.Drawing.Size(148, 30);
            this.txtCSD_Dien.TabIndex = 212;
            // 
            // txtMaDienNuoc_DN
            // 
            this.txtMaDienNuoc_DN.Location = new System.Drawing.Point(185, 101);
            this.txtMaDienNuoc_DN.Margin = new System.Windows.Forms.Padding(5);
            this.txtMaDienNuoc_DN.Multiline = true;
            this.txtMaDienNuoc_DN.Name = "txtMaDienNuoc_DN";
            this.txtMaDienNuoc_DN.Size = new System.Drawing.Size(148, 31);
            this.txtMaDienNuoc_DN.TabIndex = 211;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(30, 147);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 23);
            this.label5.TabIndex = 210;
            this.label5.Text = "CS Đầu_Điện:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(666, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 23);
            this.label6.TabIndex = 228;
            this.label6.Text = "Ngày Bắt Đầu: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(25, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 23);
            this.label2.TabIndex = 209;
            this.label2.Text = "Mã Điện Nước:";
            // 
            // btnThoat_DN
            // 
            this.btnThoat_DN.BackColor = System.Drawing.Color.White;
            this.btnThoat_DN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat_DN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnThoat_DN.Location = new System.Drawing.Point(919, 282);
            this.btnThoat_DN.Name = "btnThoat_DN";
            this.btnThoat_DN.Size = new System.Drawing.Size(98, 38);
            this.btnThoat_DN.TabIndex = 232;
            this.btnThoat_DN.Text = "THOÁT";
            this.btnThoat_DN.UseVisualStyleBackColor = false;
            this.btnThoat_DN.Click += new System.EventHandler(this.btnThoat_DN_Click);
            // 
            // btnLuu_DN
            // 
            this.btnLuu_DN.BackColor = System.Drawing.Color.White;
            this.btnLuu_DN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu_DN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLuu_DN.Location = new System.Drawing.Point(687, 282);
            this.btnLuu_DN.Name = "btnLuu_DN";
            this.btnLuu_DN.Size = new System.Drawing.Size(98, 38);
            this.btnLuu_DN.TabIndex = 231;
            this.btnLuu_DN.Text = "LƯU";
            this.btnLuu_DN.UseVisualStyleBackColor = false;
            // 
            // btnHuy_DN
            // 
            this.btnHuy_DN.BackColor = System.Drawing.Color.White;
            this.btnHuy_DN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy_DN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnHuy_DN.Location = new System.Drawing.Point(803, 282);
            this.btnHuy_DN.Name = "btnHuy_DN";
            this.btnHuy_DN.Size = new System.Drawing.Size(98, 38);
            this.btnHuy_DN.TabIndex = 230;
            this.btnHuy_DN.Text = "RESET";
            this.btnHuy_DN.UseVisualStyleBackColor = false;
            this.btnHuy_DN.Click += new System.EventHandler(this.btnHuy_DN_Click);
            // 
            // btFind_DN
            // 
            this.btFind_DN.BackColor = System.Drawing.Color.White;
            this.btFind_DN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFind_DN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btFind_DN.Location = new System.Drawing.Point(32, 288);
            this.btFind_DN.Name = "btFind_DN";
            this.btFind_DN.Size = new System.Drawing.Size(113, 35);
            this.btFind_DN.TabIndex = 235;
            this.btFind_DN.Text = "Tìm Kiếm";
            this.btFind_DN.UseVisualStyleBackColor = false;
            this.btFind_DN.Click += new System.EventHandler(this.btFind_DN_Click);
            // 
            // dtp_NBT_DN
            // 
            this.dtp_NBT_DN.Location = new System.Drawing.Point(831, 105);
            this.dtp_NBT_DN.Name = "dtp_NBT_DN";
            this.dtp_NBT_DN.Size = new System.Drawing.Size(200, 22);
            this.dtp_NBT_DN.TabIndex = 236;
            // 
            // dtp_NKT_DN
            // 
            this.dtp_NKT_DN.Location = new System.Drawing.Point(831, 147);
            this.dtp_NKT_DN.Name = "dtp_NKT_DN";
            this.dtp_NKT_DN.Size = new System.Drawing.Size(200, 22);
            this.dtp_NKT_DN.TabIndex = 237;
            // 
            // FrmDienNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1045, 552);
            this.Controls.Add(this.dtp_NKT_DN);
            this.Controls.Add(this.dtp_NBT_DN);
            this.Controls.Add(this.btFind_DN);
            this.Controls.Add(this.btnThoat_DN);
            this.Controls.Add(this.btnLuu_DN);
            this.Controls.Add(this.btnHuy_DN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCSC_Dien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCSD_Nuoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgDS_DN);
            this.Controls.Add(this.txtCSC_Nuoc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTKiem_DN);
            this.Controls.Add(this.btnSua_DN);
            this.Controls.Add(this.btnThem_DN);
            this.Controls.Add(this.btnXoa_DN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCSD_Dien);
            this.Controls.Add(this.txtMaDienNuoc_DN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Name = "FrmDienNuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDienNuoc";
            this.Load += new System.EventHandler(this.FrmDienNuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDS_DN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCSC_Dien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCSD_Nuoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDS_DN;
        private System.Windows.Forms.TextBox txtCSC_Nuoc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTKiem_DN;
        private System.Windows.Forms.Button btnSua_DN;
        private System.Windows.Forms.Button btnThem_DN;
        private System.Windows.Forms.Button btnXoa_DN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCSD_Dien;
        private System.Windows.Forms.TextBox txtMaDienNuoc_DN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoat_DN;
        private System.Windows.Forms.Button btnLuu_DN;
        private System.Windows.Forms.Button btnHuy_DN;
        private System.Windows.Forms.Button btFind_DN;
        private System.Windows.Forms.DateTimePicker dtp_NBT_DN;
        private System.Windows.Forms.DateTimePicker dtp_NKT_DN;
    }
}
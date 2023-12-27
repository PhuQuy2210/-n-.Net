using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an
{
    public partial class FrmTrangChu : Form
    {
        public FrmTrangChu()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //nút sinh viên nhe
        private void button1_Click(object sender, EventArgs e)
        {
            FrmSinhVien f1 = new FrmSinhVien();
            this.Hide();
            f1.ShowDialog();
            this.Show();
        }

        //nút nhân viên nè
        private void button2_Click(object sender, EventArgs e)
        {
            FrmNhanVien f2 = new FrmNhanVien();
            this.Hide();
            f2.ShowDialog();
            this.Show();
        }

        //nút phòng
        private void button3_Click(object sender, EventArgs e)
        {
            FrmPhongcs f3 = new FrmPhongcs();
            this.Hide();
            f3.ShowDialog();
            this.Show();
        }

        //nút người thân nhe ba
        private void button7_Click(object sender, EventArgs e)
        {
            FrmNguoiThan f4 = new FrmNguoiThan();
            this.Hide();
            f4.ShowDialog();
            this.Show();
        }

        //nút điện nước nè bà nội
        private void button4_Click(object sender, EventArgs e)
        {
            FrmDienNuoc f5 = new FrmDienNuoc();
            this.Hide();
            f5.ShowDialog();
            this.Show();
        }

        //nút hoá đơn đây
        private void button5_Click(object sender, EventArgs e)
        {
            FrmHoáĐơn f6 = new FrmHoáĐơn();
            this.Hide();
            f6.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmHopDong f7 = new FrmHopDong();
            this.Hide();
            f7.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =  MessageBox.Show("Bạn muốn thoát ứng dụng không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dialogResult == DialogResult.Yes)
            {
                FrmĐăng_Nhập f8 = new FrmĐăng_Nhập();
                f8.Show();
                this.Close();
            }
            else
            {
                //Ở lại trang chủ
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}

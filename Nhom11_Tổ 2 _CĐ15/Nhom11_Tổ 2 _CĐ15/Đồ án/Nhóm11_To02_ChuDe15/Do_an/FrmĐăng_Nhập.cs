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
    public partial class FrmĐăng_Nhập : Form
    {
        
        public FrmĐăng_Nhập()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Nhập thông tin đầy đủ nào !!", "Nào nào nào ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtTaiKhoan.Text != "User1234" || txtMatKhau.Text != "123456789")
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtTaiKhoan.Text == "User1234" && txtMatKhau.Text == "123456789")
            {
                FrmTrangChu f_TrangChu = new FrmTrangChu();
                this.Hide();
                f_TrangChu.ShowDialog();
                this.Show();
            }
        }

        private void FrmĐăng_Nhập_Load(object sender, EventArgs e)
        {
          
        }

        private void groupBoxThongTinDN_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn thoát ứng dụng không ?", "Khoan dừng lạii", MessageBoxButtons.OK);
            Application.Exit();
        }
    }
}

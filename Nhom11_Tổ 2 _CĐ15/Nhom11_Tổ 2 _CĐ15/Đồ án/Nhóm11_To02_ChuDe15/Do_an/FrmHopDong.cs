using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an
{
    public partial class FrmHopDong : Form
    {
        string ChuoiKN = "Data Source=LAPTOP-1170Q5GN\\MSSQLSERVER01;Initial Catalog=QLKTX;Integrated Security=True";
        SqlConnection conn;
        public FrmHopDong()
        {
            InitializeComponent();
        }
        private void OpenSQL()
        {
            conn = new SqlConnection(ChuoiKN);
            conn.Open();
        }


        private void LoaddataShow()
        {
            string str_Open = @"select * from HopDong";
            SqlDataAdapter adapter = new SqlDataAdapter(str_Open, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgDS_HD.DataSource = dt;
        }
        private void FrmHopDong_Load(object sender, EventArgs e)
        {
            OpenSQL();
            LoaddataShow();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_HDong_Click(object sender, EventArgs e)
        {
            FrmTrangChu f = new FrmTrangChu();
            f.Show();
            this.Close();
        }

        private void btnHuy_HDong_Click(object sender, EventArgs e)
        {
            txtMaHopDong_HDong.Clear();
            txtMaNV_HDong.Clear();
            txtMaPhong_HDong.Clear();
            txtNgayNPhong_HDong.Clear();
            txtNgayTPhong_HDong.Clear();
            txtSV_HDong.Clear();
            txtTKiem_HDong.Clear();
        }

        private void btnXoa_HDong_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dgDS_HD.SelectedRows)
            {
                if (!i.IsNewRow)
                {
                    string str_MaHopDong = dgDS_HD.SelectedRows[0].Cells["MaHopDong"].Value.ToString();
                    string str = @"delete from HopDong where MaHopDong= @MaHopDong";
                    using (SqlCommand command = new SqlCommand(str, conn))
                    {
                        command.Parameters.AddWithValue("@MaHopDong", str_MaHopDong);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Xóa lỗi", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    dgDS_HD.Rows.RemoveAt(dgDS_HD.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Chưa chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSua_HDong_Click(object sender, EventArgs e)
        {
            string str = @"UPDATE HopDong SET MaHopDong=@MaHopDong, MaSV=@MaSV, MaNV=@MaNV, NgayNhanPhong=@NgayNhanPhong, NgayTraPhong=@NgayTraPhong, MaPhong=@MaPhong where MaHopDong=@MaHopDong";
            using (SqlConnection connection = new SqlConnection(ChuoiKN))
            {
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    command.Parameters.AddWithValue("@MaHopDong", txtMaHopDong_HDong.Text);
                    command.Parameters.AddWithValue("@MaNV", txtMaNV_HDong.Text);
                    command.Parameters.AddWithValue("@MaSV", txtSV_HDong.Text);
                    command.Parameters.AddWithValue("@NgayNhanPhong", txtNgayNPhong_HDong.Text);
                    command.Parameters.AddWithValue("@NgayTraPhong", txtNgayTPhong_HDong.Text);
                    command.Parameters.AddWithValue("@MaPhong", txtMaPhong_HDong.Text);
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    LoaddataShow();
                }
            }
        }

        private void btnThem_HDong_Click(object sender, EventArgs e)
        {
            string str = @"insert into HopDong values (@MaHopDong, @MaNV, @MaSV, @MaPhong, @NgayNhanPhong, @NgayTraPhong)";
            if (txtMaHopDong_HDong.Text == "" || txtMaNV_HDong.Text == "" || txtSV_HDong.Text == "" ||
                txtNgayNPhong_HDong.Text == "" || txtNgayTPhong_HDong.Text == "" || txtMaPhong_HDong.Text == "")

            {
                MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(ChuoiKN))
                {
                    using (SqlCommand command = new SqlCommand(str, connection))
                    {
                        command.Parameters.AddWithValue("@MaHopDong", txtMaHopDong_HDong.Text);
                        command.Parameters.AddWithValue("@MaNV", txtMaNV_HDong.Text);
                        command.Parameters.AddWithValue("@MaSV", txtSV_HDong.Text);
                        command.Parameters.AddWithValue("@NgayNhanPhong", txtNgayNPhong_HDong.Text);
                        command.Parameters.AddWithValue("@NgayTraPhong", txtNgayTPhong_HDong.Text);
                        command.Parameters.AddWithValue("@MaPhong", txtMaPhong_HDong.Text);
                        connection.Open();
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        LoaddataShow();
                    }
                }
            }
        }

        private void btFind_HDong_Click(object sender, EventArgs e)
        {

            try
            {
                string str_Tim = @"select * from HopDong where MaHopDong like '" + txtMaHopDong_HDong.Text + "%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(str_Tim, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgDS_HD.DataSource = dataTable;
            }
            catch { MessageBox.Show("Hãy nhập mã số nhân viên cần tìm", "Thông báo", MessageBoxButtons.OK); }
        }

        private void dgDS_HD_Click(object sender, EventArgs e)
        {
            txtMaHopDong_HDong.Text = dgDS_HD.SelectedRows[0].Cells[0].Value.ToString();
            txtMaNV_HDong.Text = dgDS_HD.SelectedRows[0].Cells[1].Value.ToString();
            txtSV_HDong.Text = dgDS_HD.SelectedRows[0].Cells[2].Value.ToString();
            txtMaPhong_HDong.Text = dgDS_HD.SelectedRows[0].Cells[3].Value.ToString();
            txtNgayNPhong_HDong.Text = dgDS_HD.SelectedRows[0].Cells[4].Value.ToString();
            txtNgayTPhong_HDong.Text = dgDS_HD.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

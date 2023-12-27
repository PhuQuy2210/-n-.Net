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
    
    public partial class FrmHoáĐơn : Form
    {
        public int ChiSoDau_Nuoc, ChiSoDau_Dien, ChiSoCuoi_Dien, ChiSoCuoi_Nuoc;

        public FrmHoáĐơn()
        {
            InitializeComponent();
        }
        string ChuoiKN = "Data Source=LAPTOP-1170Q5GN\\MSSQLSERVER01;Initial Catalog=QLKTX;Integrated Security=True";
        SqlConnection conn;
        
        private void OpenSQL()
        {
            conn = new SqlConnection(ChuoiKN);
            conn.Open();
        }


        private void LoaddataShow()
        {
            string str_Open = @"select * from HoaDon";
            SqlDataAdapter adapter = new SqlDataAdapter(str_Open, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgDS_HoaDon.DataSource = dt;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmHoáĐơn_Load(object sender, EventArgs e)
        {
            OpenSQL();
            LoaddataShow();
        }

        private void btnThoat_HD_Click(object sender, EventArgs e)
        {
            FrmTrangChu f = new FrmTrangChu();
            f.Show();
            this.Close();
        }
        //Tổng tiền nước
        private void txtMaPhong_HD_TextChanged(object sender, EventArgs e)
        {

        }

        // Tổng tiền điện
        private void txtTTDien_HD_TextChanged(object sender, EventArgs e)
        {

        }


        
        private void btnThem_HD_Click(object sender, EventArgs e)
        {
            {
                string str = @"insert into HoaDon values (@MaHoaDon, @MaHopDong,@MaDienNuoc, @TongTienDien, @TongTienNuoc, @ThangNamTToan)";
                if (txtMaHD_HD.Text == "" || txtTTN_HD.Text == "" || txtMaHopDong_HD.Text == "" ||
                    txtTTDien_HD.Text == "" || dtp_TNTToan_HD.Text == ""|| txtMaDNuoc_HD.Text=="")

                {
                    MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(ChuoiKN))
                    {
                        using (SqlCommand command = new SqlCommand(str, connection))
                        {
                            command.Parameters.AddWithValue("@MaHoaDon", txtMaHD_HD.Text);
                            command.Parameters.AddWithValue("@MaPhong", txtTTN_HD.Text);
                            command.Parameters.AddWithValue("@MaHopDong", txtMaHopDong_HD.Text);
                            command.Parameters.AddWithValue("@TongTienDien", txtTTDien_HD.Text);
                            command.Parameters.AddWithValue("@TongTienNuoc", txtTTN_HD.Text);
                            command.Parameters.AddWithValue("@ThangNamThanhToan", dtp_TNTToan_HD.Text);
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
        }

        private void btnSua_HD_Click(object sender, EventArgs e)
        {
            string str = @"UPDATE HoaDon SET MaHoaDon=@MaHoaDon, @MaHopDong,@MaDienNuoc, @TongTienDien, @TongTienNuoc, @ThangNamTToan where MaHoaDon=@MaHoaDon";
            using (SqlConnection connection = new SqlConnection(ChuoiKN))
            {
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    command.Parameters.AddWithValue("@MaHoaDon", txtMaHD_HD.Text);
                    command.Parameters.AddWithValue("@MaHopDong", txtTTN_HD.Text);
                    command.Parameters.AddWithValue("@TongTienDien", txtTTDien_HD.Text);
                    command.Parameters.AddWithValue("@TongTienNuoc", txtTTN_HD.Text);
                    command.Parameters.AddWithValue("@ThangNamThanhToan", dtp_TNTToan_HD.Text);
                    
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK);
                    }
                    LoaddataShow();
                }
            }
        }

        private void dgDS_HoaDon_Click(object sender, EventArgs e)
        {
            txtMaHD_HD.Text = dgDS_HoaDon.SelectedRows[0].Cells[0].Value.ToString();
            txtMaHopDong_HD.Text = dgDS_HoaDon.SelectedRows[0].Cells[1].Value.ToString();
            txtMaDNuoc_HD.Text = dgDS_HoaDon.SelectedRows[0].Cells[2].Value.ToString();
            txtTTDien_HD.Text = dgDS_HoaDon.SelectedRows[0].Cells[3].Value.ToString();
            txtTTN_HD.Text = dgDS_HoaDon.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnXoa_HD_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dgDS_HoaDon.SelectedRows)
            {
                if (!i.IsNewRow)
                {
                    string str_MaHoaDon = dgDS_HoaDon.SelectedRows[0].Cells["MaHoaDon"].Value.ToString();
                    string str = @"delete from HoaDon where MaHoaDon= @MaHoaDon";
                    using (SqlCommand command = new SqlCommand(str, conn))
                    {
                        command.Parameters.AddWithValue("@MaHoaDon", txtMaHD_HD.Text);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Xóa lỗi", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    dgDS_HoaDon.Rows.RemoveAt(dgDS_HoaDon.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Chưa chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnHuy_HD_Click(object sender, EventArgs e)
        {
            txtMaDNuoc_HD.Clear();
            txtMaHD_HD.Clear();
            txtMaHopDong_HD.Clear();
            txtTTN_HD.Clear();
            txtTKiemHD_HD.Clear();
            txtTTDien_HD.Clear();
        }

        private void btFind_HDon_Click(object sender, EventArgs e)
        {

            try
            {
                string str_Tim = @"select * from HoaDon where MaHoaDon like '" + txtTKiemHD_HD.Text + "%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(str_Tim, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgDS_HoaDon.DataSource = dataTable;
            }
            catch { MessageBox.Show("Hãy nhập mã số nhân viên cần tìm", "Thông báo", MessageBoxButtons.OK); }
        }
    }
}

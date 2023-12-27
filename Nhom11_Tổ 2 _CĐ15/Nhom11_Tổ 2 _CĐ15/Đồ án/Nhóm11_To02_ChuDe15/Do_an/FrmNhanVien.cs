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
    public partial class FrmNhanVien : Form
    {
        string ChuoiKN = "Data Source=LAPTOP-1170Q5GN\\MSSQLSERVER01;Initial Catalog=QLKTX;Integrated Security=True";
        SqlConnection conn;

        string maNV_Currency;
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            OpenSQL();
            LoaddataShow();
        }

        private void OpenSQL()
        {
            conn = new SqlConnection(ChuoiKN);
            conn.Open();
        }


        private void LoaddataShow()
        {
            string str_Open = @"select * from NhanVien";
            SqlDataAdapter adapter = new SqlDataAdapter(str_Open, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgDS_NV.DataSource = dt;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_NT_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_NT_Click(object sender, EventArgs e)
        {
            FrmTrangChu f = new FrmTrangChu();
            f.Show();
            this.Close();
        }

        private void btnHuy_NT_Click(object sender, EventArgs e)
        {
            txtMaNV_NV.Clear();
            txtHoten_NV.Clear();
            txtQueQuan_NV.Clear();
            txtEmail_NV.Clear();
            txtSDT_NV.Clear();
            txtChucVu_NV.Clear();
            //radNam_NV.Checked = false;
            //radNu_NV.Checked = false;
            DateTime dt = new DateTime(2000, 1, 1);
            dtpNgaySinh.Value = dt;
        }

        private void btnThem_NV_Click(object sender, EventArgs e)
        {
            try
            {
                string str = @"insert into NhanVien values (@MaNV, @HoTen, @GioiTinh, @QueQuan, @Email, @ChucVu, @SDT, @NgaySinh)";
                if (txtMaNV_NV.Text == "" || txtHoten_NV.Text == "" || txtQueQuan_NV.Text == "" ||
                    txtEmail_NV.Text == "" || txtSDT_NV.Text == "" ||
                     txtChucVu_NV.Text == "" || (radNam_NV.Checked == false && radNu_NV.Checked == false))

                {
                    MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(ChuoiKN))
                    {
                        using (SqlCommand command = new SqlCommand(str, connection))
                        {

                            command.Parameters.AddWithValue("@MaNV", txtMaNV_NV.Text);
                            command.Parameters.AddWithValue("@HoTen", txtHoten_NV.Text);
                            command.Parameters.AddWithValue("@QueQuan", txtQueQuan_NV.Text);
                            command.Parameters.AddWithValue("@Email", txtEmail_NV.Text);
                            command.Parameters.AddWithValue("@SDT", txtSDT_NV.Text);
                            command.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.ToString("yyyy-MM-dd"));
                            command.Parameters.AddWithValue("@ChucVu", txtChucVu_NV.Text);
                            if (radNam_NV.Checked)
                            {
                                command.Parameters.AddWithValue("@GioiTinh", radNam_NV.Text);
                            }
                            else if (radNu_NV.Checked)
                            {
                                command.Parameters.AddWithValue("@GioiTinh", radNu_NV.Text);
                            }
                            else
                            {
                                MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                            }
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Thêm thông tin nhân viên thành công");
            LoaddataShow();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_NV_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow i in dgDS_NV.SelectedRows)
            {
                if (!i.IsNewRow)
                {
                    string str_MaNV = dgDS_NV.SelectedRows[0].Cells["MaNV"].Value.ToString();
                    string str = @"delete from SinhVien where MaNV = @MaNV";
                    using (SqlCommand command = new SqlCommand(str, conn))
                    {
                        command.Parameters.AddWithValue("@MaNV", txtMaNV_NV.Text);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Xóa lỗi", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    dgDS_NV.Rows.RemoveAt(dgDS_NV.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Chưa chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSua_NV_Click(object sender, EventArgs e)
        {
            string str = @"UPDATE NhanVien SET MaNV=@MaNV, HoTen=@HoTen, GioiTinh=@GioiTinh, QueQuan=@QueQuan, Email=@Email, ChucVu=@ChucVu, SDT=@SDT, NgaySinh=@NgaySinh where MaNV = @MaNV";
            using (SqlConnection connection = new SqlConnection(ChuoiKN))
            {
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    command.Parameters.AddWithValue("@MaNV", txtMaNV_NV.Text);
                    command.Parameters.AddWithValue("@HoTen", txtHoten_NV.Text);
                    command.Parameters.AddWithValue("@QueQuan", txtQueQuan_NV.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail_NV.Text);
                    command.Parameters.AddWithValue("@SDT", txtSDT_NV.Text);
                    command.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Text);
                    command.Parameters.AddWithValue("@ChucVu", txtChucVu_NV.Text);
                    if (radNam_NV.Checked)
                    {
                        command.Parameters.AddWithValue("@GioiTinh", radNam_NV.Text);
                    }
                    else if (radNu_NV.Checked)
                    {
                        command.Parameters.AddWithValue("@GioiTinh", radNu_NV.Text);
                    }
                    else
                    {
                        MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                    }
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK);
                    }
                    connection.Close();
                    LoaddataShow();
                }
            }
        }

        private void btFind_NV_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Tim = @"select * from NhanVien where MaNV like '" + txtTKiem_NV.Text + "%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(str_Tim, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgDS_NV.DataSource = dataTable;
            }
            catch { MessageBox.Show("Hãy nhập mã số nhân viên cần tìm", "Thông báo", MessageBoxButtons.OK); }
        }

        private void dgDS_NV_Click(object sender, EventArgs e)
        {
            maNV_Currency = txtMaNV_NV.Text;
            txtMaNV_NV.Text = dgDS_NV.SelectedRows[0].Cells[0].Value.ToString();
            txtHoten_NV.Text = dgDS_NV.SelectedRows[0].Cells[1].Value.ToString();
            string gioiTinh = dgDS_NV.SelectedRows[0].Cells[2].Value.ToString();
            if (gioiTinh.Equals("Nam"))
                radNam_NV.Checked = true;
            else radNu_NV.Checked = true;
            txtQueQuan_NV.Text = dgDS_NV.SelectedRows[0].Cells[3].Value.ToString();
            txtEmail_NV.Text = dgDS_NV.SelectedRows[0].Cells[4].Value.ToString();
            txtChucVu_NV.Text = dgDS_NV.SelectedRows[0].Cells[5].Value.ToString();
            txtSDT_NV.Text = dgDS_NV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void radNam_NV_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

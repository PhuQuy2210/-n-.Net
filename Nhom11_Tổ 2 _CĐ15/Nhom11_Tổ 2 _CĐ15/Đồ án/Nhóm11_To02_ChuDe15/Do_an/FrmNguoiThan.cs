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
    public partial class FrmNguoiThan : Form
    {
        string ChuoiKN = "Data Source=LAPTOP-1170Q5GN\\MSSQLSERVER01;Initial Catalog=QLKTX;Integrated Security=True";
        SqlConnection conn;
        public FrmNguoiThan()
        {
            InitializeComponent();
        }
        private void OpenSQL()
        {
            conn = new SqlConnection(ChuoiKN);
            conn.Open();
        }


        private void Loaddatashow()
        {
            string str_Open = @"select * from NguoiThan";
            SqlDataAdapter adapter = new SqlDataAdapter(str_Open, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgDS_NguoiThan.DataSource = dt;
        }
        private void FrmNguoiThan_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd-MM-yyyy";
            OpenSQL();
            Loaddatashow();
        }

        private void btnThoat_NT_Click(object sender, EventArgs e)
        {
            FrmTrangChu f = new FrmTrangChu();
            f.Show();
            this.Close();
        }

        private void btnThem_SV_Click(object sender, EventArgs e)
        {
            string str = @"insert into NguoiThan values (@MaNguoiThan, @HoTenNguoiThan, @GioiTinh, @DiaChi, @SoDienThoai, @Email, @NgaySinh, @MaSV)";
            if (txtMaSV_NT.Text == "" || txtMaNT_NT.Text == "" || txtDiaChi_NT.Text == "" ||
                txtHoten_NT.Text == "" || txtEmail_NT.Text == "" ||
                txtSDT_NT.Text == "" || (radNam_NT.Checked == false && radNu_NT.Checked == false))

            {
                MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(ChuoiKN))
                {
                    using (SqlCommand command = new SqlCommand(str, connection))
                    {
                        command.Parameters.AddWithValue("@MaSV", txtMaSV_NT.Text);
                        command.Parameters.AddWithValue("@HoTenNguoiThan", txtHoten_NT.Text);
                        command.Parameters.AddWithValue("@MaNguoiThan", txtMaNT_NT.Text);
                        command.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@SoDienThoai", txtSDT_NT.Text);
                        command.Parameters.AddWithValue("@DiaChi", txtDiaChi_NT.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail_NT.Text);
                        if (radNam_NT.Checked)
                        {
                            command.Parameters.AddWithValue("@GioiTinh", radNam_NT.Text);
                        }
                        else if (radNu_NT.Checked)
                        {
                            command.Parameters.AddWithValue("@GioiTinh", radNu_NT.Text);
                        }
                        else
                        {
                            MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                        }
                        
                        
                        connection.Open();
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
                        Loaddatashow();
                    }
                }
            }
        }

        private void btnSua_NT_Click(object sender, EventArgs e)
        {
            string str = @"UPDATE NguoiThan SET MaNguoiThan=@MaNguoiThan, HoTenNguoiThan=@HoTenNguoiThan, MaSV=@MaSV, NgaySinh=@NgaySinh, SoDienThoai=@SoienThoai, DiaChi=@DiaChi, Email=@Email, GioiTinh=@GioiTinh where MaNguoiThan=@MaNguoiThan";
            using (SqlConnection connection = new SqlConnection(ChuoiKN))
            {
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    command.Parameters.AddWithValue("@MaSV", txtMaSV_NT.Text);
                    command.Parameters.AddWithValue("@HoTenNguoiThan", txtHoten_NT.Text);
                    command.Parameters.AddWithValue("@MaNguoiThan", txtMaNT_NT.Text);
                    command.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@SoienThoai", txtSDT_NT.Text);
                    command.Parameters.AddWithValue("@DiaChi", txtDiaChi_NT.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail_NT.Text);
                    if (radNam_NT.Checked)
                    {
                        command.Parameters.AddWithValue("@GioiTinh", radNam_NT.Text);
                    }
                    else if (radNu_NT.Checked)
                    {
                        command.Parameters.AddWithValue("@GioiTinh", radNu_NT.Text);
                    }
                    else
                    {
                        MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                    }
                    
                    
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Loaddatashow();
                }
            }
        }

        private void btnXoa_NT_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dgDS_NguoiThan.SelectedRows)
            {
                if (!i.IsNewRow)
                {
                    string str_MaNT = dgDS_NguoiThan.SelectedRows[0].Cells["MaNT"].Value.ToString();
                    string str = @"delete from NguoiThan where MaNT = @MaNT";
                    using (SqlCommand command = new SqlCommand(str, conn))
                    {
                        command.Parameters.AddWithValue("@MaNT", txtMaNT_NT.Text);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Xóa lỗi", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    dgDS_NguoiThan.Rows.RemoveAt(dgDS_NguoiThan.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Chưa chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnHuy_NT_Click(object sender, EventArgs e)
        {
            txtMaSV_NT.Clear();
            txtHoten_NT.Clear();
            txtMaNT_NT.Clear();
            txtDiaChi_NT.Clear();
            txtSDT_NT.Clear();
            //txtNgaySinh_NT.Clear();
            txtEmail_NT.Clear();
            radNam_NT.Enabled = false;
            radNu_NT.Enabled = false;
        }

        private void btFind_NT_Click(object sender, EventArgs e)
        {

            try
            {
                string str_Tim = @"select * from NguoiThan where MaNguoiThan like '" + txtTKiem_NT.Text + "%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(str_Tim, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgDS_NguoiThan.DataSource = dataTable;
            }
            catch { MessageBox.Show("Hãy nhập mã số nhân viên cần tìm", "Thông báo", MessageBoxButtons.OK); }
        }

        private void dgDS_NguoiThan_Click(object sender, EventArgs e)
        {
            txtMaSV_NT.Text = dgDS_NguoiThan.SelectedRows[0].Cells[7].Value.ToString();
            txtMaNT_NT.Text = dgDS_NguoiThan.SelectedRows[0].Cells[0].Value.ToString();
            //txtMaPhong.Text = dgvThongTinSinhVien.SelectedRows[0].Cells[8].Value.ToString();
            txtHoten_NT.Text = dgDS_NguoiThan.SelectedRows[0].Cells[1].Value.ToString();
            txtEmail_NT.Text = dgDS_NguoiThan.SelectedRows[0].Cells[5].Value.ToString();
            txtDiaChi_NT.Text = dgDS_NguoiThan.SelectedRows[0].Cells[3].Value.ToString();
            txtSDT_NT.Text = dgDS_NguoiThan.SelectedRows[0].Cells[4].Value.ToString();
            string gioiTinh = dgDS_NguoiThan.SelectedRows[0].Cells[2].Value.ToString();
            if (gioiTinh.Equals("Nam"))
                radNam_NT.Checked = true;
            else radNu_NT.Checked = true;
            dtpNgaySinh.Value = (DateTime)dgDS_NguoiThan.SelectedRows[0].Cells[6].Value;
        }
    }
}

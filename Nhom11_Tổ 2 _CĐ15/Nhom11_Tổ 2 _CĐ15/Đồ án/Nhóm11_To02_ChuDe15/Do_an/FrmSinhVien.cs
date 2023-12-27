using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an
{
   
    public partial class FrmSinhVien : Form
    {
        string ChuoiKN = "Data Source=LAPTOP-1170Q5GN\\MSSQLSERVER01;Initial Catalog=QLKTX;Integrated Security=True";
        SqlConnection conn;
        public FrmSinhVien()
        {
            InitializeComponent();
        }
        private void OpenSQL()
        {
            conn = new SqlConnection(ChuoiKN);
            conn.Open();
        }
        private void txtMaSV_HD_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FrmSinhVien_Load(object sender, EventArgs e)
        {
            OpenSQL();
            LoaddataShow();
            dateTimePicker_SV.Format = DateTimePickerFormat.Custom;
            dateTimePicker_SV.CustomFormat = "dd-MM-yyyy";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void LoaddataShow()
        {
            string str_Open = @"select * from SinhVien";
            SqlDataAdapter adapter = new SqlDataAdapter(str_Open, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvThongTinSinhVien.DataSource = dt;
        }

        private void btnThem_SV_Click(object sender, EventArgs e)
        {
            try
            {
                string str = @"insert into SinhVien values (@MaSV, @MaNguoiThan, @HoTen,  @GioiTinh, @NgaySinh, @Email, @DiaChi, @SoienThoai, @MaPhong)";
                if (txtMaSV_SV.Text == "" || txtMaNT_SV.Text == "" || txtMaPhong_SV.Text == "" ||
                    txtHoten_SV.Text == "" || txtDiaChi_SV.Text == "" || txtEmail_SV.Text == "" ||
                    txtSDT_SV.Text == "" || dateTimePicker_SV.Text == "" || (radNam_SV.Checked == false && radNu_SV.Checked == false))

                {
                    MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(ChuoiKN))
                    {
                        using (SqlCommand command = new SqlCommand(str, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@MaSV", txtMaSV_SV.Text);
                            command.Parameters.AddWithValue("@MaNguoiThan", txtMaNT_SV.Text);
                            command.Parameters.AddWithValue("@HoTen", txtHoten_SV.Text);
                            if (radNam_SV.Checked)
                            {
                                command.Parameters.AddWithValue("@GioiTinh", "Nam");
                            }
                            else if (radNu_SV.Checked)
                            {
                                command.Parameters.AddWithValue("@GioiTinh", "Nữ");
                            }
                            else
                            {
                                MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                            }
                            DateTime ngayDuocChon = dateTimePicker_SV.Value;
                            string ngaysinh = ngayDuocChon.ToString("yyyy-MM-dd");
                            command.Parameters.AddWithValue("@Email", txtEmail_SV.Text);
                            command.Parameters.AddWithValue("@DiaChi", txtDiaChi_SV.Text);
                            
                            command.Parameters.AddWithValue("@NgaySinh", ngaysinh);
                            command.Parameters.AddWithValue("@SoienThoai", txtSDT_SV.Text);
                            command.Parameters.AddWithValue("@MaPhong", txtMaPhong_SV.Text);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Thêm thông tin sinh viên thành công");
            LoaddataShow();
        }   
        private void btnXoa_SV_Click(object sender, EventArgs e)
        {
            /*
            foreach (DataGridViewRow i in dgvThongTinSinhVien.SelectedRows)
            {
                if (!i.IsNewRow)
                {
                    
                    
                    dgvThongTinSinhVien.Rows.RemoveAt(dgvThongTinSinhVien.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Chưa chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK);
                }
            }*/
            string str_MaSV = dgvThongTinSinhVien.SelectedRows[0].Cells["MaSV"].Value.ToString();
            string str = @"delete from SinhVien where MaSV = @MaSV";
            using (SqlCommand command = new SqlCommand(str, conn))
            {
                command.Parameters.AddWithValue("@MaSV", txtMaSV_SV.Text);
                try
                {
                    command.ExecuteNonQuery();

                    MessageBox.Show("Đã xóa sinh viên!", "Thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa lỗi", "Thông báo", MessageBoxButtons.OK);
                }
            }
            LoaddataShow();
        }

        private void btnSua_SV_Click(object sender, EventArgs e)
        {
            string str = "update SinhVien set MaNguoiThan = @MaNguoiThan, HoTen = @HoTen, GioiTinh = @GioiTinh, Email = @Email, DiaChi = @DiaChi, SoDienThoai = @SDT, MaPhong = @MaPhong where MaSV = @MaSV";
            using (SqlConnection connection = new SqlConnection(ChuoiKN))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    command.Parameters.AddWithValue("@MaSV", txtMaSV_SV.Text);
                    command.Parameters.AddWithValue("@HoTen", txtHoten_SV.Text);
                    command.Parameters.AddWithValue("@MaNguoiThan", txtMaNT_SV.Text);
                    //Chuyển giá trị của datime picker kiểu datetime sang định dạng năm-tháng-ngày để lưu vào csdl
                    command.Parameters.AddWithValue("@NgaySinh", dateTimePicker_SV.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100).Value = txtDiaChi_SV.Text;
                    command.Parameters.AddWithValue("@SDT", txtSDT_SV.Text);
                    command.Parameters.AddWithValue("@MaPhong", txtMaPhong_SV.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail_SV.Text);
                    string gioiTinh = radNam_SV.Checked ? "Nam" : "Nữ";
                    command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 3).Value = gioiTinh;
                    
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK);
                    }
                    MessageBox.Show("Sửa thông tin sinh viên thành công");
                    LoaddataShow();
                }
            }
        }

        private void dgvThongTinSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dataGridViewRow = dgvThongTinSinhVien.SelectedRows[0];
                txtMaSV_SV.Text = dataGridViewRow.Cells["MaSV"].Value.ToString();
                txtHoten_SV.Text = dataGridViewRow.Cells["HoTen"].Value.ToString();
                txtMaNT_SV.Text = dataGridViewRow.Cells["MaNguoiThan"].Value.ToString();
                txtMaPhong_SV.Text = dataGridViewRow.Cells["MaPhong"].Value.ToString();
                txtSDT_SV.Text = dataGridViewRow.Cells["SoDienThoai"].Value.ToString();
                dateTimePicker_SV.Text = dataGridViewRow.Cells["NgaySinh"].Value.ToString();
                txtEmail_SV.Text = dataGridViewRow.Cells["Email"].Value.ToString();
                radNu_SV.Text = dataGridViewRow.Cells["GioiTinh"].Value.ToString();
                radNam_SV.Text = dataGridViewRow.Cells["GioiTinh"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Hãy chọn dữ liệu", "THông báo", MessageBoxButtons.OK);
            }
        }

        private void btnRS_SV_Click(object sender, EventArgs e)
        {
            txtMaSV_SV.Clear();
            txtHoten_SV.Clear();
            txtMaNT_SV.Clear();
            txtMaPhong_SV.Clear();
            txtSDT_SV.Clear();
            
            txtEmail_SV.Clear();
            txtDiaChi_SV.Clear();
            radNam_SV.Checked = false;
            radNu_SV.Checked = false;
            DateTime dt = new DateTime(2000, 1, 1);
            dateTimePicker_SV.Value = dt;
        }

        private void btnThoat_SV_Click(object sender, EventArgs e)
        {
            FrmTrangChu f = new FrmTrangChu();
            f.Show();
            this.Close();
        }

    

        private void dgvThongTinSinhVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btFind_SV_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Tim = @"select * from SinhVien where MaSV like '" + txtTKiem_SV.Text + "%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(str_Tim, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvThongTinSinhVien.DataSource = dataTable;
            }
            catch { MessageBox.Show("Hãy nhập mã số nhân viên cần tìm", "Thông báo", MessageBoxButtons.OK); }
        }

        private void dgvThongTinSinhVien_Click(object sender, EventArgs e)
        {
            txtMaSV_SV.Text= dgvThongTinSinhVien.SelectedRows[0].Cells[0].Value.ToString();
            txtMaNT_SV.Text = dgvThongTinSinhVien.SelectedRows[0].Cells[1].Value.ToString();
            txtMaPhong_SV.Text = dgvThongTinSinhVien.SelectedRows[0].Cells[8].Value.ToString();
            txtHoten_SV.Text = dgvThongTinSinhVien.SelectedRows[0].Cells[2].Value.ToString();
            txtEmail_SV.Text = dgvThongTinSinhVien.SelectedRows[0].Cells[5].Value.ToString();
            txtDiaChi_SV.Text = dgvThongTinSinhVien.SelectedRows[0].Cells[6].Value.ToString();
            txtSDT_SV.Text = dgvThongTinSinhVien.SelectedRows[0].Cells[7].Value.ToString();
            string gioiTinh = dgvThongTinSinhVien.SelectedRows[0].Cells[3].Value.ToString();
            if(gioiTinh.Equals("Nam"))
                radNam_SV.Checked = true;
            else radNu_SV.Checked = true;
            dateTimePicker_SV.Text = dgvThongTinSinhVien.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}

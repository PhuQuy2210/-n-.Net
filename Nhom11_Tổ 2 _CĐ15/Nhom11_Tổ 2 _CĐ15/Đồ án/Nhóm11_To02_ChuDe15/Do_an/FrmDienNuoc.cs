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
    public partial class FrmDienNuoc : Form
    {
        public FrmDienNuoc()
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
            string str_Open = @"select * from DienNuoc";
            SqlDataAdapter adapter = new SqlDataAdapter(str_Open, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgDS_DN.DataSource = dt;
           

        }
        private void FrmDienNuoc_Load(object sender, EventArgs e)
        {
            OpenSQL();
            LoaddataShow(); 
        }

        private void btnThoat_DN_Click(object sender, EventArgs e)
        {
            FrmTrangChu f = new FrmTrangChu();
            f.Show();
            this.Close();
         
        }

        private void btnSua_DN_Click(object sender, EventArgs e)
        {
            string str = @"UPDATE DienNuoc SET MaDienNuoc=@MaDienNuoc,
                        ChiSoDau_Dien=@ChiSoDau_Dien, ChiSoDau_Nuoc=@ChiSoDau_Nuoc, 
                        ChiSoCuoi_Dien=@ChiSoCuoi_Dien, ChiSoCuoi_Nuoc=@ChiSoCuoi_Nuoc, 
                        NgayBatDau=@NgayBatDau, NgayKetThuc=@NgayKetThuc where MaDienNuoc = @MaDienNuoc ";
            using (SqlConnection connection = new SqlConnection(ChuoiKN))
            {
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    command.Parameters.AddWithValue("@MaDienNuoc", txtMaDienNuoc_DN.Text);
                    command.Parameters.AddWithValue("@ChiSoDau_Dien", txtCSD_Dien.Text);
                    command.Parameters.AddWithValue("@ChiSoDau_Nuoc", txtCSD_Nuoc.Text);
                    command.Parameters.AddWithValue("@ChiSoCuoi_Dien", txtCSC_Dien.Text);
                    command.Parameters.AddWithValue("@ChiSoCuoi_Nuoc", txtCSC_Nuoc.Text);
                    command.Parameters.AddWithValue("@NgayBatDau", dtp_NBT_DN.Value.ToString("yyyy-MM-dd"));// trở về ngày mặc định
                    command.Parameters.AddWithValue("@NgayKetThuc", dtp_NKT_DN.Value.ToString("yyyy-MM-dd"));// trở về ngày mặc định
                    connection.Open();
                    try
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                        command.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    LoaddataShow();
                }
            }
        }

        private void btnXoa_DN_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dgDS_DN.SelectedRows)
            {
                if (!i.IsNewRow)
                {
                    string str_MaDienNuoc = dgDS_DN.SelectedRows[0].Cells["MaDienNuoc"].Value.ToString();
                    string str = @"delete from DienNuoc where MaDienNuoc = @MaDienNuoc";
                    using (SqlCommand command = new SqlCommand(str, conn))
                    {
                        command.Parameters.AddWithValue("@MaDienNuoc", txtMaDienNuoc_DN.Text);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Xóa lỗi", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    dgDS_DN.Rows.RemoveAt(dgDS_DN.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Chưa chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnThem_DN_Click(object sender, EventArgs e)
        {
            string str = @"insert into DienNuoc values (@MaDienNuoc, @ChiSoDau_Dien, @ChiSoDau_Nuoc, @ChiSoCuoi_Dien, @ChiSoCuoi_Nuoc, @NgayBatDau, @NgayKetThuc )";
            if (txtMaDienNuoc_DN.Text == "" || txtCSD_Dien.Text == "" ||
                txtCSD_Nuoc.Text == "" || txtCSC_Dien.Text == "" || txtCSC_Nuoc.Text == "" ||
                dtp_NBT_DN.Text == "" || dtp_NKT_DN.Text == "")

            {
                MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(ChuoiKN))
                {
                    using (SqlCommand command = new SqlCommand(str, connection))
                    {
                        command.Parameters.AddWithValue("@MaDienNuoc", txtMaDienNuoc_DN.Text);
                        command.Parameters.AddWithValue("@ChiSoDau_Dien", int.Parse(txtCSD_Dien.Text));
                        command.Parameters.AddWithValue("@ChiSoDau_Nuoc", int.Parse(txtCSD_Nuoc.Text));
                        command.Parameters.AddWithValue("@ChiSoCuoi_Dien",int.Parse(txtCSC_Dien.Text));
                        command.Parameters.AddWithValue("@ChiSoCuoi_Nuoc",int.Parse(txtCSC_Nuoc.Text));
                        command.Parameters.AddWithValue("@NgayBatDau", dtp_NBT_DN.Value.ToString("yyyy-MM-dd"));// trở về ngày mặc định
                        command.Parameters.AddWithValue("@NgayKetThuc", dtp_NKT_DN.Value.ToString("yyyy-MM-dd"));// trở về ngày mặc định
                        connection.Open();
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                        }
                        catch(Exception ex )
                        {
                            MessageBox.Show(ex.Message);
                        }
                        LoaddataShow();
                    }
                }
            }
        }

        private void btnHuy_DN_Click(object sender, EventArgs e)
        {
            txtMaDienNuoc_DN.Clear();
            txtCSD_Dien.Clear();
            txtCSD_Nuoc.Clear();
            txtCSC_Dien.Clear();
            txtCSC_Nuoc.Clear();
            DateTime dt1 = new DateTime(2000,1,1);
            dtp_NBT_DN.Value = dt1;
            DateTime dt2 = new DateTime(2000, 1, 1);
            dtp_NKT_DN.Value = dt2;
        }

        private void dgDS_DN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btFind_DN_Click(object sender, EventArgs e)
        {

            try
            {
                string str_Tim = @"select * from DienNuoc where MaDienNuoc like '" + txtTKiem_DN.Text + "%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(str_Tim, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgDS_DN.DataSource = dataTable;
            }
            catch { MessageBox.Show("Hãy nhập mã số nhân viên cần tìm", "Thông báo", MessageBoxButtons.OK); }
        }

        private void txtCSD_Nuoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgDS_DN_Click(object sender, EventArgs e)
        {
            txtMaDienNuoc_DN.Text = dgDS_DN.SelectedRows[0].Cells[0].Value.ToString();
            txtCSD_Dien.Text = dgDS_DN.SelectedRows[0].Cells[1].Value.ToString();
            txtCSD_Nuoc.Text = dgDS_DN.SelectedRows[0].Cells[2].Value.ToString();
            txtCSC_Dien.Text = dgDS_DN.SelectedRows[0].Cells[3].Value.ToString();
            txtCSC_Nuoc.Text = dgDS_DN.SelectedRows[0].Cells[4].Value.ToString();
            dtp_NBT_DN.Text = dgDS_DN.SelectedRows[0].Cells[5].Value.ToString();
            dtp_NKT_DN.Text = dgDS_DN.SelectedRows[0].Cells[6].Value.ToString();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

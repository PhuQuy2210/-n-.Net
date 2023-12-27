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
    public partial class FrmPhongcs : Form
    {
        string ChuoiKN = "Data Source=LAPTOP-1170Q5GN\\MSSQLSERVER01;Initial Catalog=QLKTX;Integrated Security=True";
        SqlConnection conn;
        private void OpenSQL()
        {
            conn = new SqlConnection(ChuoiKN);
            conn.Open();
        }
        public FrmPhongcs()
        {
            InitializeComponent();
        }

        private void FrmPhongcs_Load(object sender, EventArgs e)
        {
            OpenSQL();
            LoaddataShow();
        }
        private void LoaddataShow()
        {
            string str_Open = @"select * from Phong";
            SqlDataAdapter adapter = new SqlDataAdapter(str_Open, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgDS_Phong.DataSource = dt;
        }

        private void txtDiaChi_SV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Phong_Click(object sender, EventArgs e)
        {
            FrmTrangChu f = new FrmTrangChu();
            f.Show();
            this.Close();
        }

        private void btnThem_Phong_Click(object sender, EventArgs e)
        {
            try
            {
                string str = @"insert into Phong values (@MaPhong,@Tang,@SucChua, @LoaiPhong, @TrangThaiPhong)";
                if (txtMaPhong_Phong.Text == "" || txtTang_Phong.Text == "" || (radioChuaday.Checked == false && radioDay.Checked == false) ||
                    (radMLanh_Phong.Checked == false && radMQuat_Phong.Checked == false) || (radSC4_Phong.Checked == false && radSC6_Phong.Checked == false))

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
                            
                            command.Parameters.AddWithValue("@MaPhong", txtMaPhong_Phong.Text);
                            command.Parameters.AddWithValue("@Tang", txtTang_Phong.Text);
                            if (radioChuaday.Checked)
                            {
                                command.Parameters.AddWithValue("@TrangThaiPhong", radioChuaday.Text);
                            }
                            else if(radioDay.Checked)
                            {
                                command.Parameters.AddWithValue("@TrangThaiPhong", radioDay.Text);
                            }
                            else
                            {
                                MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                            }

                            if (radMLanh_Phong.Checked)
                            {
                                command.Parameters.AddWithValue("@LoaiPhong", radMLanh_Phong.Text);
                            }
                            else if (radMQuat_Phong.Checked)
                            {
                                command.Parameters.AddWithValue("@LoaiPhong", radMQuat_Phong.Text);
                            }
                            else
                            {
                                MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                            }

                            if (radSC4_Phong.Checked)
                            {
                                command.Parameters.AddWithValue("@SucChua", int.Parse(radSC4_Phong.Text));
                            }
                            else if (radSC6_Phong.Checked)
                            {
                                command.Parameters.AddWithValue("@SucChua", int.Parse(radSC6_Phong.Text));
                            }
                            else
                            {
                                MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                            }
                            command.ExecuteNonQuery();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                LoaddataShow();
            
        }

        private void btnXoa_Phong_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dgDS_Phong.SelectedRows)
            {
                if (!i.IsNewRow)
                {
                    string str_MaPhong = dgDS_Phong.SelectedRows[0].Cells["Maphong"].Value.ToString();
                    string str = @"delete from Phong where MaPhong = @MaPhong";
                    using (SqlCommand command = new SqlCommand(str, conn))
                    {
                        command.Parameters.AddWithValue("@Maphong", txtMaPhong_Phong.Text);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Xóa lỗi", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    dgDS_Phong.Rows.RemoveAt(dgDS_Phong.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Chưa chọn dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSua_Phong_Click(object sender, EventArgs e)
        {
            string str = string.Format(@"UPDATE Phong SET Tang=@Tang, TrangThaiPhong=@TrangThaiPhong, LoaiPhong=@LoaiPhong, SucChua=@SucChua where MaPhong='{0}'", txtMaPhong_Phong.Text);
            using (SqlConnection connection = new SqlConnection(ChuoiKN))
            {
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Tang", txtTang_Phong.Text);
                    if (radioChuaday.Checked)
                    {
                        command.Parameters.AddWithValue("@TrangThaiPhong", radioChuaday.Text);
                    }
                    else if (radioDay.Checked)
                    {
                        command.Parameters.AddWithValue("@TrangThaiPhong", radioDay.Text);
                    }
                    else
                    {
                        MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                    }

                    if (radMLanh_Phong.Checked)
                    {
                        command.Parameters.AddWithValue("@LoaiPhong", radMLanh_Phong.Text);
                    }
                    else if (radMQuat_Phong.Checked)
                    {
                        command.Parameters.AddWithValue("@LoaiPhong", radMQuat_Phong.Text);
                    }
                    else
                    {
                        MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                    }

                    if (radSC4_Phong.Checked)
                    {
                        command.Parameters.AddWithValue("@SucChua", int.Parse(radSC4_Phong.Text));
                    }
                    else if (radSC6_Phong.Checked)
                    {
                        command.Parameters.AddWithValue("@SucChua", int.Parse(radSC6_Phong.Text));
                    }
                    else
                    {
                        MessageBox.Show("Không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                    }

                    //command.ExecuteNonQuery();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    LoaddataShow();
                }
            }
        }

        private void btnHuy_Phong_Click(object sender, EventArgs e)
        {
            txtMaPhong_Phong.Clear();
            txtTang_Phong.Clear();
            radMLanh_Phong.Enabled= false;
            radMQuat_Phong.Enabled = false;
            radioChuaday.Enabled = false;
            radioDay.Enabled = false;
            radSC4_Phong.Enabled = false;
            radSC6_Phong.Enabled = false;
        }

        private void btFind_Phong_Click(object sender, EventArgs e)
        {
            try
            {
                string str_Tim = @"select * from Phong where MaPhong like '" + txtTKiem_Phong.Text + "%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(str_Tim, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgDS_Phong.DataSource = dataTable;
            }
            catch { MessageBox.Show("Hãy nhập mã số nhân viên cần tìm", "Thông báo", MessageBoxButtons.OK); }
        }

        private void dgDS_Phong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgDS_Phong_Click(object sender, EventArgs e)
        {
            txtMaPhong_Phong.Text = dgDS_Phong.SelectedRows[0].Cells[0].Value.ToString();
            txtTang_Phong.Text = dgDS_Phong.SelectedRows[0].Cells[1].Value.ToString();
            string sucChua = dgDS_Phong.SelectedRows[0].Cells[2].Value.ToString();
            if (sucChua.Equals("4"))
                radSC4_Phong.Checked = true;
            else radSC6_Phong.Checked = true;
            string loaiPhong = dgDS_Phong.SelectedRows[0].Cells[3].Value.ToString();
            if(loaiPhong.Equals("Quạt"))
                radMQuat_Phong.Checked = true;
            else radMLanh_Phong.Checked = true;

            string trangThaiPhong = dgDS_Phong.SelectedRows[0].Cells[4].Value.ToString();
            if (trangThaiPhong.Equals("Đầy"))
                radioDay.Checked = true;
            else
                radioChuaday.Checked = true;
        }
    }
}

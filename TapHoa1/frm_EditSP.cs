using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TapHoa1
{
    public partial class frm_EditSP : Form
    {
        public frm_EditSP()
        {
            InitializeComponent();
        }
        LopDungChung lopchung = new LopDungChung();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_EditSP_Load(object sender, EventArgs e)
        {
            string sqldm = "Select * from DanhMuc";
            cbDanhMuc.DataSource = lopchung.LoadDL(sqldm);
            cbDanhMuc.ValueMember = "Id_danhmuc";
            cbDanhMuc.DisplayMember = "TenDanhMuc";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                object dem = lopchung.LayGT("select count (Id_sanpham) from SanPham where Id_sanpham='" + txtID.Text + "'");
                if ((int)dem == 1)
                {
                    string sqlupdate = "update SanPham set TenSanPham='" + txtTen.Text + "',Id_danhmuc='" + cbDanhMuc.SelectedValue +
                        "',GiaTien='" + txtGiaTien.Text + "',SoLuong='" + txtSoLuong.Text + "' where Id_sanpham='"+txtID.Text+"'";
                    int kq = lopchung.ThemXoaSua(sqlupdate);
                    if (kq >= 1) MessageBox.Show("Cập nhật sản phẩm thành công");
                    else MessageBox.Show("Cập nhật sản phẩm thất bại");
                }
                else if ((int)dem == 0)
                {
                    string sqlinsert = "Insert into SanPham values ('" + txtID.Text + "','" + cbDanhMuc.SelectedValue + "','" + txtTen.Text +
                    "','"  + txtGiaTien.Text + "','" + txtSoLuong.Text + "')";
                    int kq = lopchung.ThemXoaSua(sqlinsert);
                    if (kq >= 1) MessageBox.Show("Thêm sản phẩm thành công");
                    else MessageBox.Show("Thêm sản phẩm thất bại");
                }  
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn thật sự có muốn thoát hay không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

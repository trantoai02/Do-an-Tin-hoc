using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDS_HOCSINH.DTO;
using QLDS_HOCSINH.BUS;

namespace QLDS_HOCSINH.GUI
{
    
    public partial class DSHocSinhGUI : Form
    {
        HocSinhDTO hsDTO;//= new HocSinhDTO();
        HocSinhDTO[] dsHocSinh = new HocSinhDTO[50];
        HocSinhBus hsBUS = new HocSinhBus();
        string fileGhiHocSinh = @"E:\hocOnline\Do an TINHOC\Đồ án Tin Học\QLDS_HOCSINH\DanhSachHocSinh.txt";
        public DSHocSinhGUI()
        {
            InitializeComponent();
          
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            //thong tin hoc sinh
            if(hsBUS.TimMaHS(dsHocSinh, txtMSHS.Text) != -1)
            {
                MessageBox.Show("Mã số của mỗi học sinh là duy nhất. Mời nhập lại!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                HocSinhDTO hs = new HocSinhDTO(); //iSoLuong =1
                int sl = hsBUS.TotalLines(fileGhiHocSinh); //sl = 0
                hs.MSHS = txtMSHS.Text;
                hs.HoVaTen = txtHoTen.Text;
                hs.GioiTinh = cmbGT.Text;
                hs.NamSinh = txtNamSinh.Text;
                hs.DiemTB = Convert.ToSingle(txtDTB.Text); // chuyen string sang float
                //hs.XepLoai = txtXepLoai.Text;

                if (sl == 0)
                {
                    dsHocSinh[HocSinhDTO.iSoLuongHS - 1] = hs;

                }
                else if (sl > 0)
                {
                        dsHocSinh[sl] = hs;
                }
            }
            //dataGridView
            List<HocSinhDTO> list = new List<HocSinhDTO>();
            for (int i = 0; i < HocSinhDTO.iSoLuongHS; i++)
            {
                list.Add(dsHocSinh[i]);
            }
            dgvDSHS.DataSource = list;
            //ghi vao file
            hsBUS.GhiFile_ThemHocSinh(fileGhiHocSinh, dsHocSinh);
        }
        private void DSHocSinhGUI_Load(object sender, EventArgs e)
        {
            hsBUS.DocFile_ThongTinHocSinh(fileGhiHocSinh, dsHocSinh);
            List<HocSinhDTO> list = new List<HocSinhDTO>();
            int sl = hsBUS.TotalLines(fileGhiHocSinh);
            for (int i = 0; i < sl; i++)
            {
                list.Add(dsHocSinh[i]);
            }
            dgvDSHS.DataSource = list;
            dgvDSHS.ClearSelection();
           // MessageBox.Show(HocSinhDTO.iSoLuongHS.ToString());
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn tệp";
            openFile.InitialDirectory = @"C:\";
            openFile.Filter = "Image Files(*.png;*.jpg;*.ico)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.ShowDialog();
            if(openFile.FileName != "")
            {
                picAvatar.Image = Image.FromFile(openFile.FileName);
                lbNgang.Visible = false;
                lbDoc.Visible = false;
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            btnXong.Visible = true;
            btnThem.Visible = true;
            btnXoa.Visible = true;
            btnChinhSua.Visible = false;
            txtMSHS.ReadOnly = false;
            txtHoTen.ReadOnly = false;
            txtNamSinh.ReadOnly = false;
            txtDTB.ReadOnly = false;
            txtGT.Visible = false;
            picAvatar.Enabled = true;
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            btnChinhSua.Visible = true;
            btnXong.Visible = false;
            btnThem.Visible = false;
            btnXoa.Visible = false;
            txtMSHS.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtNamSinh.ReadOnly = true;
            txtDTB.ReadOnly = true;
            txtGT.Visible = true;
            picAvatar.Enabled = false;
        }

        private void dgvDSHS_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("clicked");
            txtMSHS.Text = dgvDSHS.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dgvDSHS.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbGT.Text = dgvDSHS.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNamSinh.Text = dgvDSHS.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDTB.Text = dgvDSHS.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDS_HOCSINH.DTO
{
    class HocSinhDTO
    {
        public static int iSoLuongHS=0;
        //private string sTenLop;
        private string sMSHS;
        private string sHoVaTen;
        private string sGioiTinh;
        private string sNamSinh;
        private float fDiemTB;
        private string sXepLoai;

        public HocSinhDTO()
        {
          //  string sTenLop = "";
            string sMSHS = "";
            string sHoVaTen = "";
            string sGioiTinh = "";
            string sNamSinh = "";
            float fDiemTB = 0;

            iSoLuongHS++;
        }

        public HocSinhDTO(string TenLop, string MSHS, string HoVaTen, string GioiTinh, float DiemTB)
        {
            sMSHS = MSHS;
            sHoVaTen = HoVaTen;
            sGioiTinh = GioiTinh;
            fDiemTB = DiemTB;

            iSoLuongHS++;
        }

        public string MSHS
        {
            get { return sMSHS; }
            set { sMSHS = value; }
        }
        public string HoVaTen
        {
            get { return sHoVaTen; }
            set { sHoVaTen = value; }
        }
        public string GioiTinh
        {
            get { return sGioiTinh; }
            set { sGioiTinh = value; }
        }
        public string NamSinh
        {
            get { return sNamSinh; }
            set{ sNamSinh = value; }
        }
        public float DiemTB
        {
            get { return fDiemTB; }
            set { fDiemTB = value; }
        }
        public string XepLoai
        {
            get { return sXepLoai; }
            set { sXepLoai = value; }
        }
    }
}

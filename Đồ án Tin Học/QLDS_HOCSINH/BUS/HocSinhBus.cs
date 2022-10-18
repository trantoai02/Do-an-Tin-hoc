using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDS_HOCSINH.DTO;
using QLDS_HOCSINH.GUI;
using System.IO;

namespace QLDS_HOCSINH.BUS
{
    class HocSinhBus
    {
        //private static HocSinhBus instance;
        //private String _fileName;
        //public String FileName
        //{
        //    get { return _fileName; }
        //    set { _fileName = value; }
        //}

        //public static HocSinhBus Instance 
        //{
        //    get { if (instance == null) instance = new HocSinhBus();
        //        return HocSinhBus.instance;
        //    }
        //    private set
        //    {
        //        HocSinhBus.instance = value;
        //    }
        //}
     
        

        System.IO.FileStream fs;
        //ghi xuong file
        public void GhiFile_ThemHocSinh(string fileName, HocSinhDTO[] ds)
        {
            if (ds != null)
            {
                fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                StreamWriter sw = new StreamWriter(fs);
                for (int i = 0; i < HocSinhDTO.iSoLuongHS; i++)
                {
                    sw.WriteLine(ds[i].MSHS + "," + ds[i].HoVaTen + "," + ds[i].GioiTinh + "," + ds[i].NamSinh + "," + ds[i].DiemTB + "," + ds[i].XepLoai);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
           

        }

        //lay du lieu tu file len
        public void DocFile_ThongTinHocSinh(string fileName, HocSinhDTO[] ds)
        {
            int sl = TotalLines(fileName);
            fs = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs);
            string str;
            
            for (int i = 0; i < sl; i++)
            {//
                string[] thuoctinh = new string[6];
                int k = 0;
                str = sr.ReadLine();
                
                //them 6 truong vao 6 pt  mang
                for(int j = 0; j < 6; j++)
                {
                    for (; k < str.Length; k++)
                    {
                        if (str[k] != ',')
                        {
                            thuoctinh[j] += str[k];
                        }
                        else
                        {
                            k++;
                            break;
                        }
                    }
                }
                //them 6 pt mang vao 6 thuoc tinh cua hoc sinh

                HocSinhDTO hs = new HocSinhDTO();
                ds[i] = hs;
                hs.MSHS = thuoctinh[0];
                hs.HoVaTen = thuoctinh[1];
                hs.GioiTinh = thuoctinh[2];
                hs.NamSinh = thuoctinh[3];
                hs.DiemTB = Convert.ToSingle(thuoctinh[4]);
                hs.XepLoai = thuoctinh[5];

            }
            sr.Close();
            fs.Close();
            
        }
        public int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }

        public bool IsEmpty(string fileName)
        {
            if (TotalLines(fileName) == 0)
                return true;
            return false;

        }


        public int TimMaHS(HocSinhDTO[] ds, string ma)
        {
            for (int i = 0; i < HocSinhDTO.iSoLuongHS; i++)
            {
                if(ds[i].MSHS == ma)
                {
                    return i;
                }
            }
            return -1;
        }

        public void SapXepDanhSach()
        {

        }


    }
}

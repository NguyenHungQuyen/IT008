using QuanLySinhVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Class
    {
        public string MALOP { get; set; }
        public string Ten { get; set; }
        public int Siso { get; set; }
        public Class()
        {
            MALOP = "";
            Ten = "";
            Siso = 0;
        }

        public Class(Class classs)
        {
            MALOP = classs.MALOP;
            Siso = classs.Siso;
            Ten = classs.Ten;

        }

        public Class(string MALOP, string ten, int SISO)
        {
            this.MALOP = MALOP;
            this.Ten = ten;
            this.Siso = SISO;
        }

        public Class(string malop)
        {
            MALOP = malop;
            Siso = 0;
            Ten = "";
        }

     /*  public void SaoChep(Class classs)
        {
            this.Ten = classs.Ten;
            this.Lop = classs.Lop;
            this.DTB = classs.DTB;
        }*/

        public string toString()
        {
            string kq = "";
            kq = MALOP + "-" + Ten + "-" + Siso.ToString();
            return kq;
        }

    }
}

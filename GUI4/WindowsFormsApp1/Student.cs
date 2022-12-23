using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    internal class Student
    {
        public string MSSV { get; set; }
        public string Ten { get; set; }
        public string Lop { get; set; }
        public double DTB { get; set; }
        public Student()
        {
            MSSV = "";
            Ten = "";
            Lop = "";
            DTB = 0;
        }

        public Student(Student student)
        {
            MSSV = student.MSSV;
            Ten = student.Ten;
            Lop = student.Lop;
            DTB = student.DTB;

        }

        public Student(string mSSV, string ten, string lop, double dTB)
        {
            MSSV = mSSV;
            Ten = ten;
            Lop = lop;
            DTB = dTB;
        }

        public Student(string mSSV)
        {
            MSSV = mSSV;
            Ten = "";
            Lop = "";
            DTB = 0;
        }

        public void SaoChep(Student student)
        {
            this.Ten = student.Ten;
            this.Lop = student.Lop;
            this.DTB = student.DTB;
        }

        public string toString()
        {
            string kq = "";
            kq = MSSV + "-" + Ten + "-" + Lop + "-" + DTB.ToString();
            return kq;
        }

        
    }
}

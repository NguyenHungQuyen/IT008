using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    internal class FileStoreStudent
    {
        private string path;
        public FileStoreStudent()
        {
            path = null;
        }

      

        public FileStoreStudent(string path)
        {
            this.path = path;
        }

        public void Luu(string s, Student st)
        {
            string[] detail = s.Split('-');
            st.MSSV = detail[0];
            st.Ten = detail[1];
            st.Lop = detail[2];
            st.DTB = Convert.ToDouble(detail[3]);
        }

        public List<Student> ReadFile()
        {
            List<Student> kq = new List<Student>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream == false)
                {
                    Student sv = new Student();

                    string line = sr.ReadLine();
                    Luu(line, sv);
                    kq.Add(sv);
                }
            }
            return kq;
        }

        public void WriteFile(Student st)
        {
            string s = st.toString();
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(s);
                sw.Close();
            }

        }
        public void WriteFile(Student st, int i)
        {
            string s = st.toString();
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(s);
                sw.Close();
            }

        }
    }
}

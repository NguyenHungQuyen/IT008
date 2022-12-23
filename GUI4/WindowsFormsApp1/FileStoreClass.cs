using QuanLySinhVien;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class FileStoreClass
    {
        private string path;
        public FileStoreClass()
        {
            path = null;
        }



        public FileStoreClass(string path)
        {
            this.path = path;
        }

        public void Luu(string s, Class cl)
        {
            string[] detail = s.Split('-');
            cl.MALOP = detail[0];
            cl.Ten = detail[1];
            cl.Siso =Convert.ToInt16( detail[2]);
        }

        public List<Class> ReadFile()
        {
            List<Class> kq = new List<Class>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream == false)
                {
                    Class sv = new Class();

                    string line = sr.ReadLine();
                    Luu(line, sv);
                    kq.Add(sv);
                }
            }
            return kq;
        }

        public void WriteFile(Class cl)
        {
            string s = cl.toString();
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(s);
                sw.Close();
            }

        }
        public void WriteFile(Class cl, int i)
        {
            string s = cl.toString();
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(s);
                sw.Close();
            }

        }
    }
}

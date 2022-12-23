using QuanLySinhVien;
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

namespace WindowsFormsApp1
{
    public partial class Form_Add_Student : Form
    {
        public Form_Add_Student()
        {
            InitializeComponent();
            List<Student> students = new List<Student>();
            FileStoreClass fileStoreClass=new FileStoreClass("DSLopChon.txt");
            List<Class> classes= fileStoreClass.ReadFile();
            Class cl = classes[0];
            this.textBox3.Text = cl.MALOP;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();
                string s = "";
                string[] ss = new string[10];
                s = this.textBox1.Text;
                ss[0] = s;
                s = this.textBox2.Text;
                ss[1] = s;
                s = this.textBox3.Text;
                ss[2] = s;
                s = this.textBox4.Text;
                ss[3] = s;
                string queryString = "";
                queryString = "INSERT INTO dbo.SINHVIEN  (TEN,MALOP,DTB,MASV ) VALUES (N'{0}','{1}',{2},'{3}')";
                queryString = string.Format(queryString, ss[1], ss[2], ss[3], ss[0]);
                Console.WriteLine(queryString);
                string sss = "";
                sss = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(sss);
              //  SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-RUGI22K\\SQLEXPRESS;Initial Catalog=QuanLyLopHoc;" + "Integrated Security=true;");
                sqlcon.Open();
                SqlCommand sql_cmd = new SqlCommand(queryString, sqlcon);
                sql_cmd.ExecuteNonQuery();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

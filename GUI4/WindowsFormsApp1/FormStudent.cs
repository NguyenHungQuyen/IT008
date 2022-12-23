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
    public partial class FormStudent : Form
    {
        List<Student> students = new List<Student>();
        SQL sQL = new SQL();
        string connectionString;
        public FormStudent()
        {
            InitializeComponent();
            string s = "";
            FileStoreClass fileStoreClass = new FileStoreClass("DSLopChon.txt");
            List<Class> classes = new List<Class>();
            classes = fileStoreClass.ReadFile();
            Class cl = new Class();
            cl = classes[0];
            s = cl.MALOP;

      //      connectionString = "Data Source=DESKTOP-RUGI22K\\SQLEXPRESS;Initial Catalog=QuanLyLopHoc;" + "Integrated Security=true;";
            string queryString = "SELECT * FROM dbo.SINHVIEN where MALOP='{0}';";
            queryString = String.Format(queryString, s);
            string sss = "";
            sss = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            connectionString = sss;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            while (reader.Read())
                {
                    Student student = new Student();
                    string x = "";
                string[] ss = new string[10];
                x = reader[0].ToString();
                student.MSSV = x;
                ss[0] = x;

                    x = reader[1].ToString();
                student.Ten = x;
                ss[1] = x;

                    x = reader[2].ToString();
                student.Lop = x;
                ss[2] = x;
                    x = reader[3].ToString();
                    double d = 0;
                    d = Convert.ToDouble(x);
                    student.DTB = d;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = student.MSSV;
                row.Cells[1].Value = student.Ten;
                row.Cells[2].Value = student.Lop;
                row.Cells[3].Value = student.DTB;
                rows.Add(row);
                students.Add(student);
                }
            DataGridViewRow[] viewRows;
            viewRows = rows.ToArray();
            this.dataGridView1.Rows.AddRange(viewRows);

            // this.dataGridView1.DataSource = students;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int n = 0;
                DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection;
                dataGridViewSelectedRowCollection = this.dataGridView1.SelectedRows;
                
                n = dataGridViewSelectedRowCollection.Count;
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow = dataGridViewSelectedRowCollection[0];

                //if (dataGridViewRow.Index == n)                    return;
                if (n !=1 )
                    return;

                DataGridViewCellCollection dataGridViewCellCollection;
                dataGridViewCellCollection = dataGridViewRow.Cells;

                Student student = new Student();
                string s = "";
                s = dataGridViewCellCollection[0].Value.ToString();
                student.MSSV = s;

                s = dataGridViewCellCollection[1].Value.ToString();
                student.Ten = s;

                s = dataGridViewCellCollection[2].Value.ToString();
                student.Lop = s;

                s = dataGridViewCellCollection[3].Value.ToString();
                student.DTB = Convert.ToDouble(s);

                FileStoreStudent fileStoreStudent = new FileStoreStudent("DSSVChon.txt");
                fileStoreStudent.WriteFile(student, 0);

                Form_Edit_Student form_Edit_Student = new Form_Edit_Student();
                form_Edit_Student.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (res == DialogResult.Cancel)
                    return;
                int n = 0;
                DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection;
                dataGridViewSelectedRowCollection = this.dataGridView1.SelectedRows;

                n = dataGridViewSelectedRowCollection.Count;
                if (n != 1)
                    return;
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow = dataGridViewSelectedRowCollection[0];

                DataGridViewCellCollection dataGridViewCellCollection;
                dataGridViewCellCollection = dataGridViewRow.Cells;

                Student student = new Student();
                string s = "";
                s = dataGridViewCellCollection[0].Value.ToString();
                student.MSSV = s;

                s = dataGridViewCellCollection[1].Value.ToString();
                student.Ten = s;

                s = dataGridViewCellCollection[2].Value.ToString();
                student.Lop = s;

                s = dataGridViewCellCollection[3].Value.ToString();
                student.DTB = Convert.ToDouble(s);

                FileStoreStudent fileStoreStudent = new FileStoreStudent("DSSVChon.txt");
                fileStoreStudent.WriteFile(student, 0);

                s = dataGridViewCellCollection[0].Value.ToString();
                string queryString = "DELETE dbo.SINHVIEN  WHERE MASV='{0}'";
                queryString = string.Format(queryString, s);
                string sss = "";
                sss = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(sss);

//                SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-RUGI22K\\SQLEXPRESS;Initial Catalog=QuanLyLopHoc;" + "Integrated Security=true;");
                SqlCommand sql_cmd = new SqlCommand(queryString, sqlcon);
                sqlcon.Open();
                sql_cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Add_Student form_Add_Student = new Form_Add_Student();
            form_Add_Student.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                string s = "";
                FileStoreClass fileStoreClass = new FileStoreClass("DSLopChon.txt");
                List<Class> classes = new List<Class>();
                classes = fileStoreClass.ReadFile();
                Class cl = new Class();
                cl = classes[0];
                s = cl.MALOP;

               // connectionString = "Data Source=DESKTOP-RUGI22K\\SQLEXPRESS;Initial Catalog=QuanLyLopHoc;" + "Integrated Security=true;";
                string queryString = "SELECT * FROM dbo.SINHVIEN where MALOP='{0}';";
                queryString = String.Format(queryString, s);
                string sss = "";
                sss = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
                connectionString = sss;


                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<DataGridViewRow> rows = new List<DataGridViewRow>();


                while (reader.Read())
                {
                    Student student = new Student();
                    string x = "";
                    string[] ss = new string[10];
                    x = reader[0].ToString();
                    student.MSSV = x;
                    ss[0] = x;

                    x = reader[1].ToString();
                    student.Ten = x;
                    ss[1] = x;

                    x = reader[2].ToString();
                    student.Lop = x;
                    ss[2] = x;
                    x = reader[3].ToString();
                    double d = 0;
                    d = Convert.ToDouble(x);
                    student.DTB = d;
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = student.MSSV;
                    row.Cells[1].Value = student.Ten;
                    row.Cells[2].Value = student.Lop;
                    row.Cells[3].Value = student.DTB;
                    rows.Add(row);
                    students.Add(student);
                }

                this.dataGridView1.Rows.AddRange(rows.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox .Show(ex.Message);        
            }
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {

        }
    }
}

    
        
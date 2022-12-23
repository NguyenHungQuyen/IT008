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
    public partial class Form_Add_Class : Form
    {
        public Form_Add_Class()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                s = this.textBox2.Text;
                s = Encoding.UTF8.GetBytes(s).ToString();

                Class cl = new Class(this.textBox1.Text, this.textBox2.Text, Convert.ToInt32(this.textBox3.Text));
                string queryString = "insert INTO  dbo.LOP VALUES ('{0}',N'{1}',{2})  ";
                queryString = string.Format(queryString, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                Console.WriteLine(queryString);
                //string connectionString = "Data Source=DESKTOP-RUGI22K\\SQLEXPRESS;Initial Catalog=QuanLyLopHoc;"                + "Integrated Security=true;";
                string sss = "";
                sss = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(sss);
               // SqlConnection sqlcon = new SqlConnection(connectionString);
                SqlCommand sql_cmd = new SqlCommand(queryString, sqlcon);
                sqlcon.Open();
                sql_cmd.ExecuteNonQuery();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_Add_Class_Load(object sender, EventArgs e)
        {

        }
    }
}

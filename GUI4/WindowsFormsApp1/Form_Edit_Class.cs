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
    public partial class Form_Edit_Class : Form
    {
       
        public Form_Edit_Class()
        {
            InitializeComponent();

           

            Class cl = new Class();
            List<Class> classes = new List<Class>();
            FileStoreClass fileStoreClass = new FileStoreClass("DSLopChon.txt");

            string s = "";
            classes= fileStoreClass.ReadFile();
            cl = classes[0];
            s=cl.toString();

            string[] ss = s.Split('-');
            this.textBox1.Text= ss[0];
            this.textBox2.Text= ss[1];
            this.textBox3.Text= ss[2];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sss = "";
                sss = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
                
                SqlConnection connection = new SqlConnection(sss);
                string queryString ="UPDATE dbo.LOP SET TEN=N'{0}', SISO={1} WHERE MALOP='{2}'";
                queryString = string.Format(queryString, this.textBox2.Text, this.textBox3.Text, this.textBox1.Text);
                
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form_Edit_Class_Load(object sender, EventArgs e)
        {

        }
    }
}

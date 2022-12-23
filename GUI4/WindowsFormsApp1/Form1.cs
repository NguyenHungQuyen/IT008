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
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        SQL sQL = new SQL();
        public Form1()
        {
            InitializeComponent();
            string sss = "";
            sss = Program.connect;
            sss = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlConnection connection = new SqlConnection(sss);
            
            List<Class> classes = new List<Class>();
            string queryString = "SELECT MALOP,TEN,SISO FROM dbo.LOP;";
            SqlCommand command = new SqlCommand(queryString, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Class cl = new Class();
                string s = "";
                s = reader[0].ToString();
                cl.MALOP = s;
                s = reader[1].ToString();
                cl.Ten = s;
                s = reader[2].ToString();
                int n;
                n = Convert.ToInt32(s);
                cl.Siso = n;
                classes.Add(cl);

            } 

            int i = 0;
            List<ListViewItem> items = new List<ListViewItem>();
             while (i < classes.Count)
            {
                ListViewItem listViewItem = new ListViewItem();
                Class cl = new Class();
                cl = classes[i];
                string[] ss = new string[10];
                string s = "";

                s = cl.MALOP;
                ss[0] = s;

                s = cl.Ten; 
                ss[1] = s;

                int n;
                n = cl.Siso;
                s = n.ToString();
                ss[2] = s;


                ListViewItem item1 = new ListViewItem(new string[] { ss[0], ss[1], ss[2] });
                items.Add(item1);

                i++;
            }
            ListViewItem[] listViewItems = new ListViewItem[] { };
            listViewItems = items.ToArray();
            listView1.Items.AddRange(listViewItems);

        }
        private ListViewItem ConvertListtoLstItem(Class CL)
        {
            ListViewItem item1 = new ListViewItem(new string[] { CL.MALOP, CL.Ten, CL.Siso.ToString() });
            return item1;
        }
        private Class ConvertLstItemToList(ListViewItem item)
        {
            Class cl = new Class();
            string kq = "";
            kq = item.SubItems[0].Text;
            cl.MALOP = kq;

            kq = item.SubItems[1].Text;
            cl.Ten = kq;

            kq = item.SubItems[2].Text;
            cl.Siso = Convert.ToInt32(kq);

            return cl;
        }
        private void InitList(List<Class> Classes, ListView list)
        {

            foreach (Class cl in Classes)
            {

                ListViewItem listViewItem = new ListViewItem();
                listViewItem = ConvertListtoLstItem((Class)cl);
                list.Items.Add(listViewItem);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                
                int n = 0;
                ListView.SelectedListViewItemCollection selectedListViewItemCollection;
                selectedListViewItemCollection = this.listView1.SelectedItems;
                n = selectedListViewItemCollection.Count;
                if (n != 1)
                    return;
                ListViewItem listViewItem = selectedListViewItemCollection[0];
                Class cl = new Class();
                string s = "";
                s = listViewItem.SubItems[0].Text;
                cl.MALOP = s;

                s = listViewItem.SubItems[1].Text;
                cl.Ten = s;

                s = listViewItem.SubItems[2].Text;
                int m = 0;
                n = Convert.ToInt32(s);
                cl.Siso = m;

                FileStoreClass fileStoreClass = new FileStoreClass("DSLopChon.txt");
                fileStoreClass.WriteFile(cl, 0);
                Form_Edit_Class form_Edit_Class = new Form_Edit_Class();
                form_Edit_Class.ShowDialog();

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
                int n = 0;
                ListView.SelectedListViewItemCollection selectedListViewItemCollection;
                selectedListViewItemCollection = this.listView1.SelectedItems;
                n = selectedListViewItemCollection.Count;
                if (n != 1)
                    return;
                ListViewItem listViewItem = selectedListViewItemCollection[0];
                Class cl = new Class();
                string s = "";
            
                s = listViewItem.SubItems[0].Text;
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.Cancel)
                    return;
                string queryString ="DELETE dbo.LOP  WHERE MALOP='{0}'";
                queryString = string.Format(queryString, s);

                string sss = "";

                ConnectionStringSettings settings = new ConnectionStringSettings();
                settings = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"];
                sss=settings.ConnectionString;

                SqlConnection sqlcon = new SqlConnection(sss);
                SqlCommand sql_cmd = new SqlCommand(queryString, sqlcon);
                sqlcon.Open();
                sql_cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form_Add_Class form_Add_Class = new Form_Add_Class();
            form_Add_Class.ShowDialog();
            


        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                List<Class> classes = new List<Class>();
                string queryString = "SELECT MALOP,TEN,SISO FROM dbo.LOP;";
                string sss = "";
                sss = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
                SqlConnection connection = new SqlConnection(sss);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Class cl = new Class();
                    string s = "";
                    s = reader[0].ToString();
                    cl.MALOP = s;
                    s = reader[1].ToString();
                    cl.Ten = s;
                    s = reader[2].ToString();
                    int n;
                    n = Convert.ToInt32(s);
                    cl.Siso = n;
                    classes.Add(cl);

                }
                int i = 0;
                List<ListViewItem> items = new List<ListViewItem>();
                while (i < classes.Count)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    Class cl = new Class();
                    cl = classes[i];
                    string[] ss = new string[10];
                    string s = "";

                    s = cl.MALOP;
                    ss[0] = s;

                    s = cl.Ten;
                    ss[1] = s;

                    int n;
                    n = cl.Siso;
                    s = n.ToString();
                    ss[2] = s;


                    ListViewItem item1 = new ListViewItem(new string[] { ss[0], ss[1], ss[2] });
                    items.Add(item1);
                    i++;
                }
                ListViewItem[] listViewItems = new ListViewItem[] { };
                listViewItems = items.ToArray();
                listView1.Items.AddRange(listViewItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

                ListView.SelectedListViewItemCollection selectedListViewItemCollection;
                selectedListViewItemCollection = this.listView1.SelectedItems;
                int n = selectedListViewItemCollection.Count;
                if (n <= 0)
                    return;
                Class kq = ConvertLstItemToList(selectedListViewItemCollection[0]);
                FileStoreClass fileStoreClass = new FileStoreClass("DSLopChon.txt");
                fileStoreClass.WriteFile(kq, 0);
                FormStudent formStudent = new FormStudent();
                formStudent.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

      

           
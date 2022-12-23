using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class SQL
    {
       
        public string connectionString;
        public SQL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public SQL()
        {
            connectionString = "Data Source=DESKTOP-RUGI22K\\SQLEXPRESS;Initial Catalog=QuanLyLopHoc;"
                + "Integrated Security=true;";
        }
        public List<Class> ReadData()
        {
            List<Class> list = new List<Class>();

            string queryString =
                "SELECT MALOP,TEN,SISO FROM dbo.LOP;";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Class()
                        {
                            MALOP = reader[0].ToString(),
                            Ten = reader[1].ToString(),
                            Siso = Convert.ToInt16( reader[2].ToString()),
                        }); ;
                    }
                }
            }
           return list;
        }
        public int Upada(string sql)
        {
            int kq = 0;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    using (SqlCommand sql_cmd = new SqlCommand(sql, sqlcon))
                    {
                        sqlcon.Open();
                        kq= sql_cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return kq;
        }
        public DataTable GetDataTable(string sql)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds);
            return myds.Tables[0];
        }

        public void Insert(Class cl)
        {
            string s = cl.toString();
            string[] ss = s.Split('-');
            string queryString =
                "insert INTO  dbo.LOP VALUES ('{0}',N'{1}',{2})  ";
            queryString = string.Format(queryString, ss[0], ss[1], ss[2]);
            Console.WriteLine(queryString);
            Upada(queryString);
        }
        public void Update(Class cl)
        {
            string s=cl.toString();
            string[] ss = s.Split('-');
            string queryString =
                "UPDATE dbo.LOP SET TEN=N'{0}', SISO={1} WHERE MALOP='{2}'";
            queryString = string.Format(queryString, ss[1], ss[2], ss[0]);
            Console.WriteLine(queryString);
            Upada(queryString);
        }
        public void Delete(Class cl)
        {
            string s = cl.toString();
            string[] ss = s.Split('-');
            string queryString =
                "DELETE dbo.LOP  WHERE MALOP='{0}'";
            queryString = string.Format(queryString, ss[0]);
            Console.WriteLine(queryString);
            Upada(queryString);
        }

        public string FormatInsert(String queryString, string[] ss)
        {
            queryString = string.Format(queryString, ss[0], ss[1], ss[2]);
            return queryString;
        }
        public string FormatUpdate(String queryString, string[] ss)
        {
            queryString = string.Format(queryString, ss[1], ss[2], ss[0]);
            return queryString;
        }
        public string FormatDelete(String queryString, string[] ss)
        {
            queryString = string.Format(queryString, ss[1], ss[2], ss[0]);
            return queryString;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace CSharpLessonWeekTwoHW
{
    public class DBTool
    {
        public static DataTable readTable(string readtable ,string[] readcol)
        {
            string connectionString =
               "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ProjectImmediateReply; Integrated Security=true";
            //將接過來的陣列用「,」連接成一個字串
            string readcoladd = string.Join(",", readcol);
            //判斷接過來的readtable來決定那個表的排序方式
            string ordername = "";
            if (readtable == "Users")
            {
                ordername = "UserID";
            }
            else if (readtable == "Projects")
            {
                ordername = "ProjectID";
            }
            else if (readtable == "Works")
            {
                ordername = "WorkID";
            }
            else if (readtable == "Grades")
            {
                ordername = "UserID";
            }
            else
            {
                HttpContext.Current.Response.Write("請輸入正確資料表名稱");
            }
            //SQL語法參數化
            string queryString =
                $@" SELECT {readcoladd} FROM {readtable}
                    ORDER BY {ordername} ;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;

                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("" + ex);
                    return null;
                }
            }
        }
        public static void InsertTable(string readtable,string[] insertcol, string[] insertcolp, List<string> userinsert)
        {
            string connectionString =
                "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ProjectImmediateReply; Integrated Security=true";
            //將接過來的陣列用「,」連接成一個字串
            string insertcolum = string.Join(",", insertcol);
            string insertparameter = string.Join(",", insertcolp);
            string queryString = "";
            //將user輸入的集合轉為陣列
            string[] puserinsert = userinsert.ToArray(); 

            queryString =
               $@" INSERT INTO {readtable}
                         ({insertcolum})
                   VALUES
                         ({insertparameter})";
            //利用connection插入、修改
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    for (int i = 0; i < insertcolp.Length; i++)
                    {
                        command.Parameters.AddWithValue($"{insertcolp[i]}", puserinsert[i]);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("" + ex);
                }
            }
        }
        public static void UpdateTable(string readtable, string[] updatecol, string wherep,string[] updatecolp, List<string> userupdate)
        {
            string connectionString =
                "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ProjectImmediateReply; Integrated Security=true";
            //將接過來的陣列用「,」連接成一個字串
            string updatecolum = string.Join(",", updatecol);
            string queryString = "";
            //將user輸入的集合轉為陣列
            string[] puserupdate = userupdate.ToArray();

            queryString =
                $@"   UPDATE {readtable}
                        SET  {updatecolum}
                        WHERE {wherep} ";
          
            //利用connection插入、修改
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    for (int i = 0; i < updatecolp.Length; i++)
                    {
                        command.Parameters.AddWithValue($"{updatecolp[i]}", puserupdate[i]);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("" + ex);
                }
            }
        }
        public static void DeleteTable(string readtable,string target ,string targetp, string userdelete)
        {
            string connectionString =
                "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ProjectImmediateReply; Integrated Security=true";

            string queryString = $"DELETE FROM {readtable} WHERE {target} = {targetp}";
          
            ;

            //利用connection刪除
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue(targetp, userdelete);
                try
                {
                    connection.Open();
                    int totalchangeRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("" + ex);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DBAdapter
{
    class DB
    {
        static DB instance;

        static SqlConnection connection =  new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FootballBase.mdf;Integrated Security = True");//Егор;
        //static SqlConnection connection = new SqlConnection(@"Server=PC; DataBase=Foot; Integrated security = True");//Daria
        public DB()
        {

        }

        public static DB GetInstance()
        {
            if (instance == null)
                instance = new DB();
            return instance;
        }
        public static DataTable RunSelect(string zapros)
        {
            DataTable dt = new DataTable() ;
            try
            {
                SqlDataAdapter dataadapter = new SqlDataAdapter(zapros, connection);
                dt = new DataTable();
                connection.Open();
                dataadapter.Fill(dt);
                connection.Close();
            }
            catch(Exception eror)
            { string error = eror.Message; }
            return dt;
        }

        internal static bool CheckConnection()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch 
            {
                connection.Close();
                return false;
            }
        }

        public static bool RunInsert(string command)
        {

            SqlCommand cmd = new SqlCommand(command, connection);
            connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (InvalidOperationException)
            {
                connection.Close();
                return false;
            }
        }

        public static bool AddEntry(string[] values, string tableTitle) //false если не удалось добавить запись
        {
            string command = "insert into " + tableTitle + " values ('" + values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (i == values.Length - 1)
                    command += "','" + values[i] + "')";
                else
                    command += "','" + values[i];

            }
            return RunInsert(command);
        }
        public void RemoveEntry()
        {

        }

        public static DataTable SelectEntireTable(string tableName)
        {
            SqlCommand cmd = new SqlCommand("select * from " + tableName, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        internal static bool CheckIfLoginExists(string login)// "ПроверитьСуществуетЛиТакойЛогин true-существует/
        {
            if (RunSelect("Select * From Autorization where Login = '" + login + "'").Rows.Count == 0)
            { return false; }
            else
            {
                return true;
            }
        }
    }
}

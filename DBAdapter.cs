using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logics;
using System.Data.SqlClient;
using System.Data;

namespace DBAdapter
{
    class DB
    {
        static DB instance;

        SqlConnection connection;

        public DB()
        {
            connection = new SqlConnection("Data Source=DESKTOP-4E4QD9H;Initial Catalog=ProjectBank;Integrated Security=True");//Егор
        }

        public static DB GetInstance()
        {
            if (instance == null)
                instance = new DB();
            return instance;
        }
        public DataTable RunSelect(string zapros)
        {
            SqlDataAdapter dataadapter = new SqlDataAdapter(zapros, connection);
            DataTable dt = new DataTable();
            connection.Open();
            dataadapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public bool RunInsert(string command)
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

        public bool AddEntry(string[] values, string tableTitle) //false если не удалось добавить запись
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

        public DataTable SelectEntireTable(string tableName)
        {
            SqlCommand cmd = new SqlCommand("select * from " + tableName, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        internal bool CheckIfLoginExists(string login)// "ПроверитьСуществуетЛиТакойЛогин true-существует/
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

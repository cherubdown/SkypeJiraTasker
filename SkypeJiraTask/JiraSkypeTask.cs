using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkypeJiraTask
{
    public class JiraSkypeTask : ITask
    {
        private string[] Args;

        public void Run(string[] args)
        {
            Args = args;
            Init();
        }
        private void Init()
        {
            Console.WriteLine("Initalizing...");

            //var skypeBaseFolder = @"%AppData%\Skype\cbales-curse\";
            var skypeBaseFolder = @"C:\Users\Valued Customer\AppData\Roaming\Skype\cbales-curse\";
            var dbName = "main.db";
            var connectionString = string.Format("Data Source={0};Journal Mode=Off;", skypeBaseFolder + dbName);

            string query =  "select * from Messages " +
                            "order by timestamp desc limit 1;";

            using(SQLiteConnection dbConn = new SQLiteConnection(connectionString, true))
            {
                dbConn.Open();
                SQLiteCommand command = new SQLiteCommand(query, dbConn);
                SQLiteDataReader resultReader = command.ExecuteReader();

                while (resultReader.Read())
                {
                    Console.WriteLine(resultReader["body_xml"]);
                }
                dbConn.Close();
            }
        }
    }
}

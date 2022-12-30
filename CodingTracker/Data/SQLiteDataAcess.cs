using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.Sqlite;
using CodingTracker.Interface;
using CodingTracker.Models;
using CodingTracker.StaticHelper;
namespace CodingTracker.Data
{
    public class SQLiteDataAcess : IDataAccess
    {

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public void CreateDB()
        {
            using (var connection = new SqliteConnection(LoadConnectionString("Default")))
            {
                //create a new databse if one does not exist 
                connection.Open();
                var table = connection.CreateCommand();
                table.CommandText = @"CREATE TABLE IF NOT EXISTS codeSessions(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                StartTime TEXT,
                EndTime TEXT,
                Duration TEXT)";
                table.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void InsertData(DateTime startTime, DateTime endTime, TimeSpan duration)
        {
            using (var connection = new SqliteConnection(LoadConnectionString("Default")))
            {
                connection.Open();
                var input = connection.CreateCommand();
                input.CommandText = $"INSERT INTO codeSessions(StartTime, EndTime, Duration) VALUES ('{startTime.ToString()}', '{endTime.ToString()}', '{duration.ToString()}')";
                try
                {
                    input.ExecuteNonQuery();
                    Console.WriteLine("Data Inserted successfully");
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Data not Inserted");
                    Console.WriteLine(e);
                    connection.Close();
                }
            }
        }

        public void DeleteData(int Id)
        {
            using (var connection = new SqliteConnection(LoadConnectionString("Default")))
            {
                connection.Open();
                var input = connection.CreateCommand();
                input.CommandText = $"DELETE FROM codeSessions WHERE Id == {Id}";

                int count = input.ExecuteNonQuery();
                //if the id does not equal anithing in data base then deletion failed
                if (count == 0) Console.WriteLine($"\nRecord with id:{Id} does not exist");
                else Console.WriteLine($"\ncode session {Id} has been deleted successfully");
                connection.Close();
            }
        }

        public List<CodingSession> LoadData()
        {
            using (var connection = new SqliteConnection(LoadConnectionString("Default")))
            {
                connection.Open();
                var output = connection.CreateCommand();
                output.CommandText = "SELECT * FROM codeSessions";
                List<CodingSession> sessionsTable = new();
                SqliteDataReader reader = output.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        DateTime startDate = DateTime.Parse(reader.GetString(1));
                        DateTime endDate = DateTime.Parse(reader.GetString(2));
                        TimeSpan duration = reader.GetTimeSpan(3);
                        sessionsTable.Add(new CodingSession(Id, startDate, endDate, duration));
                    }
                }
                else
                {
                    StaticMessages.EmptyTableMessage();
                    connection.Close();
                }
                connection.Close();
                return sessionsTable;
            }
        }


    }
}

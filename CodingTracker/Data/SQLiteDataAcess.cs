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
                input.CommandText = $"INSERT INTO codeSessions(StartTime, EndTime, Duration) VALUES ('{startTime.ToString()}', '{endTime.ToString()}', '{duration.ToString(@"hh\:mm\:ss")}')"; // ensure that stopwatch time span is correct format when inserted
                try
                {
                    input.ExecuteNonQuery();
                    Console.WriteLine("\nData Inserted successfully");
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nData not Inserted");
                    Console.WriteLine(e);
                    connection.Close();
                }
            }
        }

        public void DeleteData(int Id)
        {
            using (var connection = new SqliteConnection(LoadConnectionString("Default")))
            {
                try
                {
                    connection.Open();
                    var input = connection.CreateCommand();
                    input.CommandText = $"DELETE FROM codeSessions WHERE Id == {Id}";
                    int count = input.ExecuteNonQuery();
                    //if the id does not equal anything in data base then deletion failed
                    if (count == 0) StaticMessages.IdErrorMessage(Id);
                    else Console.WriteLine($"\ncode session {Id} has been deleted successfully");

                    connection.Close();
                } 
                catch (Exception e) 
                {
                    StaticMessages.OperationErrorMessage();
                    Console.WriteLine(e);
                }

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


        public void UpdateData(int Id, UserInput userInput)
        {
            using (var connection = new SqliteConnection(LoadConnectionString("Default")))
            {
                connection.Open();
                var check = connection.CreateCommand();
                check.CommandText = $"SELECT * FROM codeSessions WHERE Id == {Id}";
                int checkID = Convert.ToInt32(check.ExecuteScalar());
                try
                {
                    if (checkID != 0)
                    {
                        StaticMessages.StartDateMessage();
                        DateTime startTime = userInput.EnterDateTime();

                        StaticMessages.EndTimeMessage();
                        DateTime endTime = userInput.EndTime(startTime);

                        TimeSpan duration = endTime - startTime;

                        var update = connection.CreateCommand();
                        update.CommandText = $"UPDATE codeSessions SET StartTime = '{startTime}', EndTime = '{startTime}', Duration = '{duration}' WHERE Id == {Id}";
                        update.ExecuteNonQuery();
                        Console.WriteLine($"\nCode Session with {Id} was successfuly updated");
                        connection.Close();
                    }
                    else
                        StaticMessages.IdErrorMessage(Id);

                } catch(Exception e)
                {
                    StaticMessages.OperationErrorMessage();
                    Console.WriteLine(e);
                }
            }
        }

    }
}

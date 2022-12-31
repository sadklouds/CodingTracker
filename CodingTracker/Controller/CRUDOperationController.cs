using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTracker.Data;
using CodingTracker.Interface;
using CodingTracker.StaticHelper;
using ConsoleTableExt;

namespace CodingTracker.Controller
{
    public class CRUDOperationController
    {
        private UserInput userInput = new();

        // inserts entry in data base after all input validation is correct
        public void CreateManualCodeSession(IDataAccess db)
        {
            StaticMessages.StartDateMessage();
            DateTime startTime = userInput.EnterDateTime();

            StaticMessages.EndTimeMessage();
            DateTime endTime = userInput.EndTime(startTime);

            TimeSpan duration = endTime - startTime;

            db.InsertData(startTime, endTime, duration);
        }

        // outputs a table with the database record data
        public void CodingSessionsTable(IDataAccess db)
        {
            var sessions = db.LoadData();
            ConsoleTableBuilder
            .From(sessions)
            .ExportAndWriteLine();
        }

        public void DeleteCodeSession(IDataAccess db)
        {
            StaticMessages.EnterIdMessage();
            int id = userInput.UserIntInput();
            db.DeleteData(id);
        }


        // acts as an automatic way to time and insert a coding session
        public void StopWatch(IDataAccess db)
        {
            DateTime startTime = DateTime.Now;
            string input;
            do
            {
                Console.Write("\nYour coding session is now being tracked, type 'Stop' to finish: ");
                input = userInput.UserInputString();
            } while (input.ToLower() != "stop") ;
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            db.InsertData(startTime, endTime, duration);
        }

        public void UpdateCodeSession(IDataAccess db)
        {
            StaticMessages.EnterIdMessage();
            int id = userInput.UserIntInput();
            db.UpdateData(id,  userInput);
            
        }
    }
}

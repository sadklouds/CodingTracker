using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTracker.Data;
using CodingTracker.Interface;
using CodingTracker.StaticHelper;
using ConsoleTableExt;

namespace CodingTracker.Logic
{
    public class CRUDOperations
    {
        private UserInput userInput = new();

        public void CreateCodeSession(IDataAccess db)
        {
            StaticMessages.StartDateMessage();
            DateTime startTime = userInput.EnterDateTime();

            StaticMessages.EndTimeMessage();
            DateTime endTime = userInput.EndTime(startTime);

            TimeSpan duration = endTime - startTime;

            db.InsertData(startTime, endTime, duration);
        }

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

    }
}

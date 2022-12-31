using CodingTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTracker.Data;

namespace CodingTracker.Interface
{
    public interface IDataAccess
    {
        public void CreateDB();

        public void InsertData(DateTime startTime, DateTime endTime, TimeSpan duration);

        public List<CodingSession> LoadData();

        public void DeleteData(int Id);

        public void UpdateData(int Id, UserInput userInput);

    }
}

using CodingTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Interface
{
    public interface IDataAccess
    {
        public void CreateDB();

        public void InsertData(DateTime startTime, DateTime endTime, TimeSpan duration);

        public List<CodingSession> LoadData();

        public void DeleteData(int Id);

    }
}

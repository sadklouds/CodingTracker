using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    public class Validation
    {
        // ensures the date that user has inputted meets the required format
        public bool ValidDateTime(string input)
        {
            if (DateTime.TryParseExact(input, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return true;
            }
            return false;
        }

        public bool ValidEndTime(DateTime endTime, DateTime startTime)
        {
            if (endTime > startTime) return true;
            return false;
        }
    }
}

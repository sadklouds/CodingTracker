using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTracker.Logic;

namespace CodingTracker.Data
{
    public class UserInput
    {
        private Validation validation = new Validation();


        public int UserIntInput()
        {
            while (true)
            {
                //Console.Write("\nEnter the operation you wish to perform: ");
                if (int.TryParse(Console.ReadLine(), out int option)) return option;
                Console.WriteLine("Invalid input given");
            }
        }
        public DateTime EnterDateTime()
        {
            while (true)
            {
                Console.Write("\nEnter date and time as dd/MM/yyyy hh:mm AM/PM: ");
                string? input = Console.ReadLine();
                if (input == null) continue;
                DateTime start;
                if (validation.ValidDateTime(input))
                    return start = Convert.ToDateTime(input);
                else Console.WriteLine("\nInvalid date format given");
            }
        }


        public DateTime EndTime(DateTime startTime)
        {
            while (true)
            {
                DateTime endTime = EnterDateTime();
                if (validation.ValidEndTime(endTime, startTime))
                    return endTime;
                else Console.WriteLine("\nEnd time & date is before start time & Date");
            }
        }

    }
}

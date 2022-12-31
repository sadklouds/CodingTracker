using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Data
{
    public class UserInput
    {
        private Validation validation = new Validation();

        public string UserInputString() 
        {
            string ?input;
            do
            {
                input = Console.ReadLine();
            } while (input == null);
            return input;
        } 
        public int UserIntInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int option)) return option;
                Console.WriteLine("Invalid input given");
            }
        }
        public DateTime EnterDateTime()
        {
            while (true)
            {
                Console.Write("\nEnter date and time as dd/MM/yyyy HH:mm (24 hour clock): ");
                string? input = Console.ReadLine();
                if (input == null) continue;
                DateTime start;
                if (validation.ValidDateTime(input))
                    return start = Convert.ToDateTime(input);
                else Console.WriteLine("\nInvalid date format given");
            }
        }

        // uses EnterDateTime method to get the data and format validation, this method will validate if it is after the given start date
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

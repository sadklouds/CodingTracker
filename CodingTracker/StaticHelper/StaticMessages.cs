using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.StaticHelper
{
    public class StaticMessages
    {
        public static void StartDateMessage() => Console.WriteLine("\nStart Date & Time ");
        public static void EndTimeMessage() => Console.WriteLine("\nEnd Date & Time");
        public static void EmptyTableMessage() => Console.WriteLine("\nTable contains no data");

        public static void EnterIdMessage() => Console.Write("\nEnter Code Session ID number: ");

        public static void IdErrorMessage(int Id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nCode Session with id:{Id} does not exist");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void OperationErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAn error has occured Operation has failed!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

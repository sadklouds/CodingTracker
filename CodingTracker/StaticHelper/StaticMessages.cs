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

        public static void EnterIdMessage() => Console.WriteLine("\nEnter Code Session ID number");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.StaticHelper
{
    public static class StaticMainMenu
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("\nMAIN MENU");
            Console.WriteLine("--------------------");
            Console.WriteLine("Track coding sessions");
            Console.WriteLine("--------------------");
            Console.WriteLine("1: View All Records.");
            Console.WriteLine("2: Insert Records.");
            Console.WriteLine("3: Delete Record");
            Console.WriteLine("4: Update Record");
            Console.WriteLine("0: Exit Program");
            Console.WriteLine("--------------------");
        }
    }
}

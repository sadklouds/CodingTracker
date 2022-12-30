using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTracker.Interface;
using CodingTracker.StaticHelper;
using CodingTracker.Data;
using CodingTracker.Logic;

namespace CodingTracker
{
    public  class CodingController
    {
        UserInput userInput = new();
        IDataAccess DataBase = new SQLiteDataAcess();
        CRUDOperations CRUD = new();

       
        public void Run()
        {
            DataBase.CreateDB();
            while (true)
            {
                StaticMainMenu.DisplayMenu();
                Console.Write("\nEnter the operation you wish to perform: ");
                int operation = userInput.UserIntInput();

                switch (operation)
                {
                    case 1:
                        CRUD.CodingSessionsTable(DataBase);
                        break;
                    case 2:
                        CRUD.CreateCodeSession(DataBase);
                        break;
                    case 3:
                        CRUD.DeleteCodeSession(DataBase);
                        break;

                    case 0:
                        Console.WriteLine("Exiting Program...");
                        return;
                    default:
                        Console.WriteLine("Unknown command was given.");
                        break;
                }

              
            }
        }
    }
}

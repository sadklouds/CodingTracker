using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTracker.Interface;
using CodingTracker.StaticHelper;
using CodingTracker.Data;


namespace CodingTracker.Controller
{
    public  class CodingController
    {
        UserInput userInput = new();
        IDataAccess DataBase = new SQLiteDataAcess();
        CRUDOperationController CRUD = new();

       // controlls the access to different operations
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
                        CRUD.CreateManualCodeSession(DataBase);
                        break;
                    case 3:
                        CRUD.StopWatch(DataBase);
                        break;
                    case 4:
                        CRUD.DeleteCodeSession(DataBase);
                        break;
                    case 5:
                        CRUD.UpdateCodeSession(DataBase);
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

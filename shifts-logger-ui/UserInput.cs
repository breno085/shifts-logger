using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shifts_logger_ui;

public static class UserInput
{
    public static void MainMenu()
    {
        bool closeMenu = false;

        while (!closeMenu)
        {
            Console.WriteLine("What you would like to do?");

            Console.WriteLine("1 - Add a new worker shift");
            Console.WriteLine("2 - View a worker shift");
            Console.WriteLine("3 - View all workers shifts");
            Console.WriteLine("4 - Update a worker shift");
            Console.WriteLine("5 - Delete a worker shift");
            Console.WriteLine("0 - Quit");

            string option = Console.ReadLine();
            
        }

    }

    public static void GetUserIdInput(string action)
    {
        //action can be read, update or delete 
        Console.WriteLine($"Type the Id of the worker you want to {action}: ");

        string id = Console.ReadLine();
    }

    public static void GetUserInput(string action)
    {
        Worker worker = new Worker();
        //action can be create, or update
        Console.WriteLine($"{action} worker shift log")
        Console.WriteLine("Name: ");
        string workerName = Console.ReadLine();

        Console.WriteLine("Start: (format HH:mm)");
        string workerStart = Console.ReadLine();

        Console.WriteLine("End: (format HH:mm)");
        string workerStart = Console.ReadLine();
    }
}
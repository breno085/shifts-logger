using shifts_logger_ui.Models;

namespace shifts_logger_ui;

public class UserInput
{
    public static void MainMenu()
    {
        bool closeMenu = false;
        int workerId;
        var worker = new Worker();

        while (!closeMenu)
        {
            Console.WriteLine("\nWhat you would like to do?");

            Console.WriteLine("1 - Add a new worker shift");
            Console.WriteLine("2 - View a worker shift");
            Console.WriteLine("3 - View all workers shifts");
            Console.WriteLine("4 - Update a worker shift");
            Console.WriteLine("5 - Delete a worker shift");
            Console.WriteLine("0 - Quit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    worker = GetUserInput("Add");
                    ShiftService.CreateWorkerLog(worker);
                    break;
                case "2":
                    workerId = GetIdInput("View");
                    ShiftService.GetWorkerLog(workerId);
                    break;
                case "3":
                    ShiftService.GetWorkersLogs();
                    break;
                case "4":
                    workerId = GetIdInput("Update");
                    worker = GetUserInput("Update");
                    ShiftService.UpdateWorkerLog(workerId, worker);
                    break;
                case "5":
                    workerId = GetIdInput("Delete");
                    ShiftService.DeleteWorkerLog(workerId);
                    break;
                case "0":
                    closeMenu = true;
                    break;
                default:
                    Console.WriteLine("Type a valid option");
                    break;
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

    }

    public static int GetIdInput(string action)
    {
        int id;
        bool validId;

        do
        {
            //action can be read, update or delete 
            Console.WriteLine($"Type the Id of the worker you want to {action}: ");
            string workerId = Console.ReadLine();

            validId = int.TryParse(workerId, out id);
        } while (!validId);

        return id;
    }

    public static Worker GetUserInput(string action)
    {
        Worker worker = new Worker();

        Console.WriteLine($"{action} worker shift log");

        Console.WriteLine("Name: ");
        worker.Name = Console.ReadLine();

        worker.Start = TimeValidation("Start");
        worker.End = TimeValidation("End");

        TimeSpan start = TimeSpan.Parse(worker.Start);
        TimeSpan end = TimeSpan.Parse(worker.End);

        if (end < start)
            end = end.Add(new TimeSpan(24, 0, 0)); // Add 24 hours

        worker.Duration = (end - start).ToString(@"hh\:mm");

        return worker;
    }

    public static string TimeValidation(string startOrEnd)
    {
        string time;

        bool isTimeValid;
        do
        {
            Console.WriteLine($"{startOrEnd}: (format HH:mm)");
            time = Console.ReadLine();
            isTimeValid = DateTime.TryParseExact(time, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _);

            if (!isTimeValid)
                Console.WriteLine("Type a valid time (Format HH:mm)");
        } while (!isTimeValid);

        return time;
    }
}
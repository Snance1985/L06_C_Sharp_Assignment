class Program
{
    static List<string?> taskList = new List<string?>();

    static void Main()
    {
        bool quit = false;

        while (!quit)
        {
            DisplayOptions();
            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();

            try
            {
                int choice = int.Parse(input);

                switch (choice)
                {
                    case 1:
                        CreateTask();
                        break;
                    case 2:
                        DisplayTasks();
                        break;
                    case 3:
                        DeleteTask();
                        break;
                    case 4:
                        quit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void DisplayOptions()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create a Task");
        Console.WriteLine("2. View All Tasks");
        Console.WriteLine("3. Delete a Task");
        Console.WriteLine("4. Quit");
    }

    static void CreateTask()
    {
        Console.Write("Enter a task: ");
        string? task = Console.ReadLine();
        taskList.Add(task);
        Console.WriteLine("Task created successfully!");
    }

    static void DisplayTasks()
    {
        if (taskList.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            Console.WriteLine("Tasks:");
            for (int i = 0; i < taskList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {taskList[i]}");
            }
        }
    }

    static void DeleteTask()
    {
        if (taskList.Count == 0)
        {
            Console.WriteLine("No tasks to delete.");
            return;
        }

        Console.WriteLine("Select a task to delete:");
        DisplayTasks();
        Console.Write("Enter the number of the task: ");
        string? input = Console.ReadLine();

        try
        {
            int taskIndex = int.Parse(input) - 1;

            if (taskIndex >= 0 && taskIndex < taskList.Count)
            {
                string? deletedTask = taskList[taskIndex];
                taskList.RemoveAt(taskIndex);
                Console.WriteLine($"Task '{deletedTask}' deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number. Please try again.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}
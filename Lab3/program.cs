using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using JsonSerialization;
using XmlSerialization;
using SQLiteSerialization;
namespace Lab3
{

    class Program
    {



        static List<Task> tasks = new();
        static string filename = "tasks";
        static string fileExtension = "json";
        private static JsonObjectSerializer<Task> jsonSerializer = new JsonObjectSerializer<Task>();
        private static XmlObjectSerializer<Task> xmlSerializer = new XmlObjectSerializer<Task>();
        private static SQLiteObjectSerializer<Task> sqliteSerializer = new SQLiteObjectSerializer<Task>($"{filename}.db");

        static void Main()
        {
            SaveDataMenu();

            while (true)
            {
                Console.WriteLine("Welcome to ToDoList:");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Search tasks by tags.");
                Console.WriteLine("3. Last N task ");
                Console.WriteLine("4. Edit data storage settings");
                Console.WriteLine("5. Exit");
                Console.Write("Select menu item number: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddNewTask();
                            break;
                        case 2:
                            SearchTasks();
                            break;
                        case 3:
                            LastNTasks();
                            break;
                        case 4:
                            SaveDataMenu();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Incorrect choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect choice. Please try again.");
                }
            }
        }

        //Добавление задачи
        static void AddNewTask()
        {
            Task newTask = new Task();

            Console.Write("Enter task title: ");
            newTask.Title = Console.ReadLine();

            Console.Write("Enter task description: ");
            newTask.Description = Console.ReadLine();

            Console.Write("Enter task deadline (format DDDD-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime Deadline))
            {
                newTask.Deadline = Deadline;
            }
            else
            {
                Console.WriteLine("Incorrect date format.Task wouldn't add.");
                return;
            }

            string tag;
            do
            {
                Console.WriteLine("Enter task tags (send one by one,to finish press Enter):");
                tag = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(tag))
                {
                    newTask.Tags.Add(tag);
                }

            } while (!string.IsNullOrWhiteSpace(tag));

            tasks.Add(newTask);
            SaveDataToFile(tasks);
            Console.WriteLine("Task successfully added!");
        }
        // Поиск задачи
        static void SearchTasks()
        {
            Console.Write("Enter tags for search (whitespace between the tags): ");
            string[] keywords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Фильтрация задач по тэгам
            List<Task> filteredTasks = tasks.FindAll(task => task.Tags.Any(tag => keywords.Contains(tag)));

            // Сортировка по дате готовности
            filteredTasks.Sort((task1, task2) => DateTime.Compare(task1.Deadline, task2.Deadline));

            Console.WriteLine("Tasks, sorted by deadline:");
            foreach (var task in filteredTasks)
            {
                task.Print();
            }
        }
        //последний N задач
        static void LastNTasks()
        {
            Console.Write("Enter number of task to show: ");

            if (int.TryParse(Console.ReadLine(), out int count))
            {
                if (count < tasks.Count())
                {

                    List<Task> tasksList = tasks;
                    tasksList.Sort((task1, task2) => DateTime.Compare(task1.Deadline, task2.Deadline));
                    for (int n = 0; n < count; n++)
                    {
                        tasksList[n].Print();
                    }
                }
                else
                {
                    List<Task> tasksList = tasks;
                    tasksList.Sort((task1, task2) => DateTime.Compare(task1.Deadline, task2.Deadline));
                    for (int n = 0; n < tasksList.Count(); n++)
                    {
                        tasksList[n].Print();
                    }
                }
            }
            else
            {
                Console.Write("Incorrect input try again");

            }


        }
        //Меню настройки сохранения данных
        static void SaveDataMenu()
        {
            Console.WriteLine("Select save data format:");
            Console.WriteLine("1. JSON");
            Console.WriteLine("2. XML");
            Console.WriteLine("3. SQLite");

            Console.Write("Enter menu item: ");

            if (int.TryParse(Console.ReadLine(), out int formatChoice))
            {
                switch (formatChoice)
                {
                    case 1:
                        fileExtension = "json";
                        break;
                    case 2:
                        fileExtension = "xml";
                        break;
                    case 3:
                        fileExtension = "db";
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Сохранение отменено.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный выбор. Сохранение отменено.");
            }
            LoadDataFromFile();
        }
        static void SaveDataToFile(List<Task> data)
        {
            switch (fileExtension)
            {
                case "json":
                    jsonSerializer.WriteDataToFile(data, $"{filename}.json");
                    break;
                case "xml":
                    xmlSerializer.WriteDataToFile(data, $"{filename}.xml");

                    break;
                case "db":
                    sqliteSerializer.WriteDataToDatabase(data);
                    break;
                default:
                    Console.WriteLine("Incorrect choice. Please try again.");
                    break;
            }
        }
        static void LoadDataFromFile()
        {
            switch (fileExtension)
            {
                case "json":
                    tasks = jsonSerializer.ReadDataFromFile($"{filename}.json");
                    break;
                case "xml":
                    tasks = xmlSerializer.ReadDataFromFile($"{filename}.xml");

                    break;
                case "db":
                    tasks = sqliteSerializer.ReadDataFromDatabase();
                    break;
                default:
                    Console.WriteLine("Incorrect choice. Please try again.");
                    break;
            }
        }
    }
}

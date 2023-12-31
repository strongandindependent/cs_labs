using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{

    class Program
    {
        static List<Task> tasks = new();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Welcome to ToDoList:");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Search tasks by tags.");
                Console.WriteLine("3. Last N task ");
                Console.WriteLine("4. Exit");
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
            Console.WriteLine("Task successfully added!");
        }

        static void SearchTasks()
        {
            Console.Write("Enter tags for search (whitespace between the tags): ");
            string[] keywords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


            List<Task> filteredTasks = tasks.FindAll(task => task.Tags.Any(tag => keywords.Contains(tag)));

            
            filteredTasks.Sort((task1, task2) => DateTime.Compare(task1.Deadline, task2.Deadline));

            Console.WriteLine("Tasks, sorted by deadline:");
            foreach (var task in filteredTasks)
            {
                task.Print();
            }
        }
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

    }


}

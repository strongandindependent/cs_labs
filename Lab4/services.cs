using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.Serializers;
namespace Lab4;
public interface ITaskService
{
    List<Task> GetAllTasks();
    List<Task> GetNTasks(int Task);
    // Task GetTaskById(int id);
    void AddTask(Task task);

}

public class TaskService : ITaskService
{
    private static JsonObjectSerializer<Task> jsonSerializer = new JsonObjectSerializer<Task>();

    private List<Task> tasks = new List<Task>();

    public List<Task> GetAllTasks()
    {
        return jsonSerializer.ReadDataFromFile("tasks.json");
    }
    public List<Task> GetNTasks(int number)
    {
        tasks = jsonSerializer.ReadDataFromFile("tasks.json");
        List<Task> result = new List<Task>();
        if (number < tasks.Count())
        {

            List<Task> tasksList = tasks;
            tasksList.Sort((task1, task2) => DateTime.Compare(task1.Deadline, task2.Deadline));
            for (int n = 0; n < number; n++)
            {
                result.Add(tasksList[n]);
            }
        }
        else
        {
            List<Task> tasksList = tasks;
            tasksList.Sort((task1, task2) => DateTime.Compare(task1.Deadline, task2.Deadline));
            for (int n = 0; n < tasksList.Count(); n++)
            {
                result.Add(tasksList[n]);
            }
        }
        return result;
    }
    public void AddTask(Task task)
    {
        tasks = GetAllTasks();
        tasks.Add(task);
        jsonSerializer.WriteDataToFile(tasks, "tasks.json");
    }
}

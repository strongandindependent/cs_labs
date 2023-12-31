using System;

namespace Lab2
{

    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public List<string> Tags { get; set; }

        public Task()
        {
            Tags = new List<string>();
        }

        public void Print()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Deadline: {Deadline.ToShortDateString()}");
            Console.Write($"Tags : {string.Join(", ", Tags)}");
            Console.Write("\n\n");

        }

    }
}

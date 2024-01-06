namespace Lab4;
using System;
using System.Collections.Generic;


public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public List<string> Tags { get; set; }

    public Task()
    {
        Tags = new List<string>();
    }
}

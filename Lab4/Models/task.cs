namespace Lab4.Models;
public class Task

{
    public long Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public List<string> Tags { get; set; }

    public Task()
    {
        Tags = new List<string>();
    }
}

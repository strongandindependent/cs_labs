using Microsoft.EntityFrameworkCore;

namespace Lab4.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<Task> TaskItems { get; set; } = null!;
    }
}

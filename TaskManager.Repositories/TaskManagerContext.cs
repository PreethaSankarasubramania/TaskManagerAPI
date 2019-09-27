using TaskManager.Entities;
using System.Data.Entity;

namespace TaskManager.Repositories
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext():base("name=TaskManager")
        {
        }

        public DbSet<ParentTask> ParentTasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

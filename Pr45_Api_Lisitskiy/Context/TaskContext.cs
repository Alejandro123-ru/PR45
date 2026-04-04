using Microsoft.EntityFrameworkCore;
using Pr45_Api_Lisitskiy.Models;

namespace Pr45_Api_Lisitskiy.Context
{
    public class TaskContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public TaskContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=localhost;uid=root;database=TaskManager", new MySqlServerVersion(new Version(8, 0, 11)));
    }
}

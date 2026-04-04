using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Pr45_Api_Lisitskiy.Models;

namespace Pr45_Api_Lisitskiy.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UsersContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;uid=root;database=TaskManager", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}

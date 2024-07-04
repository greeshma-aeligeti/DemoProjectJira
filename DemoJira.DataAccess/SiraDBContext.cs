using DemoJira.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess
{
    public class SiraDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb; Initial Catalog=SiraDB; Integrated Security=true ");
        }

        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<Project> Areas { get; set; }
        public DbSet<Iteration> Iterations { get; set; }
        public DbSet<TasksRelation> Relations { get; set; }
        public DbSet<User> NewUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

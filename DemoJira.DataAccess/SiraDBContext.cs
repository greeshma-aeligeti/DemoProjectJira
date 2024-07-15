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
      //  public DbSet<TasksRelation> Relations { get; set; }

        public DbSet<MyFile> Files { get; set; }


           public DbSet<TaskRelationship> Relations { get; set; }

        public DbSet<User> NewUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           /* modelBuilder.Entity<TaskRelationship>()
       .Property(r => r.Id)
       .ValueGeneratedOnAdd();*/
/*            modelBuilder.Entity<TaskRelationship>()
        .HasKey(tr => tr.Id);*/
            modelBuilder.Entity<MyTask>()
                .HasMany(t => t.ParentTasks)
                .WithOne(tr => tr.MainTask)
                .HasForeignKey(tr => tr.MainTaskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MyTask>()
                .HasMany(t => t.ChildTasks)
                .WithOne(tr => tr.RelatedTask)
                .HasForeignKey(tr => tr.RelatedTaskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskRelationship>()
                .HasOne(tr => tr.MainTask)
                .WithMany(t => t.ParentTasks)
                .HasForeignKey(tr => tr.MainTaskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskRelationship>()
                .HasOne(tr => tr.RelatedTask)
                .WithMany(t => t.ChildTasks)
                .HasForeignKey(tr => tr.RelatedTaskId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
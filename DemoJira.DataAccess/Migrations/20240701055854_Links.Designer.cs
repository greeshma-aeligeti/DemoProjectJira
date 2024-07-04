﻿// <auto-generated />
using System;
using DemoJira.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoJira.DataAccess.Migrations
{
    [DbContext(typeof(SiraDBContext))]
    [Migration("20240701055854_Links")]
    partial class Links
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoJira.DataAccess.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("TaskId");

                    b.HasIndex("userId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.Iteration", b =>
                {
                    b.Property<int>("IterationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IterationId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectEntityId")
                        .HasColumnType("int");

                    b.HasKey("IterationId");

                    b.HasIndex("ProjectEntityId");

                    b.ToTable("Iterations");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.MyTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<DateTime>("ActEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HexId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IterationId")
                        .HasColumnType("int");

                    b.Property<int>("MyUserId")
                        .HasColumnType("int");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("IterationId");

                    b.HasIndex("MyUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.TasksRelation", b =>
                {
                    b.Property<int>("RelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelationId"));

                    b.Property<int>("Task1TaskId")
                        .HasColumnType("int");

                    b.Property<int>("Task2TaskId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId1")
                        .HasColumnType("int");

                    b.Property<int>("TaskId2")
                        .HasColumnType("int");

                    b.HasKey("RelationId");

                    b.HasIndex("Task1TaskId");

                    b.HasIndex("Task2TaskId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NewUsers");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.Comment", b =>
                {
                    b.HasOne("DemoJira.DataAccess.Entities.MyTask", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoJira.DataAccess.Entities.User", "CmntUser")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CmntUser");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.Iteration", b =>
                {
                    b.HasOne("DemoJira.DataAccess.Entities.Project", "ProjectEntity")
                        .WithMany("Iterations")
                        .HasForeignKey("ProjectEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectEntity");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.MyTask", b =>
                {
                    b.HasOne("DemoJira.DataAccess.Entities.Iteration", "Iterations")
                        .WithMany()
                        .HasForeignKey("IterationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoJira.DataAccess.Entities.User", "MyUser")
                        .WithMany()
                        .HasForeignKey("MyUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoJira.DataAccess.Entities.Project", "Areas")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Areas");

                    b.Navigation("Iterations");

                    b.Navigation("MyUser");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.TasksRelation", b =>
                {
                    b.HasOne("DemoJira.DataAccess.Entities.MyTask", "Task1")
                        .WithMany()
                        .HasForeignKey("Task1TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoJira.DataAccess.Entities.MyTask", "Task2")
                        .WithMany()
                        .HasForeignKey("Task2TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task1");

                    b.Navigation("Task2");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.MyTask", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.Project", b =>
                {
                    b.Navigation("Iterations");
                });
#pragma warning restore 612, 618
        }
    }
}

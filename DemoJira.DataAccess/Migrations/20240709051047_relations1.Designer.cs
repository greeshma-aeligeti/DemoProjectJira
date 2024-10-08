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
    [Migration("20240709051047_relations1")]
    partial class relations1
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

                    b.HasKey("IterationId");

                    b.HasIndex("ProjId");

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

                    b.Property<int?>("BugStatus")
                        .HasColumnType("int");

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

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StoryPoint")
                        .HasColumnType("int");

                    b.Property<int?>("TaskStatus")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

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

            modelBuilder.Entity("DemoJira.DataAccess.Entities.TaskRelationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChildTaskId")
                        .HasColumnType("int");

                    b.Property<int>("ParentTaskId")
                        .HasColumnType("int");

                    b.Property<int>("RelationshipType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChildTaskId");

                    b.HasIndex("ParentTaskId");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.TasksRelation", b =>
                {
                    b.Property<int>("RelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelationId"));

                    b.Property<int>("TaskId1")
                        .HasColumnType("int");

                    b.Property<int>("TaskId2")
                        .HasColumnType("int");

                    b.Property<string>("relation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RelationId");

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
                        .HasForeignKey("ProjId")
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

            modelBuilder.Entity("DemoJira.DataAccess.Entities.TaskRelationship", b =>
                {
                    b.HasOne("DemoJira.DataAccess.Entities.MyTask", "ChildTask")
                        .WithMany("ParentTasks")
                        .HasForeignKey("ChildTaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DemoJira.DataAccess.Entities.MyTask", "ParentTask")
                        .WithMany("ChildTasks")
                        .HasForeignKey("ParentTaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChildTask");

                    b.Navigation("ParentTask");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.MyTask", b =>
                {
                    b.Navigation("ChildTasks");

                    b.Navigation("Comments");

                    b.Navigation("ParentTasks");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.Project", b =>
                {
                    b.Navigation("Iterations");
                });
#pragma warning restore 612, 618
        }
    }
}

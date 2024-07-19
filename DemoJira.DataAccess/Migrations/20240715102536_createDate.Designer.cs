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
    [Migration("20240715102536_createDate")]
    partial class createDate
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

                    b.Property<string>("TaskId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

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

            modelBuilder.Entity("DemoJira.DataAccess.Entities.MyFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("TaskId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UploadTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.MyTask", b =>
                {
                    b.Property<string>("TaskId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ActEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BugStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IterationId")
                        .HasColumnType("int");

                    b.Property<int>("MyUserId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ReporterId")
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

                    b.HasIndex("ReporterId");

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

                    b.Property<string>("MainTaskId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RelatedTaskId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RelationshipType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MainTaskId");

                    b.HasIndex("RelatedTaskId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

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
                        .HasForeignKey("UserId")
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

            modelBuilder.Entity("DemoJira.DataAccess.Entities.MyFile", b =>
                {
                    b.HasOne("DemoJira.DataAccess.Entities.MyTask", "AttachedToTask")
                        .WithMany("TaskFiles")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttachedToTask");
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

                    b.HasOne("DemoJira.DataAccess.Entities.User", "Reporter")
                        .WithMany()
                        .HasForeignKey("ReporterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Areas");

                    b.Navigation("Iterations");

                    b.Navigation("MyUser");

                    b.Navigation("Reporter");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.TaskRelationship", b =>
                {
                    b.HasOne("DemoJira.DataAccess.Entities.MyTask", "MainTask")
                        .WithMany("ParentTasks")
                        .HasForeignKey("MainTaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DemoJira.DataAccess.Entities.MyTask", "RelatedTask")
                        .WithMany("ChildTasks")
                        .HasForeignKey("RelatedTaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MainTask");

                    b.Navigation("RelatedTask");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.MyTask", b =>
                {
                    b.Navigation("ChildTasks");

                    b.Navigation("Comments");

                    b.Navigation("ParentTasks");

                    b.Navigation("TaskFiles");
                });

            modelBuilder.Entity("DemoJira.DataAccess.Entities.Project", b =>
                {
                    b.Navigation("Iterations");
                });
#pragma warning restore 612, 618
        }
    }
}

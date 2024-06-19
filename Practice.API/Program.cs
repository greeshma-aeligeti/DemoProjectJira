
using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.Bussiness.Services;
using DemoJira.DataAccess;
using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using DemoJira.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Practice.API.Controllers;
using System.Text.Json;

namespace Practice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

           // builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

         
                builder.Services.AddControllers()
                        .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                            options.JsonSerializerOptions.WriteIndented = true;
                        });

                // Other configurations and services
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITaskRepository, TaskRepos>();
            builder.Services.AddScoped<MyTask>();
            builder.Services.AddScoped<TaskDTO>();
            builder.Services.AddAutoMapper(typeof(TaskController));
            builder.Services.AddHttpClient<ITaskService, TaskService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44353");
            });
            builder.Services.AddScoped<SiraDBContext>();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseWebAssemblyDebugging();
            }

         

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseBlazorFrameworkFiles();

            app.UseStaticFiles();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}


using DemoJira.Bussiness.APIServices;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.Bussiness.Services;
using DemoJira.DataAccess;
using DemoJira.DataAccess.InterfaceForRepo;
using DemoJira.DataAccess.Repositories;
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
                            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                            options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

                        });

                // Other configurations and services
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITaskRepository, TaskRepos>();
            //builder.Services.AddScoped<MyTask>();
            builder.Services.AddScoped<TaskAPIService>();
            builder.Services.AddTransient<UserAPIService>();
          //  builder.Services.AddScoped<User>();
          builder.Services.AddScoped<IRelationRepos,RelationRepos>();
            builder.Services.AddScoped<IRelationService, RelationService>();
            builder.Services.AddScoped<RelationAPIService>();
            builder.Services.AddTransient<IUserService,UserService>();
            builder.Services.AddScoped<IUserRepository,UserRepos>();
            builder.Services.AddScoped<CommentAPIService>();
            builder.Services.AddScoped<ICommentRepos,CommentRepos>();
            builder.Services.AddScoped<ICommentService,CommentService>();
            builder.Services.AddScoped<IIdGeneratorService,IDGeneratorService>();
           builder.Services.AddScoped<IFileRepos,FileRepos>();
            builder.Services.AddScoped<IFileService,FileService>();
            builder.Services.AddScoped<FileApiService>();

           // builder.Services.AddTransient<IUserService>();
            builder.Services.AddAutoMapper(typeof(TaskController));
            /*    builder.Services.AddHttpClient<ITaskService, TaskService>(client =>
                {
                    client.BaseAddress = new Uri("http://localhost:5011");
                });*/
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped(sp =>
        new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5120")
        });
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:5011") // Your Blazor app URL
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5011") // Replace with your client's URL
                               .AllowAnyHeader()
                               
                               .AllowAnyMethod();
                    });
            });

            // In Configure method




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
            app.UseCors();
            app.UseAuthorization();
            app.UseBlazorFrameworkFiles();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("AllowSpecificOrigin");

            app.MapRazorPages();
            app.MapControllers();
           // app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}

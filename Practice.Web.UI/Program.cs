//using Blazored.Toast;
/*using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;*/
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using DemoJira.Bussiness.APIServices;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.Bussiness.Services;
using DemoJira.DataAccess;
using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using DemoJira.DataAccess.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Microsoft.Fast.Components.FluentUI;

namespace Practice.Web.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

             builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5011/") });
            builder.Services.AddScoped<ITaskService ,TaskService>();
            builder.Services.AddScoped<ITaskRepository, TaskRepos>();
            builder.Services.AddScoped<TaskAPIService>();
            builder.Services.AddScoped<SiraDBContext>();
            builder.Services.AddScoped<UserAPIService>();
            builder.Services.AddScoped<ICommentRepos, CommentRepos>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<CommentAPIService>();
            builder.Services.AddScoped<IIdGeneratorService, IDGeneratorService>();
            builder.Services.AddScoped<IRelationRepos, RelationRepos>();
            builder.Services.AddScoped<IRelationService, RelationService>();
            builder.Services.AddScoped<RelationAPIService>();

            // builder.Services.AddSingleton<LibraryConfiguration>();
            //builder.Services.AddAntDesign();
            //  builder.Services.AddScoped<User>();
            //builder.Services.AddBlazoredToast();
            //  builder.Services.AddBlazorise();
            /*builder.Services.AddScoped<IClassProvider,ClassProvider>();
            builder.Services.AddScoped<ClassProvider>();
         */
            builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();
            //  builder.Services.AddBootstrapHelpers();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepos>();
            await builder.Build().RunAsync();
        }
    }
}

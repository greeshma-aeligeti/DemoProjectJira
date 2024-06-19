using DemoJira.Bussiness.ServiceInterface;
using DemoJira.Bussiness.Services;
using DemoJira.DataAccess;
using DemoJira.DataAccess.InterfaceForRepo;
using DemoJira.DataAccess.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Practice.Web.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //  builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ITaskService ,TaskService>();
            builder.Services.AddScoped<ITaskRepository, TaskRepos>();
            builder.Services.AddScoped<TaskAPIService>();
            builder.Services.AddScoped<SiraDBContext>();
            await builder.Build().RunAsync();
        }
    }
}

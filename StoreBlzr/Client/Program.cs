using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StoreBlzr.Shared.Services.Auth;
using MudBlazor.Services;

namespace StoreBlzr.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // Bulma Service
            // builder.Services.AddBulmaRazor();
            builder.Services.AddMudServices();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient<IAuthDataService, AuthDataService>(client => client.BaseAddress = new Uri("https://localhost:5001/"));


            await builder.Build().RunAsync();
        }
    }
}

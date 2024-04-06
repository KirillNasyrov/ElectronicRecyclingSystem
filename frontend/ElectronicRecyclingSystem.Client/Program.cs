using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ElectronicRecyclingSystem.Client;
using ElectronicRecyclingSystem.Client.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri("https://localhost:7072/") });

builder.Services.AddScoped<IRecyclingApplicationService, RecyclingApplicationService>();

await builder.Build().RunAsync();
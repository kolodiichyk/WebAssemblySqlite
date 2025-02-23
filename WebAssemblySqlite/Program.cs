using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Radzen;
using SoloX.BlazorJsBlob;
using WebAssemblySqlite;
using WebAssemblySqlite.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddRadzenComponents();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddJsBlob();
builder.Services.AddScoped<IndexedDbService>();
builder.Services.AddDbContextFactory<ApplicationDbContext>(
    options => options.UseSqlite($"Filename=app.db"));

await builder.Build().RunAsync();

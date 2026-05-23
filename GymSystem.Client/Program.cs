using Gym.Infra;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IPersonsRepo, PersonsRepo>();

await builder.Build().RunAsync();
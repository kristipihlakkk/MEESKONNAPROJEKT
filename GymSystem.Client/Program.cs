using Gym.Infra;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IPersonsRepo, PersonsRepo>();
builder.Services.AddScoped<ILocationsRepo, LocationsRepo>();
builder.Services.AddScoped<IRoomsRepo, RoomsRepo>();
builder.Services.AddScoped<IAddressesRepo, AddressesRepo>();
builder.Services.AddScoped<ILocationRoomsRepo, LocationRoomsRepo>();
builder.Services.AddScoped<IBookingsRepo, BookingsRepo>();
builder.Services.AddScoped<IRoomBookingsRepo, RoomBookingsRepo>();

await builder.Build().RunAsync();
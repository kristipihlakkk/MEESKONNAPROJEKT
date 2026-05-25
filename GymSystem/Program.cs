using GymSystem.Client.Pages;
using GymSystem.Components;
using Microsoft.EntityFrameworkCore;
using Gym.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=app.db"));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<IPersonsRepo, PersonsRepo>();
builder.Services.AddScoped<IMembershipsRepo, MembershipsRepo>();
builder.Services.AddScoped<ILocationsRepo, LocationsRepo>();
builder.Services.AddScoped<IRoomsRepo, RoomsRepo>();
builder.Services.AddScoped<IAddressesRepo, AddressesRepo>();
builder.Services.AddScoped<ILocationRoomsRepo, LocationRoomsRepo>();
builder.Services.AddScoped<IBookingsRepo, BookingsRepo>();
builder.Services.AddScoped<IRoomBookingsRepo, RoomBookingsRepo>();
builder.Services.AddScoped<IVisitsRepo, VisitsRepo>();
builder.Services.AddScoped<ITrainersRepo, TrainersRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GymSystem.Client._Imports).Assembly);

app.Run();
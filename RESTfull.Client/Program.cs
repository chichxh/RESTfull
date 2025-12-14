using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RESTfull.Client;
using RESTfull.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7168/") });

// Регистрация сервисов для взаимодействия с API
builder.Services.AddScoped<IConferenceService, ConferenceService>();
builder.Services.AddScoped<IDirectionService, DirectionService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IVenueService, VenueService>();

await builder.Build().RunAsync();


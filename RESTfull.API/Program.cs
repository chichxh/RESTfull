using Microsoft.EntityFrameworkCore;

using RESTfull.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RESTfull.Infrastructure.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy => policy.WithOrigins("https://localhost:7168", "http://localhost:5193",
                                      "https://localhost:5001", "http://localhost:5000",
                                      "http://localhost:5173", "https://localhost:5173",
                                      "https://localhost:7033", "http://localhost:5192")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorClient");
        
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

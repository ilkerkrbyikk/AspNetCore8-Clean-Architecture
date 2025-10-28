using Restaurants.API.Middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Seeder;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ExceptionHandlingMiddleware>();
//Application Registrations
builder.Services.AddApplication();
//Infrastructure Registrations
builder.Services.AddInfrastructure(builder.Configuration);


//Serilog Configuration --bokunu çýkarmamak için bu kadar yeter prod zamaný config edilir----
//------app.json içine taþýnabilir hatta taþýnmalý ben taþýmadým------
builder.Host.UseSerilog((context, configuration) =>
        configuration.MinimumLevel.Override("Microsoft",LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
        .WriteTo.File("Logs/Restaurant-API-.log", rollingInterval : RollingInterval.Day, rollOnFileSizeLimit : true)
);

var app = builder.Build();

// Data Seeding
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

await seeder.Seed();

//-----HTTP REQUEST PIPELINE-------
//Exception Handling Middleware Registration 
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

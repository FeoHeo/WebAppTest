using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TestApp.Application.Interfaces;
using TestApp.Application.Services;
using TestApp.Application.Services.DataTypes;
using TestApp;
using TestApp.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllersWithViews();
// Build the database connections
builder.Services.AddDbContext<UserDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeWorkInfoService , EmployeeWorkInfoService>();
builder.Services.AddScoped<IEmployeeGovIdService , EmployeeGovIdService>();
builder.Services.AddScoped<IEmployeeInfoService , EmployeeInfoService>();
builder.Services.AddSingleton<IUserService, UserService>(); // configure these later
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("DevCors");
// Map controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Prints to see if connection is working
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();

bool canConnect = context.Database.CanConnect();

Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));
try
{
    Console.WriteLine(canConnect
        ? "✅ Database connection successful"
        : "❌ Cannot connect to database");
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}


app.UseHttpsRedirection();

// Start implementation
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
        // var forecast = Enumerable.Range(1, 5).Select(index =>   // Enumerate from 1 cause we wanna add at least 1 date to curr date for 'prediction'
        //         new WeatherForecast
        //         (
        //             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //             Random.Shared.Next(-20, 55),    
        //             summaries[Random.Shared.Next(summaries.Length)]
        //         ))
        //     .ToArray();
        // return forecast;



// Weather app
app.MapGet("/weatherinfo", ([FromServices] IWeatherService service) =>
    {
        return service.GetForecast();
    })
    .WithName("GetWeatherInfo");

app.MapPost("/weatherpost", ([FromServices] IWeatherService service, int index) =>
{
    WeatherForecast input = new WeatherForecast(
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        Random.Shared.Next(-20, 55),
        summaries[Random.Shared.Next(summaries.Length)]
    );
    return service.AddForecast(input);
});

    

app.MapDelete("/weatherdelete", ([FromServices] IWeatherService service) =>
{
    var currForecast = service.GetForecast();
    service.DeleteForecast();
    return;
});

app.MapPut("/weatherupdate", (int index) =>
{
    return $"Updated: {index}";
});


// Employee/User app

// app.MapGet("/userget", ([FromServices]IUserService service  , [FromBody]PagingRequest? pageRequest) =>
// {
//     return service.GetUserPage(pageRequest);
// });

app.MapGet("/usergetspecific/{targetId}", ([FromServices] IUserService service, int targetId) =>
{
    return service.GetUserSpecific(targetId);
});

app.MapPost("/userpost", ([FromServices]IUserService service, [FromBody]User userInput) =>
{
    service.AddUser(userInput);
});

app.MapDelete("/userdelete/{targetId}", ([FromServices]IUserService service , int targetId) =>
{
    return service.DeleteUser(targetId);
});

app.MapPut("/userput/{targetId}", ([FromServices]IUserService service , int targetId, User userInput) =>
{
    service.UpdateUser(targetId, userInput);
});



app.Run();

// use default value if no values are specified
public record PagingRequest(int PageNum = 1, int PageSize = 5);

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}



//post, put, delete
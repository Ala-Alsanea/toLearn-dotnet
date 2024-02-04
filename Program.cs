global using toLearn.Models;
using Microsoft.EntityFrameworkCore;
using toLearn.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(
    connectionString: builder.Configuration.GetConnectionString("MySqlConnectionString"),
    serverVersion: new MySqlServerVersion(new Version(8, 3, 0))
     ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// if (args.Length == 1 && args[0].ToLower() == "seeddata")
//     SeedData(app);

// void SeedData(IHost app)
// {
//     var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

//     using (var scope = scopedFactory.CreateScope())
//     {
//         var service = scope.ServiceProvider.GetService<Seed>();
//         service.SeedDataContext();
//     }
// }

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

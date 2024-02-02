using Microsoft.EntityFrameworkCore;
using toLearn.Models;

namespace toLearn.Data;
public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Employees> Employees { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // Replace with your connection string.
    //     var connectionString = "dddd";

    //     var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
    //     optionsBuilder.UseMySql(connectionString, serverVersion);
    // }

}

using Microsoft.EntityFrameworkCore;
using toLearn.Models;

namespace toLearn.Data;
public class AppDbContext : DbContext
{

    public DbSet<Employees> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace with your connection string.
        var connectionString = "server=localhost;user=ala;password=1234;database=dotnet_toLearn";

        var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

}

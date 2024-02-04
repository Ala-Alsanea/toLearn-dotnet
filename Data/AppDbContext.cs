using Microsoft.EntityFrameworkCore;
using toLearn.Models;

namespace toLearn.Data;
public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {

    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // Replace with your connection string.
    //     // var connectionString = "server=localhost;user=ala;password=1234;database=dotnet_toLearn";
    //     // var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
        
    //     var connectionString = _configuration.GetConnectionString("MySqlConnectionString");
    //     var serverVersion = ServerVersion.AutoDetect(connectionString);

    //     optionsBuilder.UseMySql(connectionString, serverVersion);
    // }


    public DbSet<Category> Categories { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<PokemonCategory> PokemonCategories { get; set; }
    public DbSet<PokemonOwner> PokemonOwners { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // PokemonCategory
        modelBuilder.Entity<PokemonCategory>()
            .HasKey(pc => new { pc.PokemonId, pc.CategoryId });

        modelBuilder.Entity<PokemonCategory>()
            .HasOne(pc => pc.Pokemon)
            .WithMany(pc => pc.PokemonCategories)
            .HasForeignKey(pc => pc.PokemonId);

        modelBuilder.Entity<PokemonCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(pc => pc.PokemonCategories)
            .HasForeignKey(pc => pc.CategoryId);

        // PokemonOwner
        modelBuilder.Entity<PokemonOwner>()
            .HasKey(pc => new { pc.PokemonId, pc.OwnerId });

        modelBuilder.Entity<PokemonOwner>()
            .HasOne(pc => pc.Pokemon)
            .WithMany(pc => pc.PokemonOwners)
            .HasForeignKey(pc => pc.PokemonId);

        modelBuilder.Entity<PokemonOwner>()
            .HasOne(pc => pc.Owner)
            .WithMany(pc => pc.PokemonOwners)
            .HasForeignKey(pc => pc.OwnerId);


    }



}

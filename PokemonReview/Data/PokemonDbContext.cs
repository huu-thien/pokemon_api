using Microsoft.EntityFrameworkCore;

namespace PokemonReview.Data;

public class PokemonDbContext : DbContext
{
    public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
    {
    }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }
    public DbSet<PokemonOwner> PokemonOwners { get; set; }
    public DbSet<PokemonCategory> PokemonCategories { get; set; }

    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PokemonDbContext).Assembly);
    }
}
using AppWithDatabase.Data.Entities;
using AppWithDatabase.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AppWithDatabase.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    public DbSet<PetEntity> Pets { get; set; } = null!;
    public DbSet<BreedEntity> Breeds { get; set; } = null!;
    public DbSet<LocationEntity> Locations { get; set; } = null!;
    public DbSet<CategoryEntity> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BreedEntityConfiguration());
        modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.UseHiLo();
    }
}
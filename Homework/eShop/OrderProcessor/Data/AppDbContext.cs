#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
using OrderProcessor.Data.Entities;
using OrderProcessor.Data.EntityConfigurations;

namespace OrderProcessor.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<BuyerEntity> Buyers { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new OrderEntityConfiguration());
        builder.ApplyConfiguration(new BuyerEntityConfiguration());
    }
}
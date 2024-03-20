using AppWithDatabase.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppWithDatabase.Data.EntityConfigurations;

public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
{
    public void Configure(EntityTypeBuilder<PetEntity> builder)
    {
        builder.ToTable("pet");
        
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name).HasColumnName("name");
        builder.Property(e => e.CategoryId).HasColumnName("category_id");
        builder.Property(e => e.Age).HasColumnName("age");
        builder.Property(e => e.BreedId).HasColumnName("breed_id");
        builder.Property(e => e.ImageUrl).HasColumnName("image_url");
        builder.Property(e => e.LocationId).HasColumnName("location_id");
        builder.Property(e => e.Description).HasColumnName("description");

        builder
            .HasOne(e => e.Category)
            .WithMany(e => e.Pets)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(e => e.Bread)
            .WithMany(e => e.Pets)
            .HasForeignKey(e => e.BreedId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(e => e.Location)
            .WithMany(e => e.Pets)
            .HasForeignKey(e => e.LocationId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
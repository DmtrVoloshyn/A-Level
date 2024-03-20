using AppWithDatabase.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppWithDatabase.Data.EntityConfigurations;

public class BreedEntityConfiguration : IEntityTypeConfiguration<BreedEntity>
{
    public void Configure(EntityTypeBuilder<BreedEntity> builder)
    {
        builder.ToTable("breed");
        
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.BreedName).HasColumnName("breed_name");
        builder.Property(e => e.CategoryId).HasColumnName("category_id");

        builder
            .HasOne(e => e.Category)
            .WithMany(e => e.Breeds)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
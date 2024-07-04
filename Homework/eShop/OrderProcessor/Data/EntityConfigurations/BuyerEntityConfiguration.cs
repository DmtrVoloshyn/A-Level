using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProcessor.Data.Entities;

namespace OrderProcessor.Data.EntityConfigurations
{
    public class BuyerEntityConfiguration : IEntityTypeConfiguration<BuyerEntity>
    {
        public void Configure(EntityTypeBuilder<BuyerEntity> builder)
        {
            builder.ToTable("Buyers");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.BuyerGuid)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.SurName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.FullAddress)
                .IsRequired()
                .HasMaxLength(200);
            
            builder.HasMany(b => b.Orders)
                .WithOne(o => o.Buyer)
                .HasForeignKey(o => o.BuyerId);
        }
    }
}
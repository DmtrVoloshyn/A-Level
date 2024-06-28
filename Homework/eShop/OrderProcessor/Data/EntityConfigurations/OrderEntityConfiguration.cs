using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProcessor.Data.Entities;

namespace OrderProcessor.Data.EntityConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderGuid)
                .IsRequired();
            
            builder.Property(o => o.BuyerId)
                .IsRequired();

            builder.Property(o => o.OrderStatuses)
                .IsRequired();

            builder.Property(o => o.PaymentType)
                .IsRequired();

            builder.Property(o => o.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            
            builder.HasOne(o => o.Buyer)
                .WithMany(b => b.Orders)
                .HasForeignKey(o => o.BuyerId);;

            builder.Property(o => o.ProductIds)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                );
        }
    }
}
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        
        builder.HasKey(c => c.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(c => c.Date)
            .IsRequired();
        
        builder.HasOne(c => c.User)
            .WithMany() 
            .HasForeignKey(c => c.UserId)
            .IsRequired();

        builder.HasMany(e => e.Items);
    }
}
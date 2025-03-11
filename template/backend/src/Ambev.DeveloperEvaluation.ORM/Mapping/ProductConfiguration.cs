using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>   
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        
        builder.ToTable("Products");

        
        builder.HasKey(p => p.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

       
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Image)
            .HasMaxLength(250);

        builder.Property(p => p.Category)
            .HasMaxLength(100);

       
        builder.Property<string>("RatingJson")
            .HasColumnName("RatingJson")
            .HasColumnType("varchar(300)");

       
        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("now()");

       
        builder.Property(p => p.UpdatedAt)
            .IsRequired(false);
    }
}
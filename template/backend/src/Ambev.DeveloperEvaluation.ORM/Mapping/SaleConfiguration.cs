using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        
        builder.ToTable("Sales");

        
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");


        builder.Property(s => s.SaleNumber)
            .IsRequired();

        builder.Property(s => s.SaleDate)
            .IsRequired();

        builder.Property(s => s.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.IsCancelled)
            .IsRequired();
        
        builder.Property(p => p.UpdateAt)
            .IsRequired(false);
        
        builder.Property(p => p.CanceledAt)
            .IsRequired(false);
        
        builder.HasOne(s => s.Customer)
            .WithMany(c => c.Sales) 
            .HasForeignKey(s => s.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(s => s.SaleItems)
            .WithOne(si => si.Sale)
            .HasForeignKey(si => si.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.Branch)
            .WithMany()
            .HasForeignKey(s => s.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
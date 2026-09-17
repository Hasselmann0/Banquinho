using Banquinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banquinho.Infra.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.CustomerId);

        builder.Property(c => c.FullName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.CPF)
            .IsRequired()
            .HasMaxLength(11);

        builder.HasIndex(c => c.CPF)
            .IsUnique();

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(254);

        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.Ignore(c => c.Password);

        builder.Property(c => c.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.CNPJ)
            .IsRequired(false)
            .HasMaxLength(14);

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.HasMany(c => c.Accounts)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

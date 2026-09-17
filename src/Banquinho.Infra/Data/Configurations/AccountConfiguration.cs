using Banquinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banquinho.Infra.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.AccountId);

        builder.Property(a => a.AccountNumber)
            .IsRequired();

        builder.HasIndex(a => a.AccountNumber)
            .IsUnique();

        builder.Property(a => a.AccountType)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(a => a.Balance)
            .IsRequired()
            .HasPrecision(18, 2)
            .HasDefaultValue(0);

        builder.Property(a => a.Status)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(a => a.CreatedAt)
            .IsRequired();

        builder.Property(a => a.CustomerId)
            .IsRequired(false);

        builder.Property(a => a.EnterpriseId)
            .IsRequired(false);

        builder.HasOne(a => a.Customer)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Enterprise)
            .WithMany(e => e.Accounts)
            .HasForeignKey(a => a.EnterpriseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

using Banquinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banquinho.Infra.Data.Configurations;

public class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
{
    public void Configure(EntityTypeBuilder<Enterprise> builder)
    {
        builder.ToTable("Enterprises");

        builder.HasKey(e => e.EnterpriseId);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.CNPJ)
            .IsRequired()
            .HasMaxLength(14);

        builder.HasIndex(e => e.CNPJ)
            .IsUnique();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.HasMany(e => e.Accounts)
            .WithOne(a => a.Enterprise)
            .HasForeignKey(a => a.EnterpriseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

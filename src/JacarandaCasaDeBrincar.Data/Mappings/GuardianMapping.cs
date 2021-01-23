using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class GuardianMapping : IEntityTypeConfiguration<Guardian>
    {
        public void Configure(EntityTypeBuilder<Guardian> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(g => g.Cpf)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(g => g.Rg)
                .IsRequired()
                .HasColumnType("varchar(12)");

            builder.Property(g => g.CompanyName)
                .HasColumnType("varchar(250)");

            builder.Property(g => g.Kinship)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(g => g.Occupation)
                .HasColumnType("varchar(150)");           

            builder.ToTable("Guardians", "jacaranda");
        }
    }
}

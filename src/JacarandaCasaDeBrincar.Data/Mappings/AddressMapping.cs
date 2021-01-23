using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Cep)
                .IsRequired()
                .HasColumnType("varchar(9)");

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(a => a.Complement)
                .IsRequired(false)
                .HasColumnType("varchar(150)");

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Addresses", "jacaranda");
        }
    }
}

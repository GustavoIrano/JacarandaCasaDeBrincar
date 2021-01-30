using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class AllergieMapping : IEntityTypeConfiguration<Allergie>
    {
        public void Configure(EntityTypeBuilder<Allergie> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.ToTable("Allergies", "jacaranda");
        }
    }
}

using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class InitialContactMapping : IEntityTypeConfiguration<InitialContact>
    {
        public void Configure(EntityTypeBuilder<InitialContact> builder)
        {
            builder.HasKey(ic => ic.Id);

            builder.Property(ic => ic.Informations)
               .IsRequired()
               .HasColumnType("varchar(500)");

            builder.ToTable("InitialContacts", "jacaranda");
        }
    }
}

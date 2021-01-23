using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class NextContactMapping : IEntityTypeConfiguration<NextContact>
    {
        public void Configure(EntityTypeBuilder<NextContact> builder)
        {
            builder.HasKey(nc => nc.Id);

            builder.Property(nc => nc.Informations)
               .IsRequired()
               .HasColumnType("varchar(500)");

            builder.ToTable("NextContacts", "jacaranda");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class CaptureMapping : IEntityTypeConfiguration<JacarandaCasaDeBrincar.Business.Models.Capture>
    {
        public void Configure(EntityTypeBuilder<JacarandaCasaDeBrincar.Business.Models.Capture> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(a => a.Period)
                .IsRequired()
                .HasColumnType("varchar(25)");

            builder.ToTable("Captures", "jacaranda");
        }
    }
}

using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class HowDidYouknowMapping : IEntityTypeConfiguration<HowDidYouknow>
    {
        public void Configure(EntityTypeBuilder<HowDidYouknow> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.ToTable("HowDidYouknows", "jacaranda");
        }
    }
}

using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class AllergieStudentMapping : IEntityTypeConfiguration<AllergieStudent>
    {
        public void Configure(EntityTypeBuilder<AllergieStudent> builder)
        {
            builder.HasKey(a => a.AllergiesId);

            builder.HasKey(a => a.StudentsId);

            builder.ToTable("AllergieStudent", "jacaranda");
        }
    }
}

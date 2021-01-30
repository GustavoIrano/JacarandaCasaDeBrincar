using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class AllergieStudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            //u => u.ToTable("AllergieStudent", "jacaranda")
            builder.HasMany(a => a.Allergies)
                   .WithMany(s => s.Students)
                   .UsingEntity<Dictionary<string, object>>(
                        "jacaranda.AllergieStudent",
                        x => x.HasOne<Allergie>().WithMany().HasForeignKey("AllergiesId"),
                        x => x.HasOne<Student>().WithMany().HasForeignKey("StudentsId")
                );
        }
    }
}

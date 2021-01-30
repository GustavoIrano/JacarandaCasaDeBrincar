using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace JacarandaCasaDeBrincar.Data.Mappings
{
    public class FoodRestrictionStudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(a => a.FoodRestrictions)
                .WithMany(s => s.Students)
                .UsingEntity<Dictionary<string, object>>(
                        "jacaranda.FoodRestrictionStudent",
                        x => x.HasOne<FoodRestriction>().WithMany().HasForeignKey("FoodRestrictionsId"),
                        x => x.HasOne<Student>().WithMany().HasForeignKey("StudentsId")
                );
        }
    }
}

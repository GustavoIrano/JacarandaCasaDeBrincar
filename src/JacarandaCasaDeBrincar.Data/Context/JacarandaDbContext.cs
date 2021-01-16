using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JacarandaCasaDeBrincar.Data.Context
{
    public class JacarandaDbContext : DbContext
    {
        public JacarandaDbContext(DbContextOptions<JacarandaDbContext> options) : base(options){}

        public DbSet<Guardian> Guardians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JacarandaDbContext).Assembly);

            //Impedindo o delete em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}

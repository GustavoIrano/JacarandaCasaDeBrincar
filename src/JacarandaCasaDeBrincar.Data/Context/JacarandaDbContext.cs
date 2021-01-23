using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JacarandaCasaDeBrincar.Data.Context
{
    public class JacarandaDbContext : DbContext
    {
        //private readonly StreamWriter _writer = new StreamWriter("LogsEF.txt", append: true);

        public JacarandaDbContext(DbContextOptions<JacarandaDbContext> options) : base(options){}

        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Allergie> Allergies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JacarandaDbContext).Assembly);

            //Impedindo o delete em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(_writer.WriteLine, LogLevel.Information);

            optionsBuilder.EnableDetailedErrors();

            base.OnConfiguring(optionsBuilder);
        }

        /*
        public override void Dispose()
        {
            base.Dispose();
            _writer.Dispose();
        }*/
    }
}

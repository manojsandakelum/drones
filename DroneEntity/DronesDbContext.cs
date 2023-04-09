using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesEntity
{
    public class DronesDbContext :DbContext
    {
        public DronesDbContext(DbContextOptions<DronesDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DronesDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DroneMedicationEntity>().HasKey(sc => new { sc.DroneId, sc.MedicationId });

        }

        public DbSet<DroneEntity> Drones { get; set; }
        public DbSet<MedicationEntity> Medications { get; set; }
        public DbSet<DroneMedicationEntity> DroneMedications { get; set; }
    }
}

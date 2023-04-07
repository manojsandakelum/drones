using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneEntity
{
    public class DronsDbContext : DbContext
    {
        public DronsDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DronesDB;User Id=sa;Password=Sql2021");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DroneMedicationEntity>().HasKey(sc => new { sc.DroneId, sc.MedicationId });
        }

        public DbSet<DroneEntity> Drones { get; set; }
        public DbSet<DroneEntity> Medications { get; set; }
        public DbSet<DroneMedicationEntity> DroneMedications { get; set; }
    }
}

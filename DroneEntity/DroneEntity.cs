using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DroneEntity
{
    
    public class DroneEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string SerialNumber { get; set; }
        public string? Model { get; set; }
        public double? WeightLimit { get; set; }
        public double? BatteryCapasity { get; set; }
        public string? State { get; set; }

        public List<DroneMedicationEntity> DroneMedications { get; set; }
    }
}

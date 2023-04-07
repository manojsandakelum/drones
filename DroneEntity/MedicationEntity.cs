using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DroneEntity
{
    public class MedicationEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Weight { get; set; }
        public double? code { get; set; }
        public byte[] image { get; set; }

        public List<DroneMedicationEntity> DroneMedications { get; set; }
    }
}

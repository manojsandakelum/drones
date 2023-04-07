using System;
using System.Collections.Generic;
using System.Text;

namespace DroneEntity
{
    public class DroneMedicationEntity
    {
        public int DroneId { get; set; }
        public DroneEntity Drone { get; set; }

        public int MedicationId { get; set; }
        public MedicationEntity Medication { get; set; }
    }
}

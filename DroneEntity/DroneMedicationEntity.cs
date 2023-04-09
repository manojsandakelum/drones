using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesEntity
{
    public class DroneMedicationEntity
    {
        public int DroneId { get; set; }
        public DroneEntity Drone { get; set; }

        public int MedicationId { get; set; }
        public MedicationEntity Medication { get; set; }
        public int NoOfMedications { get; set; }
    }
}

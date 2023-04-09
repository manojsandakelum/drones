using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesDTO
{
   

    public class DispatchMedicationReturnDTO
    {
        public int DroneId { get; set; }
        public int MedicationId { get; set; }
        public string Name { get; set; }
        public int NoOfMedications { get; set; }
        public double? Weight { get; set; }
        public string Code { get; set; }
        public byte[] Image { get; set; }
    }

}

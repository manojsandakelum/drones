using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesDTO
{
    public class MedicationReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Weight { get; set; }
        public string code { get; set; }
        public byte [] image { get; set; }
    }
}

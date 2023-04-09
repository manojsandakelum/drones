
using System.ComponentModel.DataAnnotations.Schema;

namespace DronesEntity
{

    public class MedicationEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Weight { get; set; }
        public string code { get; set; }
        public byte[] image { get; set; }

        public List<DroneMedicationEntity> DroneMedications { get; set; }
    }
}

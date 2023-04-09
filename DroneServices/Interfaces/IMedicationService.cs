using DronesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServices.Interfaces
{
    public interface IMedicationService
    {
        public string Save(MedicationDTO droneDto);
        public IList<MedicationReturnDTO> GetAllAvailables();
    }
}

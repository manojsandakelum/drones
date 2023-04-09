using DroneDTO;
using DronesDTO;
using DronesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServices.Interfaces
{
    public interface IDispatchService
    {
        public string Save(DispatchDTO droneDto);
        public IList<DispatchMedicationReturnDTO> GetListByDroneId(int id);
    }
}

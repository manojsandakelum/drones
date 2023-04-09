using DronesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServices.Interfaces
{
    public interface IDroneService
    {
        string Save(DronesDTO.DroneDTO droneDto);
        IList<DroneReturnDTO> GetAllAvailables();
        double GetBatteryLevelByDroneId(int id);
    }
}

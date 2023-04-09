using DronesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneRepositories.Interfaces
{
    public interface IDispatchRepository
    {
        public IList<DroneMedicationEntity> GetListByDroneId(int id);
        public int Save(DroneMedicationEntity medicationEntity);
    }
}

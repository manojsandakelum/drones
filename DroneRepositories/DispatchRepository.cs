using DroneRepositories.Interfaces;
using DronesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneRepositories
{

    public class DispatchRepository : IDispatchRepository
    {
        private DronesDbContext _dronesDbContext = null;

        public DispatchRepository(DronesDbContext dronesDbContext)
        {
            _dronesDbContext = dronesDbContext;
        }

        public IList<DroneMedicationEntity> GetListByDroneId(int id)
        {
            return _dronesDbContext.DroneMedications.Where(x => x.DroneId == id).ToList();
        }

        public int Save(DroneMedicationEntity medicationEntity)
        {
            int result = 0;
            _dronesDbContext.DroneMedications.Add(medicationEntity);
            result = _dronesDbContext.SaveChanges();
            return result;
        }

        
    }
}


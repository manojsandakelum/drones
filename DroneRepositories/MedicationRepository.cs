using DroneRepositories.Interfaces;
using DronesEntity;
using DroneUtil.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneRepositories
{

    public class MedicationRepository : IMedicationRepository
    {
        private DronesDbContext _dronesDbContext = null;

        public MedicationRepository(DronesDbContext dronesDbContext)
        {
            _dronesDbContext = dronesDbContext;
        }
        public IList<MedicationEntity> GetAllAvailables()
        {
            return _dronesDbContext.Medications.ToList();
        }

        public MedicationEntity GetById(int id)
        {
            return _dronesDbContext.Medications.FirstOrDefault(x=>x.Id == id);
        }

        public int Save(MedicationEntity medicationEntity)
        {
            int result = 0;
            _dronesDbContext.Medications.Add(medicationEntity);
            result = _dronesDbContext.SaveChanges();
            return result;
        }
    }
}


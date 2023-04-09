using DronesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneRepositories.Interfaces
{
    public interface IMedicationRepository
    {
        public IList<MedicationEntity> GetAllAvailables();

        public MedicationEntity GetById(int id);

        public int Save(MedicationEntity medicationEntity);
    }
}

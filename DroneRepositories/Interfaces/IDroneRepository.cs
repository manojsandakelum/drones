using DronesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneRepositories.Interfaces
{
    public interface IDroneRepository
    {
        public IList<DroneEntity> GetAllAvailables();
        public IList<DroneEntity> GetAll();

        public DroneEntity GetById(int id);

        public int Save(DroneEntity droneEntity);
    }
}

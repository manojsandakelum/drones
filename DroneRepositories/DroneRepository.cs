using DroneRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DroneRepositories
{
    public class DroneRepository : IDroneRepository
    {
        public IQueryable<DroneEntity.DroneEntity> GetAllAvailables()
        {
            throw new NotImplementedException();
        }

        public DroneEntity.DroneEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(DroneEntity.DroneEntity additiveMaster)
        {
            throw new NotImplementedException();
        }
    }
}

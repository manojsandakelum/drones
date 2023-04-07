using DroneEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DroneRepositories.Interfaces
{
    public interface IDroneRepository
    {
        IQueryable<DroneEntity.DroneEntity> GetAllAvailables();

        DroneEntity.DroneEntity GetById(int id);
        int  Save(DroneEntity.DroneEntity additiveMaster);
    }
}

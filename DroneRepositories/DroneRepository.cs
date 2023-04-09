using DroneRepositories.Interfaces;
using DronesEntity;
using DroneUtil.Enums;

namespace DroneRepositories
{
    public class DroneRepository : IDroneRepository
    {
        private DronesDbContext _dronesDbContext;

        public DroneRepository(DronesDbContext dronesDbContext)
        {
            _dronesDbContext = dronesDbContext;
        }


        public IList<DroneEntity> GetAllAvailables()
        {
            return _dronesDbContext.Drones.Where(x => x.BatteryCapasity > 25 && x.State == DroneStateEnum.IDLE.ToString()).ToList();

        }

        public DroneEntity GetById(int id)
        {
            return _dronesDbContext.Drones.FirstOrDefault(x => x.Id == id);
        }

        public int Save(DroneEntity droneEntity)
        {
            int result = 0;
            _dronesDbContext.Drones.Add(droneEntity);
            result = _dronesDbContext.SaveChanges();
            return result;
        }
    }
}

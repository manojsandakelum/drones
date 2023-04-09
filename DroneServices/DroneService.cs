using DroneRepositories.Interfaces;
using DronesDTO;
using DronesEntity;
using DroneServices.Interfaces;

namespace DronesServices
{
    public class DroneService : IDroneService
    {

        private readonly IDroneRepository _droneRepository = null;


        public DroneService(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }


        public IList<DroneReturnDTO> GetAllAvailables()
        {
            var droneList = new List<DroneReturnDTO>();
            try
            {
                var mappingList = _droneRepository.GetAllAvailables();

                foreach (var data in mappingList)
                {
                    DroneReturnDTO dto = new DroneReturnDTO();
                    dto.Id = data.Id;
                    dto.SerialNumber = data.SerialNumber;
                    dto.Model = data.Model;
                    dto.WeightLimit = data.WeightLimit;
                    dto.BatteryCapasity = data.BatteryCapasity;
                    dto.State = data.State;
                    droneList.Add(dto);
                }



            }
            catch (Exception ex)
            {
                throw;
            }
            return droneList;
        }


        public double GetBatteryLevelByDroneId(int id)
        {
            double batteryLevel = 0;
            try
            {
                var item = _droneRepository.GetById(id);
                if (item != null)
                {

                    batteryLevel = (double)item.BatteryCapasity;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return batteryLevel;
        }

        public string Save(DronesDTO.DroneDTO droneDto)
        {
            string result = "Insert failed";
            try
            {
                if (droneDto != null)
                {
                    if (droneDto.WeightLimit > 500)
                    {
                        return "Insert failed due to max weight limit (500) exceed";

                    }
                    DroneEntity droneEntity = new DroneEntity();
                    droneEntity.SerialNumber = droneDto.SerialNumber;
                    droneEntity.Model = droneDto.Model.ToString();
                    droneEntity.WeightLimit = droneDto.WeightLimit;
                    droneEntity.BatteryCapasity = droneDto.BatteryCapasity;
                    droneEntity.State = droneDto.State.ToString();
                    _droneRepository.Save(droneEntity);
                    result = "Insert Suceess";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}

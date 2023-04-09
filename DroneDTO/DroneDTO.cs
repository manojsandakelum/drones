using DroneUtil.Enums;

namespace DronesDTO
{
    public class DroneDTO
    {       
        public string SerialNumber { get; set; }
        public DroneModelEnum Model { get; set; }
        public double? WeightLimit { get; set; }
        public double? BatteryCapasity { get; set; }
        public DroneStateEnum State { get; set; }
    }
}
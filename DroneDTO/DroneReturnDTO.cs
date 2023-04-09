﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesDTO
{
    public class DroneReturnDTO
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public double? WeightLimit { get; set; }
        public double? BatteryCapasity { get; set; }
        public string State { get; set; }
    }
}

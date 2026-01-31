using parking_lot.src.ParkingLot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_lot.src.ParkingLot.Domain.Entities
{
    public class Vehicle
    {
        public string VehicleNumber { get; }
        public VehicleType VehicleType { get; }

        public Vehicle(string vehicleNumber, VehicleType vehicleType)
        {
            VehicleNumber = vehicleNumber;
            VehicleType = vehicleType;
        }
    }

}

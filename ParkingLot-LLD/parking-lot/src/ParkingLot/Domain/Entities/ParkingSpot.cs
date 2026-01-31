using parking_lot.src.ParkingLot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_lot.src.ParkingLot.Domain.Entities
{
    public class ParkingSpot
    {
        public int SpotId { get; }
        public ParkingSpotType SpotType { get; }
        public bool IsAvailable { get; private set; }
        public Vehicle ParkedVehicle { get; private set; }

        public ParkingSpot(int spotId, ParkingSpotType spotType)
        {
            SpotId = spotId;
            SpotType = spotType;
            IsAvailable = true;
        }

        public bool CanFitVehicle(Vehicle vehicle)
        {
            return (vehicle.VehicleType == VehicleType.Bike && SpotType == ParkingSpotType.BikeSpot)
                || (vehicle.VehicleType == VehicleType.Car && SpotType == ParkingSpotType.CarSpot)
                || (vehicle.VehicleType == VehicleType.Truck && SpotType == ParkingSpotType.TruckSpot);
        }

        public void Park(Vehicle vehicle)
        {
            ParkedVehicle = vehicle;
            IsAvailable = false;
        }

        public void Unpark()
        {
            ParkedVehicle = null;
            IsAvailable = true;
        }
    }

}

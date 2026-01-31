using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_lot.src.ParkingLot.Domain.Entities
{
    public class ParkingFloor
    {
        public int FloorNumber { get; }
        public List<ParkingSpot> ParkingSpots { get; }

        public ParkingFloor(int floorNumber)
        {
            FloorNumber = floorNumber;
            ParkingSpots = new List<ParkingSpot>();
        }

        public ParkingSpot GetAvailableSpot(Vehicle vehicle)
        {
            return ParkingSpots.FirstOrDefault(
                spot => spot.IsAvailable && spot.CanFitVehicle(vehicle));
        }
    }
}

using parking_lot.src.ParkingLot.Domain.Entities;
using parking_lot.src.ParkingLot.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_lot.src.ParkingLot.Strategies
{
    public class NearestSpotStrategy : IParkingStrategy
    {
        public ParkingSpot FindSpot(List<ParkingFloor> floors, Vehicle vehicle)
        {
            foreach (var floor in floors)
            {
                var spot = floor.GetAvailableSpot(vehicle);
                if (spot != null)
                    return spot;
            }
            return null;
        }
    }

}

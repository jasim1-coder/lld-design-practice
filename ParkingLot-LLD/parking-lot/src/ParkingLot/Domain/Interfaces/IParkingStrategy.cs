using parking_lot.src.ParkingLot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_lot.src.ParkingLot.Domain.Interfaces
{
    public interface IParkingStrategy
    {
        ParkingSpot FindSpot(List<ParkingFloor> floors, Vehicle vehicle);
    }
}

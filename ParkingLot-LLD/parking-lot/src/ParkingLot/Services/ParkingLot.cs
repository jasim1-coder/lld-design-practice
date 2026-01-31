using parking_lot.src.ParkingLot.Domain.Entities;
using parking_lot.src.ParkingLot.Domain.Interfaces;
using parking_lot.src.ParkingLot.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace parking_lot.src.ParkingLot.Services
{
    public class ParkingLot
    {
        private static ParkingLot _instance;
        private int _ticketCounter = 1;

        public List<ParkingFloor> Floors { get; }
        private readonly IParkingStrategy _parkingStrategy;

        private ParkingLot()
        {
            Floors = new List<ParkingFloor>();
            _parkingStrategy = new NearestSpotStrategy();
        }

        public static ParkingLot GetInstance()
        {
            if( _instance == null )
                _instance = new ParkingLot();
            return _instance;
        }

        public Ticket ParkVehicle(Vehicle vehicle)
        {
            var spot = _parkingStrategy.FindSpot(Floors, vehicle);

            if(spot == null)
            {
                throw new Exception("Parking Lot is Full");
            }

            spot.Park(vehicle);

            return new Ticket(_ticketCounter++, vehicle.VehicleNumber, spot.SpotId);

        }
        public void UnparkVehicle(Ticket ticket)
        {
            foreach(var floor in Floors)
            {
                var spot = floor.ParkingSpots
                    .FirstOrDefault(spot => spot.SpotId == ticket.SpotId);

                if(spot != null)
                {
                    spot.Unpark();
                    ticket.CloseTicket();
                    return;
                }

            }
            throw new Exception("Invalid Ticket");
        }
    }
}

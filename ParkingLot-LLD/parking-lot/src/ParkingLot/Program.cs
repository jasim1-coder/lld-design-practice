
using parking_lot.src.ParkingLot.Domain.Entities;
using parking_lot.src.ParkingLot.Domain.Enums;
using parking_lot.src.ParkingLot.Services;
using System;

class Program
{
    static void Main()
    {
        var parkingLot = ParkingLot.GetInstance();

        var floor1 = new ParkingFloor(1);
        floor1.ParkingSpots.Add(new ParkingSpot(1, ParkingSpotType.CarSpot));
        floor1.ParkingSpots.Add(new ParkingSpot(1, ParkingSpotType.BikeSpot));

        parkingLot.Floors.Add(floor1);
        var vehicle = new Vehicle("KL-07-AB-1234", VehicleType.Car);
        var ticket = parkingLot.ParkVehicle(vehicle);

        Console.WriteLine($"Vehcle parked. Ticket ID: {ticket.TicketId}");

        parkingLot.UnparkVehicle(ticket);

        var paymentService = new PaymentService();
        var fee = paymentService.CalculateFee(ticket.ExitTime.Value, ticket.ExitTime.Value);
        Console.WriteLine($"Parking Fee: {fee}");
    }
}
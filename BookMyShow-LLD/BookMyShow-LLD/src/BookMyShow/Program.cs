using BookMyShow_LLD.src.BookMyShow.Domain.Entities;
using BookMyShow_LLD.src.BookMyShow.Domain.Enums;
using BookMyShow_LLD.src.BookMyShow.Services;
using BookMyShow_LLD.src.BookMyShow.Strategies;
using System;

class Program
{
    static void Main()
    {
        var user = new User(1, "Jasim");
        var movie = new Movie(1, "Inception");

        var seats = new List<Seat>
        {
            new Seat(1, "A1"),
            new Seat(2, "A2"),
            new Seat(3, "A3")
        };

        var show = new Show(1, movie, DateTime.Now.AddHours(1), seats);

        Console.WriteLine("Available Seats: ");
        foreach (var seat in show.GetAvailableSeats())
        {
            Console.WriteLine(seat.SeatNumber);
        }

        var seatStrategy = new SimpleSeatSelectionStrategy();

        var bookingService = new BookingService(seatStrategy);

        var booking = bookingService.CreateBooking(user, show, 2);

        var paymentService = new PaymentService();
        var paymentStatus = paymentService.MakePayment(500);
        if (paymentStatus == PaymentStatus.Success)
        {
            booking.Confirm();
            Console.WriteLine("Booking Confirmed!");
        }

    }
}
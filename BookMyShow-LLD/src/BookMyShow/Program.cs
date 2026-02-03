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
        var movieService = new MovieService();
        var movies = movieService.GetMovies();

        Console.WriteLine("🎬 Available Movies:");
        foreach (var movie in movies)
        {
            Console.WriteLine($"{movie.MovieId}. {movie.Title}");
        }


        var seats = new List<Seat>
        {
            new Seat(1, "A1"),
            new Seat(2, "A2"),
            new Seat(3, "A3")
        };

        var selectedMovie = movies[0];
        Console.WriteLine($"\nSelected Movie: {selectedMovie.Title}");



        var show = new Show(1, selectedMovie, DateTime.Now.AddHours(1), seats);

        Console.WriteLine("\n🎭 Available Shows:");
        Console.WriteLine($"Show ID: {show.ShowId}, Time: {show.StartTime}");



        Console.WriteLine("Available Seats: ");
        foreach (var seat in show.GetAvailableSeats())
        {
            Console.WriteLine(seat.SeatNumber);
        }

        var seatStrategy = new SimpleSeatSelectionStrategy();

        var bookingService = new BookingService(seatStrategy);

        var booking = bookingService.CreateBooking(user, show, 2);
        Console.WriteLine("\n🎟️ Booking created with 2 seats.");


        var paymentService = new PaymentService();
        var paymentStatus = paymentService.MakePayment(500);
        if (paymentStatus == PaymentStatus.Success)
        {
            booking.Confirm();
            Console.WriteLine("💳 Payment successful.");
            Console.WriteLine("✅ Booking confirmed!");
        }
        else
        {
            Console.WriteLine("❌ Payment failed. Booking not confirmed.");
        }

        Console.WriteLine("Available Seats: ");
        foreach (var seat in show.GetAvailableSeats())
        {
            Console.WriteLine(seat.SeatNumber);
        }


    }
}
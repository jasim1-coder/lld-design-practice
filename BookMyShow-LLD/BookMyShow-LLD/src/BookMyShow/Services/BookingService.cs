using BookMyShow_LLD.src.BookMyShow.Domain.Entities;
using BookMyShow_LLD.src.BookMyShow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow_LLD.src.BookMyShow.Services
{
    public class BookingService
    {
        private int _bookingCounter = 1;
        private readonly ISeatSelectionStrategy _seatSelectionStrategy;

        public BookingService(ISeatSelectionStrategy seatSelectionStrategy)
        {
            _seatSelectionStrategy = seatSelectionStrategy;
        }
        public Booking CreateBooking(User user, Show show, int seatCount)
        {
            var availableSeats = show.GetAvailableSeats();
            var selectedSeats = _seatSelectionStrategy
                .SelectSeats(availableSeats, seatCount);

            return new Booking(_bookingCounter++, user, show, selectedSeats);
        }
    }
}

using BookMyShow_LLD.src.BookMyShow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow_LLD.src.BookMyShow.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; }
        public User User { get; }
        public Show Show { get; }
        public List<Seat> Seats { get; }
        public BookingStatus Status { get; private set;}

        public Booking(int bookingId, User user, Show show, List<Seat> seats)
        {
            BookingId = bookingId;
            User = user;
            Show = show;
            Seats = seats;
            Status = BookingStatus.Created;
        }

        public void Confirm()
        {
            Status = BookingStatus.Confirmed;
            Seats.ForEach(seat => seat.Book());
        }
    }
}

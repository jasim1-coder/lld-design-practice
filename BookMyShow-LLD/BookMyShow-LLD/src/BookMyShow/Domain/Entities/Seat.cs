using BookMyShow_LLD.src.BookMyShow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow_LLD.src.BookMyShow.Domain.Entities
{
    public class Seat
    {
        public int SeatId { get; }
        public string SeatNumber { get; }
        public SeatStatus SeatStatus { get; private set; }

        public Seat(int seatId, string seatNumber)
        {
            SeatId = seatId;
            SeatNumber = seatNumber;
            SeatStatus = SeatStatus.Available;
        }

        public void Book()
        {
            SeatStatus = SeatStatus.Booked;
        }
    }
}

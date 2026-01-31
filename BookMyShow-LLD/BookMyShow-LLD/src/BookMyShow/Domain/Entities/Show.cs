using BookMyShow_LLD.src.BookMyShow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow_LLD.src.BookMyShow.Domain.Entities
{
    public class Show
    {
        public int ShowId { get; }
        public Movie Movie { get; }
        public DateTime StartTime { get; }
        public List<Seat> Seats { get; }

        public Show(int showId, Movie movie, DateTime startTime, List<Seat> seats)
        {
            ShowId = showId;
            Movie = movie;
            StartTime = startTime;
            Seats = seats;
        }

        public List<Seat> GetAvailableSeats()
        {
            return Seats.Where(s => s.SeatStatus == SeatStatus.Available).ToList();

        }
    }
}

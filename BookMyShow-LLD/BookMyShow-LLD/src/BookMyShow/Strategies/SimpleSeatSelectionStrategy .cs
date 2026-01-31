using BookMyShow_LLD.src.BookMyShow.Domain.Entities;
using BookMyShow_LLD.src.BookMyShow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow_LLD.src.BookMyShow.Strategies
{
    public class SimpleSeatSelectionStrategy : ISeatSelectionStrategy
    {
        public List<Seat> SelectSeats(List<Seat> availableSeats, int SeatCount)
        {
            return availableSeats
                .Take(SeatCount)
                .ToList();
        }
    }
}

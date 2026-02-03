using BookMyShow_LLD.src.BookMyShow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow_LLD.src.BookMyShow.Domain.Interfaces
{
    public interface ISeatSelectionStrategy
    {
        List<Seat> SelectSeats(List<Seat> availableSeats, int seatCount);
    }
}

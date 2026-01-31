using parking_lot.src.ParkingLot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_lot.src.ParkingLot.Domain.Entities
{
      public class Ticket
    {
        public int TicketId { get; set; }
        public string VehicleNumber { get; set; }
        public int SpotId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public TicketStatus Status { get; set; }

        public Ticket(int ticketId, string vehicleNumber, int spotId)
        {
            TicketId = ticketId;
            VehicleNumber = vehicleNumber;
            SpotId = spotId;
            EntryTime = DateTime.Now;
            Status = TicketStatus.Active;
        }

        public void CloseTicket()
        {
            ExitTime = DateTime.Now;
            Status = TicketStatus.Paid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking_lot.src.ParkingLot.Services
{
    public class PaymentService
    {
        public double CalculateFee(DateTime entryTime, DateTime exitTime)
        {
            var totalHours = Math.Ceiling((exitTime - entryTime).TotalHours);
            if (totalHours <= 1)
            {
                return 50; 
            }
            return  50 + (totalHours - 1) * 30;
        }
    }
}
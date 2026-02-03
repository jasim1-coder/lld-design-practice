using BookMyShow_LLD.src.BookMyShow.Domain.Entities;
using BookMyShow_LLD.src.BookMyShow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow_LLD.src.BookMyShow.Services
{
    public class PaymentService
    {
        public PaymentStatus MakePayment(double amount)
        {
            return PaymentStatus.Success;
        }
    }
}

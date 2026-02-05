using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise_LLD.Domain.Entities
{
    public class Split
    {
        public User User { get; }
        public decimal Amount { get; set; }


        public Split(User user, decimal amount = 0 )
        {
            User = user;
            Amount = amount;
        }
    }
}

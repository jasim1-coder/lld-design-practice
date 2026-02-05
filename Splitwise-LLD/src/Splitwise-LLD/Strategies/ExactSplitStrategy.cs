using Splitwise_LLD.Domain.Entities;
using Splitwise_LLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise_LLD.Strategies
{
    public class ExactSplitStrategy : ISplitStrategy
    {
        public List<Split> CalculateSplits(decimal amount, List<Split> splits)
        {
            if (splits.Sum(S => S.Amount) != amount)
                throw new Exception("Exact split amoutns do not sum to total");

            return splits;
        }
    }
}

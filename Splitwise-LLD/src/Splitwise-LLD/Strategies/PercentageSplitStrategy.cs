using Splitwise_LLD.Domain.Entities;
using Splitwise_LLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise_LLD.Strategies
{
    public class PercentageSplitStrategy : ISplitStrategy
    {

        public List<Split> CalculateSplits(decimal amount, List<Split> splits)
        {
            if (splits.Sum(s => s.Amount) != 100)
                throw new Exception("Percentages must sum to 100");

            foreach (var split in splits)
            {
                split.Amount  = (split.Amount / 100 ) * 100;
            }

            return splits;
        }
    }
}

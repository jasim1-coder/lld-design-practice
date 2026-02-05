using Splitwise_LLD.Domain.Entities;
using Splitwise_LLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise_LLD.Strategies
{
    public class EqualSplitStrategy : ISplitStrategy
    {
        public List<Split> CalculateSplits(decimal amount, List<Split> splits)
        {
            decimal equalAmount = amount / splits.Count;

            foreach(var split in splits)
            {
                split.Amount = equalAmount;
            }
            
            return splits;
        }
    }
}

using Splitwise_LLD.Domain.Entities;
using Splitwise_LLD.Domain.Enums;
using Splitwise_LLD.Domain.Interfaces;
using Splitwise_LLD.Strategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise_LLD.Services
{
    public class ExpenseService
    {
        private readonly BalanceService _balanceService;

        public ExpenseService(BalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        public void AddExpense(Expense expense, List<Split> splits)
        {
            ISplitStrategy strategy = expense.SplitType switch
            {
                SplitType.EQUAL => new EqualSplitStrategy(),
                SplitType.EXACT => new ExactSplitStrategy(),
                SplitType.PERCENTAGE => new PercentageSplitStrategy(),
                _ => throw new Exception("Invalid split type")
            };

            var calculatedSplits = strategy.CalculateSplits(expense.Amount, splits);

            foreach (var split in calculatedSplits)
            {
                if(split.User.Id != expense.PaidBy.Id)
                {
                    _balanceService.UpdateBalance(split.User, expense.PaidBy, split.Amount);    
                }
            }

        }


    }
}

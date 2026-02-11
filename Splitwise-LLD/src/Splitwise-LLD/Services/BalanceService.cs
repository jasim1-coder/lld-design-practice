using Splitwise_LLD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise_LLD.Services
{
    public class BalanceService
    {
        private readonly Dictionary<string, Dictionary<string, decimal>> _balances = new();

        public void UpdateBalance(User from, User to, decimal amount)
        {
            if(!_balances.ContainsKey(from.Id))
                _balances[from.Id] = new Dictionary<string, decimal>();

            if(!_balances[from.Id].ContainsKey(to.Id))
                _balances[from.Id][to.Id] = 0;

            _balances[from.Id][to.Id] += amount;
        }

        public Dictionary<string, Dictionary<string, decimal>> GetBalances()
        {
            return _balances;
        }
        public void PrintBalance(Dictionary<string, User> users)
        {
            foreach(var from in _balances)
            {
                foreach(var to in from.Value)
                {
                    if(to.Value > 0)
                    {
                        Console.WriteLine(
                            $"{users[from.Key].Name} owes {users[to.Key].Name}: ₹{to.Value}");
                    }
                }

            }
        } 
    }
}

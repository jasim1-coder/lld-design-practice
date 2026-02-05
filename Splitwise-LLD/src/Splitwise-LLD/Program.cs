


using Splitwise_LLD.Domain.Entities;
using Splitwise_LLD.Domain.Enums;
using Splitwise_LLD.Services;

class Program
{
     static void Main()
    {
        var users = new Dictionary<string, User>
        {
            {"u1", new User("u1", "Alice") },
            { "u2", new User("u2", "Bob") },
            { "u3", new User("u3", "Charlie") }
        };

        var balanceService = new BalanceService();
        var expenseService = new ExpenseService(balanceService);

        expenseService.AddExpense(new Expense("e1", 300, users["u1"], SplitType.EQUAL),new List<Split>
        {
            new Split(users["u1"]),
            new Split(users["u2"]),
            new Split(users["u3"])
        }
        );

        expenseService.AddExpense(
           new Expense("e2", 200, users["u2"], SplitType.EXACT),
           new List<Split>
           {
                new Split(users["u1"], 50),
                new Split(users["u2"], 50),
                new Split(users["u3"], 100)
           }
       );

        Console.WriteLine("\nBalances:");
        balanceService.PrintBalance(users);

    }
}
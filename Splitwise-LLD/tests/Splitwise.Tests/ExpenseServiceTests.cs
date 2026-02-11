using Splitwise_LLD.Domain.Entities;
using Splitwise_LLD.Domain.Enums;
using Splitwise_LLD.Services;


namespace Splitwise.Tests
{
    public class ExpenseServiceTests
    {
        [Fact]
        public void Equal_Split_Should_Update_Balances_Correctly()
        {
            //Arrange
            var alice = new User("u1", "Alice");
            var bob = new User("u2", "Bob");

            var users = new Dictionary<string, User>
            {
                {alice.Id, alice},
                {bob.Id, bob},
            };

            var balanceService = new BalanceService();
            var expenseService = new ExpenseService(balanceService);


            //Act
            expenseService.AddExpense(
                new Expense("e1", 100, alice, SplitType.EQUAL),
                new List<Split>
                {
                    new Split(alice), new Split(bob)
                }

             );

            var balances = balanceService.GetBalances();
            Assert.Equal(50, balances[bob.Id][alice.Id]);
        }

        [Fact]
        public void Exact_Split_Should_Throw_If_Sum_Is_Invalid()
        {
            var alice = new User("u1", "Alice");
            var bob = new User("u2", "Bob");

            var balanceService = new BalanceService();
            var expenseService = new ExpenseService(balanceService);

            Assert.Throws<Exception>(() =>
                expenseService.AddExpense(
                    new Expense("e1", 100, alice, SplitType.EXACT),
                    new List<Split>
                    {
                new Split(alice, 30),
                new Split(bob, 30)
                    }
                )
            );
        }


        [Fact]
        public void Percentage_Split_Should_Calculate_Correct_Amounts()
        {
            var alice = new User("u1", "Alice");
            var bob = new User("u2", "Bob");

            var balanceService = new BalanceService();
            var expenseService = new ExpenseService(balanceService);

             expenseService.AddExpense(
                new Expense("e1", 200, alice, SplitType.PERCENTAGE),
                new List<Split>
                {
                    new Split(alice, 50),
                    new Split(bob, 50)
                }
              );

            var balances = balanceService.GetBalances();
            Assert.Equal(100, balances[bob.Id][alice.Id]);
        }
    }
}

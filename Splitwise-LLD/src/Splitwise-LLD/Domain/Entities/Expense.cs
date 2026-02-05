using Splitwise_LLD.Domain.Enums;


namespace Splitwise_LLD.Domain.Entities
{
    public class Expense
    {
        public string Id {  get; }
        public decimal Amount { get; }

        public User PaidBy { get; }

        public SplitType SplitType { get; }

        public Expense(string id, decimal amount,User paidBy , SplitType splitType)
        {
            Id = id;
            Amount = amount;
            PaidBy = paidBy;
            SplitType = splitType;
        }
    }
}

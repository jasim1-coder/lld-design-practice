using Splitwise_LLD.Domain.Entities;


namespace Splitwise_LLD.Domain.Interfaces
{
    public interface ISplitStrategy
    {
        List<Split> CalculateSplits(decimal amount, List<Split> splits);
    }
}

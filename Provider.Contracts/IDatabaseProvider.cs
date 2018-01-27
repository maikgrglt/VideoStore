using VideoStore.DA;

namespace Provider.Contracts
{
    public interface IDatabaseProvider
    {
        DataAccess DataAccess { get; }
    }
}
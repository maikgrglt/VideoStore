using VideoStore.Models;

namespace Provider.Contracts
{
    public interface IUserProvider
    {
        User Login(string username, string password);
    }
}
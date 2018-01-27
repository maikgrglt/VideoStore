using System.Threading.Tasks;
using VideoStore.Models;

namespace Provider.Contracts
{
    public interface IUserProvider
    {
        User Login(string username, string password);
        Task<User> LoginAsync(string username, string password);
    }
}
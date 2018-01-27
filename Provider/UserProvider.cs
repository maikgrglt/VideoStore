using System;
using System.Threading.Tasks;
using Provider.Contracts;
using VideoStore.Controller;
using VideoStore.Models;
using VideoStore.Controller.Contracts;

namespace Provider
{
    public class UserProvider : IUserProvider
    {
        private IDatabaseProvider _dbProvider;
        private IUserController _userController;

        public User Login(string username, string password)
        {
            using (var scope = _dbProvider.DataAccess.GetScope())
            {
                return _userController.Login(scope, username, password);
            }
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await Task.Factory.StartNew(() => Login(username, password));
        }

        public UserProvider(IDatabaseProvider dbProvider)
        {
            if (dbProvider == null)
                throw new ArgumentNullException(nameof(dbProvider));

            _dbProvider = dbProvider;
            _userController = new UserController();
        }
    }
}
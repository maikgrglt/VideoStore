using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VideoStore.Controller.Contracts;
using VideoStore.Models;
using VideoStore.Repositories;
using Security;

namespace VideoStore.Controller
{
    public class UserController : IUserController
    {
        private UserRepo _userRepo;

        public User Login(SQLiteConnection connection ,string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));


            var hashedPass = new Sha256Encryption().GenerateSha256Hash(password);

            return _userRepo.Login(connection, username, hashedPass);
        }


        public UserController()
        {
            _userRepo = new UserRepo();
        }
    }
}

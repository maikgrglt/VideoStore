using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VideoStore.Models;

namespace VideoStore.Repositories
{
    public class UserRepo
    {
        public User Login(SQLiteConnection connection, string username, string password)
        {
            return connection.Table<User>().FirstOrDefault(u => u.Name.ToLower().Equals(username.ToLower()) && u.Password.Equals(password));
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;

namespace VideoStore.Repositories
{
    public static class AddressRepo
    {
        public static IEnumerable<Address> GetAll(SQLiteConnection connection)
        {
            return connection.Table<Address>().ToList();
        }

        public static Address Get(SQLiteConnection connection, int id)
        {
            return connection.Table<Address>().FirstOrDefault(a => a.Id.Equals(id));
        }

        public static void Add(SQLiteConnection connection, Address address)
        {
            connection.Insert(address);
        }

        public static void Update(SQLiteConnection connection, Address address)
        {
            connection.Update(address);
        }

        public static void Delete(SQLiteConnection connection, Address address)
        {
            connection.Delete(address);
        }
    }
}

using SQLite;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Models;

namespace VideoStore.Repositories
{
    public static class CheckoutRepo
    {
        public static IEnumerable<Checkout> GetAll(SQLiteConnection connection)
        {
            return connection.Table<Checkout>().ToList();
        }

        public static Checkout Get(SQLiteConnection connection, int id)
        {
            return connection.Table<Checkout>().FirstOrDefault(a => a.Id.Equals(id));
        }

        public static void Add(SQLiteConnection connection, Checkout checkout)
        {
            connection.Insert(checkout);
        }

        public static void Update(SQLiteConnection connection, Checkout checkout)
        {
            connection.Update(checkout);
        }

        public static void Delete(SQLiteConnection connection, Checkout checkout)
        {
            connection.Delete(checkout);
        }
    }
}

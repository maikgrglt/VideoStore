using SQLite;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Models;

namespace VideoStore.Repositories
{
    public static class CustomerRepo
    {
        public static IEnumerable<Customer> GetAll(SQLiteConnection connection)
        {
            return connection.Table<Customer>().ToList();
        }

        public static Customer Get(SQLiteConnection connection, int id)
        {
            return connection.Table<Customer>().FirstOrDefault(c => c.Id.Equals(id));
        }

        public static void Add(SQLiteConnection connection, Customer customer)
        {
            connection.Insert(customer);
        }

        public static void Update(SQLiteConnection connection, Customer customer)
        {
            connection.Update(customer);
        }

        public static void Delete(SQLiteConnection connection, Customer customer)
        {
            connection.Delete(customer);
        }

        public static IEnumerable<Video> GetVideos(SQLiteConnection connection, Customer customer)
        {
            return (from v in connection.Table<Video>()
                   join c in connection.Table<Customer>() on v.CustomerId equals c.Id select v).ToList();
        }

    }
}

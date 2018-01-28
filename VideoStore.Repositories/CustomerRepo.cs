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
            IEnumerable<Video> videos = connection.Table<Video>().ToList();
            return (from v in videos
                   where v.CustomerId == customer.Id select v).ToList();
        }

    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;

namespace VideoStore.Controller.Contracts
{
    public interface ICustomerController
    {
        IList<Customer> GetAll(SQLiteConnection connection);
        Customer Get(SQLiteConnection connection, int id);
        Customer Get(SQLiteConnection connection, Customer customer);
        void Add(SQLiteConnection connection, Customer customer);
        void Update(SQLiteConnection connection, Customer customer);
        void Delete(SQLiteConnection connection, Customer customer);
    }
}

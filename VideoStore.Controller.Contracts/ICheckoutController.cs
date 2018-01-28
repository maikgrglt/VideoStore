using SQLite;
using System.Collections.Generic;
using VideoStore.Models;

namespace VideoStore.Controller.Contracts
{
    public interface ICheckoutController
    {
        IList<Checkout> GetAll(SQLiteConnection connection);
        Checkout Get(SQLiteConnection connection, int id);
        Checkout Get(SQLiteConnection connection, Checkout checkout);
        void Add(SQLiteConnection connection, Checkout checkout);
        void Update(SQLiteConnection connection, Checkout checkout);
        void Delete(SQLiteConnection connection, Checkout checkout);
    }
}

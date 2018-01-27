using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;

namespace VideoStore.Controller.Contracts
{
    public interface IAddressController
    {
        IList<Address> GetAll(SQLiteConnection connection);
        Address Get(SQLiteConnection connection, int id);
        Address Get(SQLiteConnection connection, Address address);
        void Add(SQLiteConnection connection, Address address);
        void Update(SQLiteConnection connection, Address address);
        void Delete(SQLiteConnection connection, Address address);
    }
}

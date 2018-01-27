using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Models;
using VideoStore.Repositories;
using VideoStore.Controller.Contracts;

namespace VideoStore.Controller
{
    public class AddressController: IAddressController
    {
        public Address Get(SQLiteConnection connection, int id)
        {
            if(id == 0)
            {
                throw new InvalidOperationException("id is 0");
            }
            return AddressRepo.Get(connection, id);
        }

        public Address Get(SQLiteConnection connection, Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException("customer is null");
            }
            return Get(connection, customer.AddressId);
        }

        public IList<Address> GetAll(SQLiteConnection connection)
        {
            if(connection == null)
            {
                throw new ArgumentNullException("connection is null");
            }
            return AddressRepo.GetAll(connection).ToList();
        }

        public void Add(SQLiteConnection connection, Address address)
        {
            if(address == null)
            {
                throw new ArgumentNullException("address is null");
            }
            if(connection == null)
            {
                throw new ArgumentNullException("connection is null");
            }
            AddressRepo.Add(connection, address);
        }  

        public void Update(SQLiteConnection connection, Address address)
        {
            if(connection == null)
            {
                throw new ArgumentNullException("connection is null");
            }
            if(address == null)
            {
                throw new ArgumentNullException("argument is null");
            }
            if(address.Id == 0)
            {
                throw new InvalidOperationException("address is not saved in Database");
            }
            AddressRepo.Update(connection, address);
        }        

        public void Delete(SQLiteConnection connection, Address address)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection is null");
            }
            if (address == null)
            {
                throw new ArgumentNullException("argument is null");
            }
            if (address.Id == 0)
            {
                throw new InvalidOperationException("address is not saved in Database");
            }
            AddressRepo.Delete(connection, address);
        }

        public Address Get(SQLiteConnection connection, Address address)
        {
            if(address == null)
            {
                throw new ArgumentNullException("address is null");
            }
            return Get(connection, address.Id);
        }
    }
}
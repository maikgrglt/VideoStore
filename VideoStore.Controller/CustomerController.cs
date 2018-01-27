using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Controller.Contracts;
using VideoStore.Models;
using VideoStore.Repositories;

namespace VideoStore.Controller
{
    public class CustomerController: ICustomerController
    {
        public IList<Customer> GetAll(SQLiteConnection connection)
        {
            return CustomerRepo.GetAll(connection).ToList();
        }        

        public Customer Get(SQLiteConnection connection, int id)
        {
            return CustomerRepo.Get(connection, id);
        }

        public Customer Get(SQLiteConnection connection, Customer customer)
        {
            if(customer.Id == 0)
            {
                throw new InvalidOperationException("customer.Id is 0");
            }
            return Get(connection, customer.Id);
        }

        public void Add(SQLiteConnection connection, Customer customer)
        {
            CustomerRepo.Add(connection, customer);
        }

        public void Update(SQLiteConnection connection, Customer customer)
        {
            CustomerRepo.Update(connection, customer);
        }

        public void Delete(SQLiteConnection connection, Customer customer)
        {
            CustomerRepo.Delete(connection, customer);
        }
    }
}
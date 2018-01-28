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
        private List<Customer> _customers = new List<Customer>();
        public IList<Customer> GetAll(SQLiteConnection connection)
        {
            connection.InsertAll(_customers);
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

        public IEnumerable<Video> GetVideo(SQLiteConnection connection, Customer customer)
        {
            return CustomerRepo.GetVideos(connection, customer);
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
        
        public CustomerController()
        {
            var customer = new Customer()
            {
                Firstname = "Tobias",
                Lastname = "Testing",
                Debts = 0,
                Disabled = false
            };
            _customers.Add(customer);
            _customers.Add(customer);
            _customers.Add(customer);

        }
    }
}
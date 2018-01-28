using System.Collections.Generic;
using VideoStore.Models;

namespace Provider.Contracts
{
    public interface ICustomerProvider
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Video> GetCustomerVideos(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}
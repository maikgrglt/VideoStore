using System.Collections.Generic;
using VideoStore.Models;

namespace Provider.Contracts
{
    public interface ICustomerProvider
    {
        IEnumerable<Customer> GetAllCustomers();
    }
}
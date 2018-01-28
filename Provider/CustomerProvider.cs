using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.Contracts;
using VideoStore.Controller;
using VideoStore.Controller.Contracts;
using VideoStore.Models;

namespace Provider
{
    public class CustomerProvider : ICustomerProvider
    {
        private IDatabaseProvider _dbProvider;
        private ICustomerController _customerController;

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var scope = _dbProvider.DataAccess.GetScope())
            {
                return _customerController.GetAll(scope);
            }
        }

        public CustomerProvider(IDatabaseProvider dbProvider)
        {
            if (dbProvider == null)
                throw new ArgumentNullException(nameof(dbProvider));

            _dbProvider = dbProvider;
            _customerController = new CustomerController();
        }
    }
}

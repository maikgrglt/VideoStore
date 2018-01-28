using Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Controller;
using VideoStore.Controller.Contracts;
using VideoStore.Models;

namespace Provider
{
    public class CheckoutProvider : ICheckoutProvider
    {
        private IDatabaseProvider _dbProvider;
        private ICheckoutController _checkoutController;

        public void AddCheckout(Checkout checkout)
        {
            using (var scope = _dbProvider.DataAccess.GetScope())
            {
                _checkoutController.Add(scope, checkout);
            }
        }

        public void UpdateCheckout(Checkout checkout)
        {
            using (var scope = _dbProvider.DataAccess.GetScope())
            {
                _checkoutController.Update(scope, checkout);
            }
        }

        public void DeleteCheckout(Checkout checkout)
        {
            using (var scope = _dbProvider.DataAccess.GetScope())
            {
                _checkoutController.Delete(scope, checkout);
            }
        }

        public Checkout GetCheckout(int id = 1)
        {
            using (var scope = _dbProvider.DataAccess.GetScope())
            {
                return _checkoutController.Get(scope, id);
            }
        }

        public CheckoutProvider(IDatabaseProvider dbProvider)
        {
            if (dbProvider == null)
                throw new ArgumentNullException(nameof(dbProvider));

            _dbProvider = dbProvider;
            _checkoutController = new CheckoutController();
        }
    }
}

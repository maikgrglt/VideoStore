using Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoStore.Models;
using VideoStore.ViewModels.Contracts;

namespace VideoStore.ViewModels
{
    public class PayDebtsViewModel: ViewModelBase, IModalDialog
    {
        private IProviderFacade _facade;

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        private Checkout _checkout;

        public Checkout Checkout
        {
            get { return _checkout; }
            set { _checkout = value; }
        }

        private double _money;

        public double Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public ModalResult ModalResult { get; set; }

        public ICommand PayDebtsCommand { get; }

        private void PayDebts(object obj)
        {
            _customer.Debts -= _money;
            _checkout.Money += _money;
            if(_customer.Debts < 0)
            {
                _checkout.Money += _customer.Debts;
                _customer.Debts = 0;
            }
            _facade.CustomerProvider.UpdateCustomer(_customer);
            _facade.CheckoutProvider.UpdateCheckout(_checkout);
            ModalResult = ModalResult.Ok;
        }

        public PayDebtsViewModel(IProviderFacade facade, Customer customer)
        {
            if (facade == null)
                throw new ArgumentNullException(nameof(facade));
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            PayDebtsCommand = new RelayCommand<object>(PayDebts);
            _facade = facade;
            _customer = customer;
            _checkout = _facade.CheckoutProvider.GetCheckout();
        }
    }
}

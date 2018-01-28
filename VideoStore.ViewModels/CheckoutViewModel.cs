using Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VideoStore.Models;
using VideoStore.ViewModels.Contracts;

namespace VideoStore.ViewModels
{
    public class CheckoutViewModel: ViewModelBase, IDialog
    {
        private IProviderFacade _facade;
        public EventHandler<Customer> CustomerSelected;

        private List<Customer> _customers;

        public List<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; OnPropertyChanged(); }
        }

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value;
                  CanPay = !(_selectedCustomer.Disabled);
                  OnPropertyChanged(); }
        }

        private bool _canPay;
        public bool CanPay {
            get
            {
                return _canPay;
            }
            set
            {
                _canPay = value;
                OnPropertyChanged();
            }
        }

        private Checkout _checkout;

        public Checkout Checkout
        {
            get { return _checkout; }
            set { _checkout = value; OnPropertyChanged(); }
        }


        private string _search;

        public string Search
        {
            get { return _search; }
            set { _search = value; OnPropertyChanged(); }
        }

        public CheckoutViewModel(IProviderFacade facade)
        {
            if (facade == null)
                throw new ArgumentNullException(nameof(facade));
            _facade = facade;
            Customers = _facade.CustomerProvider.GetAllCustomers().ToList();
            _checkout = facade.CheckoutProvider.GetCheckout();
            DisableCustomerCommand = new RelayCommand<object>(DisableCustomer);
            PayDebtsCommand = new RelayCommand<object>(PayDebts);
        }

        public ICommand DisableCustomerCommand { get; }
        public ICommand PayDebtsCommand { get; }

        private void DisableCustomer(object obj)
        {
            if (_selectedCustomer == null)
                return;
            _selectedCustomer.Disabled = !(_selectedCustomer.Disabled);
            _facade.CustomerProvider.UpdateCustomer(_selectedCustomer);
        }

        private void PayDebts(object obj)
        {
            if (_selectedCustomer == null)
                return;
            CustomerSelected?.Invoke(this, _selectedCustomer);
        }
        

    }
}

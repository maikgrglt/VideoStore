using System;
using System.Collections.ObjectModel;
using System.Linq;
using Provider.Contracts;
using VideoStore.Models;
using VideoStore.ViewModels.Contracts;

namespace VideoStore.ViewModels
{
    public class DebitViewModel : ViewModelBase, IModalDialog
    {
        private IProviderFacade _facade;
        public ModalResult ModalResult { get; set; }

        private ObservableCollection<Customer> _customers;

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set { _customers = value; OnPropertyChanged(); }
        }

        public DebitViewModel(IProviderFacade facade)
        {
            if (facade == null)
                throw new ArgumentNullException(nameof(facade));

            _facade = facade;
            Customers = new ObservableCollection<Customer>(facade.CustomerProvider.GetAllCustomers());
        }
    }
}
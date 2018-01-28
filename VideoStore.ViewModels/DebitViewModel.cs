using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
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

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                if (_selectedCustomer != null)
                    OverViewVisible = true;
                OnPropertyChanged();
            }
        }

        public Video Video { get; set; }

        private bool _overViewVisible;
        public bool OverViewVisible
        {
            get => _overViewVisible;
            set { _overViewVisible = value; OnPropertyChanged(); }
        }

        public ICommand CancelCommand { get; }

        public ICommand ConfirmCommand { get; }

        public DebitViewModel(IProviderFacade facade, Video video)
        {
            if (facade == null)
                throw new ArgumentNullException(nameof(facade));

            _facade = facade;
            Video = video;
            CancelCommand = new RelayCommand<object>(Cancel);
            ConfirmCommand = new RelayCommand<object>(Confirm);
            Customers = new ObservableCollection<Customer>(facade.CustomerProvider.GetAllCustomers());
        }

        private void Confirm(object obj)
        {
            SelectedCustomer.Debts += Video.Price;
            Video.CustomerId = SelectedCustomer.Id;
            Video.IsAvailable = false;
            _facade.VideoProvider.UpdateVideo(Video);
            _facade.CustomerProvider.UpdateCustomer(SelectedCustomer);
            _facade.ViewProvider.ShowMessageBox("Fee successfully debited from Customer.");
        }

        private void Cancel(object obj)
        {
            _facade.ViewProvider.Close(this);
        }
    }
}
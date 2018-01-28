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

        private List<Video> _videos;

        public List<Video> Videos
        {
            get { return _videos; }
            set { _videos = value; OnPropertyChanged(); }
        }

        private Video _selectedVideo;

        public Video SelectedVideo
        {
            get { return _selectedVideo; }
            set { _selectedVideo = value;
                  if (value == null)
                    CanPay = false;
                  else
                    CanPay = true;
                  OnPropertyChanged();
            }
        }



        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged(); }
        }

        private bool _canPay;

        public bool CanPay
        {
            get { return _canPay; }
            set { _canPay = value; OnPropertyChanged(); }
        }


        private Checkout _checkout;

        public Checkout Checkout
        {
            get { return _checkout; }
            set { _checkout = value; OnPropertyChanged(); }
        }

        public ModalResult ModalResult { get; set; }

        public ICommand PayDebtsCommand { get; }

        private void PayDebts(object obj)
        {
            _customer.Debts -= _selectedVideo.Price;
            _checkout.Money += _selectedVideo.Price;
            if(_customer.Debts < 0)
            {
                _checkout.Money += _customer.Debts;
                _customer.Debts = 0;
            }
            _selectedVideo.CustomerId = 0;
            _selectedVideo.IsAvailable = true;
            _facade.VideoProvider.UpdateVideo(_selectedVideo);
            _facade.CustomerProvider.UpdateCustomer(_customer);
            _facade.CheckoutProvider.UpdateCheckout(_checkout);
            _videos = _facade.CustomerProvider.GetCustomerVideos(_customer).ToList();
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
            _videos = _facade.CustomerProvider.GetCustomerVideos(_customer).ToList();
        }
    }
}

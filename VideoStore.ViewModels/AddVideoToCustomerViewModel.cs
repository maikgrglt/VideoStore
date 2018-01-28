using System;
using System.Windows.Input;
using Provider.Contracts;
using VideoStore.Models;
using VideoStore.ViewModels.Contracts;

namespace VideoStore.ViewModels
{
    public class AddVideoToCustomerViewModel : ViewModelBase, IModalDialog
    {
        private IProviderFacade _facade;

        public ICommand AbortCommand { get; }

        private Video _video;

        public Video Video
        {
            get => _video;
            set { _video = value; OnPropertyChanged(); }
        }

        private int _count;

        public int Count
        {
            get => _count;
            set
            {
                var temp = _count;
                _count = value;
                if (temp > Count)
                    TotalPrice -= _video.Price;
                else
                    TotalPrice += _video.Price;
                OnPropertyChanged();
            }
        }

        private double _totalPrice;

        public double TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                _totalPrice = Math.Round(_totalPrice, 2);
                OnPropertyChanged();
            }
        }

        public ModalResult ModalResult { get; set; }


        public AddVideoToCustomerViewModel(IProviderFacade facade, Video video)
        {
            if (facade == null)
                throw new ArgumentNullException(nameof(facade));
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            _facade = facade;
            _video = video;
            Count = 1;
            TotalPrice = video.Price;
        }
    }
}
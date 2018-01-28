using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Input;
using Provider.Contracts;
using VideoStore.Models;
using VideoStore.ViewModels.Contracts;

namespace VideoStore.ViewModels
{
    public class VideoSelectionViewModel : ViewModelBase, IDialog
    {
        private IProviderFacade _facade;

        public EventHandler<Video> VideoSelected;
        public EventHandler CustomerPayEvent;

        private User _user;
        public User User
        {
            get => _user;
            set { _user = value; OnPropertyChanged(); }
        }

        private List<Video> _videos;
        public List<Video> Videos
        {
            get => _videos;
            set { _videos = value; OnPropertyChanged(); }
        }

        private Video _selectedVideo;
        public Video SelectedVideo
        {
            get => _selectedVideo;
            set { _selectedVideo = value; OnPropertyChanged(); }
        }

        public ICommand AddVideoCommand { get; }
        public ICommand CustomerPayCommand { get; }
        public ICommand DeleteVideoCommand { get; }

        public VideoSelectionViewModel(IProviderFacade facade, User user)
        {
            if (facade == null)
                throw new ArgumentNullException(nameof(facade));
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _facade = facade;
            User = user;
            AddVideoCommand = new RelayCommand<object>(AddVideo);
            DeleteVideoCommand = new RelayCommand<object>(DeleteVideo);
            CustomerPayCommand = new RelayCommand<object>(CustomerPay);

            Videos = new List<Video>(_facade.VideoProvider.GetAllVideos());
        }

        private void AddVideo(object obj)
        {
            if (_selectedVideo == null)
                return;
            if (!_selectedVideo.IsAvailable)
            {
                _facade.ViewProvider.ShowMessageBox("Sorry, the movie is not available.");
                return;
            }

            VideoSelected?.Invoke(this, _selectedVideo);
        }

        private void CustomerPay(object obj)
        {
            CustomerPayEvent?.Invoke(this, null);
        }

        private void DeleteVideo(object obj)
        {
            if (_selectedVideo == null)
                return;
            _facade.VideoProvider.DeleteVideo(_selectedVideo);
            Videos = new List<Video>(_facade.VideoProvider.GetAllVideos());
        }
    }
}
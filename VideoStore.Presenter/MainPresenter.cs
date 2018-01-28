using System;
using Provider;
using Provider.Contracts;
using VideoStore.Models;
using VideoStore.ViewModels;

namespace VideoStore.Presenter
{
    public class MainPresenter
    {
        private readonly IProviderFacade _facade;
        private VideoSelectionViewModel _videoSelectionViewModel;

        public MainPresenter()
        {
            _facade = new ProviderFacade();           
        }

        public void ShowLogin()
        {
            var loginDialog = new LoginViewModel(_facade);
            loginDialog.LoginCompleted += OnLoginCompleted;
            _facade.ViewProvider.ShowDialog(loginDialog);
        }

        private void OnLoginCompleted(object sender, User user)
        {
            _videoSelectionViewModel = new VideoSelectionViewModel(_facade, user);
            _videoSelectionViewModel.VideoSelected += OnVideoSelected;
            _facade.ViewProvider.ShowDialog(_videoSelectionViewModel);
        }

        private void OnVideoSelected(object sender, Video video)
        {
            var addVideoToCustomerViewModel = new AddVideoToCustomerViewModel(_facade, video);
            addVideoToCustomerViewModel.ConfirmationCompleted += OnConfirmationCompleted;
            _facade.ViewProvider.ShowDialogModal(addVideoToCustomerViewModel);
        }

        private void OnConfirmationCompleted(object sender, Video video)
        {
            
        }
    }
}

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
            _videoSelectionViewModel.CustomerPayEvent += OnCustomerPay;
            _facade.ViewProvider.ShowDialog(_videoSelectionViewModel);
        }

        private void OnCustomerPay(object sender, object eventArgs)
        {
            var checkoutViewModel = new CheckoutViewModel(_facade);
            checkoutViewModel.CustomerSelected += OnCustomerSelected;
            _facade.ViewProvider.ShowDialog(checkoutViewModel);
        }

        private void OnVideoSelected(object sender, Video video)
        {
            var addVideoToCustomerViewModel = new AddVideoToCustomerViewModel(_facade, video);
            addVideoToCustomerViewModel.ConfirmationCompleted += OnConfirmationCompleted;
            _facade.ViewProvider.ShowDialogModal(addVideoToCustomerViewModel);
        }

        private void OnCustomerSelected(object sender, Customer customer)
        {
            var payDebtsViewModel = new PayDebtsViewModel(_facade, customer);
            _facade.ViewProvider.ShowDialogModal(payDebtsViewModel);
        }

        private void OnConfirmationCompleted(object sender, Video video)
        {
            var debitViewModel = new DebitViewModel(_facade, video);
            _facade.ViewProvider.ShowDialogModal(debitViewModel);
        }
    }
}

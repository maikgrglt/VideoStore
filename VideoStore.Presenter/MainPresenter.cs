using Provider;
using Provider.Contracts;
using VideoStore.ViewModels;

namespace VideoStore.Presenter
{
    public class MainPresenter
    {
        private readonly IProviderFacade _facade;

        public MainPresenter()
        {
            _facade = new ProviderFacade();           
        }

        public void ShowLogin()
        {
            var loginDialog = new LoginViewModel(_facade);
            _facade.ViewProvider.ShowDialog(loginDialog);
        }

    }
}

using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Provider.Contracts;
using VideoStore.Models;
using VideoStore.ViewModels.Contracts;

namespace VideoStore.ViewModels
{
    public class LoginViewModel : ViewModelBase, IDialog
    {
        private readonly IProviderFacade _facade;
        private string _username;
        private string _password;
        private string _loginMessage = string.Empty;
        private bool _isIndeterminate;

        public EventHandler<User> LoginCompleted;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); } 
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string LoginMessage
        {
            get => _loginMessage;
            set { _loginMessage = value; OnPropertyChanged();}
        }

        public bool IsIndeterminate
        {
            get => _isIndeterminate;
            set { _isIndeterminate = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IProviderFacade facade)
        {
            if (facade == null)
                throw new ArgumentNullException(nameof(facade));

            _facade = facade;
            LoginCommand = new RelayCommand<object>(Login);
        }

        private async void Login(object obj)
        {
            IsIndeterminate = true;
            var user = await _facade.UserProvider.LoginAsync(Username, Password);
            IsIndeterminate = false;
            if (user == null)
            {
                LoginMessage = "User konnte nicht gefunden werden.";
                return;
            }

            LoginCompleted?.Invoke(this, user);
            _facade.ViewProvider.Close(this);
        }
    }
}

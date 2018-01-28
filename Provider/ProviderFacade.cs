using Provider.Contracts;

namespace Provider
{
    public class ProviderFacade : IProviderFacade
    {
        private IViewProvider _viewProvider;

        public IViewProvider ViewProvider
        {
            get => _viewProvider;
            set => _viewProvider = value;
        }

        private IDatabaseProvider _databaseProvider;

        public IDatabaseProvider DatabaseProvider
        {
            get => _databaseProvider;
            set => _databaseProvider = value;
        }

        private IUserProvider _userProvider;

        public IUserProvider UserProvider
        {
            get => _userProvider;
            set => _userProvider = value;
        }

        public IVideoProvider VideoProvider { get; set; }

        public ICustomerProvider CustomerProvider { get; set; }

        public ProviderFacade()
        {
            DatabaseProvider = new DatabaseProvider();
            ViewProvider = new ViewProvider();           
            UserProvider = new UserProvider(DatabaseProvider);
            VideoProvider = new VideoProvider(DatabaseProvider);
            CustomerProvider = new CustomerProvider(DatabaseProvider);
        }
    }
}
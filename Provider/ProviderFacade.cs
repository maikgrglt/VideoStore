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

        public ProviderFacade()
        {
            DatabaseProvider = new DatabaseProvider();
            ViewProvider = new ViewProvider();           
            UserProvider = new UserProvider(DatabaseProvider);
        }
    }
}
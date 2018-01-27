namespace Provider.Contracts
{
    public interface IProviderFacade
    {
        IViewProvider ViewProvider { get; set; }
        IDatabaseProvider DatabaseProvider { get; set; }
        IUserProvider UserProvider { get; set; }
    }
}

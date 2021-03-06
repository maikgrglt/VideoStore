﻿namespace Provider.Contracts
{
    public interface IProviderFacade
    {
        IViewProvider ViewProvider { get; set; }
        IDatabaseProvider DatabaseProvider { get; set; }
        IUserProvider UserProvider { get; set; }
        IVideoProvider VideoProvider { get; set; }
        ICustomerProvider CustomerProvider { get; set; }
        ICheckoutProvider CheckoutProvider { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Models;

namespace Provider.Contracts
{
    public interface ICheckoutProvider
    {
        Checkout GetCheckout(int id = 1);
        void AddCheckout(Checkout checkout);
        void UpdateCheckout(Checkout checkout);
        void DeleteCheckout(Checkout checkout);
    }
}

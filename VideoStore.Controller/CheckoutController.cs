using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Controller.Contracts;
using VideoStore.Models;
using VideoStore.Repositories;

namespace VideoStore.Controller
{
    public class CheckoutController: ICheckoutController
    {
        public IList<Checkout> GetAll(SQLiteConnection connection)
        {
            return CheckoutRepo.GetAll(connection).ToList();
        }

        public Checkout Get(SQLiteConnection connection, int id)
        {
            return CheckoutRepo.Get(connection, id);
        }

        public Checkout Get(SQLiteConnection connection, Checkout checkout)
        {
            if (checkout.Id == 0)
            {
                throw new InvalidOperationException("checkout.Id is 0");
            }
            return Get(connection, checkout.Id);
        }

        public void Add(SQLiteConnection connection, Checkout checkout)
        {
            CheckoutRepo.Add(connection, checkout);
        }

        public void Update(SQLiteConnection connection, Checkout checkout)
        {
            CheckoutRepo.Update(connection, checkout);
        }

        public void Delete(SQLiteConnection connection, Checkout checkout)
        {
            CheckoutRepo.Delete(connection, checkout);
        }
    }
}

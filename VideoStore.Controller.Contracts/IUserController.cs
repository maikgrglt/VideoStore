﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VideoStore.Models;

namespace VideoStore.Controller.Contracts
{
    public interface IUserController
    {
        User Login(SQLiteConnection connection, string username, string password);
        void Add(SQLiteConnection connection, User user);
        void Update(SQLiteConnection connection, User user);
        void Delete(SQLiteConnection connection, User user);
    }
}

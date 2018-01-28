using System.Collections.Generic;
using Provider.Contracts;
using Security;
using System.IO;
using System.Reflection;
using VideoStore.DA;
using VideoStore.Models;

namespace Provider
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly string _databasePath;
        private bool _exists;
        private readonly DataAccess _dataAccess;

        public DataAccess DataAccess => _dataAccess;

        public DatabaseProvider()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _databasePath = Path.Combine(outputDirectory, "SqliteDatabase.DB");
            _exists = File.Exists(_databasePath);
            _dataAccess = new DataAccess(_databasePath);
            if (!_exists)
                CreateTables();
        }

        private void CreateTables()
        {
            var conn = DataAccess.GetScope();
            conn.CreateTable<User>();
            conn.CreateTable<Address>();
            conn.CreateTable<Customer>();
            conn.CreateTable<Video>();

            var standardUser = new User();
            standardUser.Name = "jessie";
            var pass = new Sha256Encryption().GenerateSha256Hash("test");
            standardUser.Password = pass;
            conn.Insert(standardUser, typeof(User));
        }
    }
}

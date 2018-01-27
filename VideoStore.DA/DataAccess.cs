using System;
using SQLite;


namespace VideoStore.DA
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection _sqliteConnection;
        private SQLiteAsyncConnection _sqliteAsyncConnection;
        private string _databasePath;

        public DataAccess(string databasePath)
        {
            if (string.IsNullOrWhiteSpace(databasePath))
                throw new ArgumentException("Cannot create DataAccess. Given databasePath is invalid.", nameof(databasePath));

            _databasePath = databasePath;
        }

        public SQLiteConnection GetScope()
        {
            return new SQLiteConnection(_databasePath);
        }

        public SQLiteAsyncConnection GetAsyncScope()
        {
            return _sqliteAsyncConnection;
        }

        public void Dispose()
        {
            _sqliteConnection?.Dispose();
        }
    }
}

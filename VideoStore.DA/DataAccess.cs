using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.DA
{
    public class DataAccess
    {
        private SQLiteConnection _sqliteConnection;

        public DataAccess(string databasePath)
        {
            if (string.IsNullOrWhiteSpace(databasePath))
                throw new ArgumentException("Cannot create DataAccess. Given databasePath is invalid.", nameof(databasePath));

            _sqliteConnection = new SQLiteConnection(databasePath, true);
        }

        public SQLiteConnection GetScope()
        {
            return _sqliteConnection;
        }
    }
}

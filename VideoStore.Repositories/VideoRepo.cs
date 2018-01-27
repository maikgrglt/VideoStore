using SQLite;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Models;

namespace VideoStore.Repositories
{
    public static class VideoRepo
    {
        public static IEnumerable<Video> GetAll(SQLiteConnection connection)
        {
            return connection.Table<Video>().ToList();
        }

        public static Video Get(SQLiteConnection connection, int id)
        {
            return connection.Table<Video>().FirstOrDefault(v => v.Id.Equals(id));
        }

        public static void Add(SQLiteConnection connection, Video video)
        {
            connection.Insert(video);
        }

        public static void Update(SQLiteConnection connection, Video video)
        {
            connection.Update(video);
        }

        public static void Delete(SQLiteConnection connection, Video video)
        {
            connection.Delete(video);
        }
    }
}

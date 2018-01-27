using SQLite;
using System.Collections.Generic;
using VideoStore.Models;

namespace VideoStore.Controller.Contracts
{
    public interface IVideoController
    {
        IList<Video> GetAll(SQLiteConnection connection);
        Video Get(SQLiteConnection connection, int id);
        Video Get(SQLiteConnection connection, Video video);
        void Add(SQLiteConnection connection, Video video);
        void Update(SQLiteConnection connection, Video video);
        void Delete(SQLiteConnection connection, Video video);
    }
}

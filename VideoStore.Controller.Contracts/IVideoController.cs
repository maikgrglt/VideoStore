using System.Collections.Generic;
using SQLite;
using VideoStore.Models;

namespace VideoStore.Controller.Contracts
{
    public interface IVideoController
    {
        IEnumerable<Video> GetAllVideos(SQLiteConnection scope);
    }
}
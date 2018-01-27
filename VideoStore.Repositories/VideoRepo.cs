using System.Collections.Generic;
using System.Linq;
using SQLite;
using VideoStore.Models;

namespace VideoStore.Repositories
{
    public class VideoRepo
    {
        public IEnumerable<Video> GetAllVideos(SQLiteConnection scope)
        {
            return scope.Table<Video>().ToList();
        }    
    }
}
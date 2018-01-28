using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using VideoStore.Controller.Contracts;
using VideoStore.Models;
using VideoStore.Repositories;

namespace VideoStore.Controller
{
    public class VideoController: IVideoController
    {
        private IList<Video> videos = new List<Video>();
        public VideoController()
        {
            var imgDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            videos.Add(new Video()
            {
                Price = 20.3,
                Length = 120,
                Title = "Fast & Furious",
                CoverPath = imgDir + "\\Images\\fastandfurious.jpg",
                IsAvailable = true
            });
            videos.Add(new Video()
            {
                Price = 10,
                Length = 120,
                Title = "Tucker and Dale vs Evil",
                CoverPath = imgDir + "\\Images\\tuckerdalevsevil.jpg",
                IsAvailable = true
            });
            videos.Add(new Video()
            {
                Price = 20,
                Length = 420,
                Title = "We did it",
                IsAvailable = true
            });
        }
        public IList<Video> GetAll(SQLiteConnection connection)
        {
            connection.InsertAll(videos, typeof(Video));
            return VideoRepo.GetAll(connection).ToList();
        }

        public IEnumerable<Video> GetAllVideos(SQLiteConnection scope)
	{
            if (scope == null)
                throw new ArgumentNullException(nameof(scope));

            return VideoRepo.GetAllVideos(scope);
        }

        public Video Get(SQLiteConnection connection, int id)
        {
            return VideoRepo.Get(connection, id);
        }

        public Video Get(SQLiteConnection connection, Video video)
        {
            if (video.Id == 0)
            {
                throw new InvalidOperationException("video.Id is 0");
            }
            return Get(connection, video.Id);
        }

        public void Add(SQLiteConnection connection, Video video)
        {
            VideoRepo.Add(connection, video);
        }

        public void Update(SQLiteConnection connection, Video video)
        {
            VideoRepo.Update(connection, video);
        }

        public void Delete(SQLiteConnection connection, Video video)
        {
            VideoRepo.Delete(connection, video);
        }
    }
}

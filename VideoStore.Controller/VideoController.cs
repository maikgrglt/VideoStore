using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Controller.Contracts;
using VideoStore.Models;
using VideoStore.Repositories;

namespace VideoStore.Controller
{
    class VideoController: IVideoController
    {
        public IList<Video> GetAll(SQLiteConnection connection)
        {
            return VideoRepo.GetAll(connection).ToList();
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

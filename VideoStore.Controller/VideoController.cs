using System;
using System.Collections.Generic;
using SQLite;
using VideoStore.Controller.Contracts;
using VideoStore.Models;
using VideoStore.Repositories;

namespace VideoStore.Controller
{
    public class VideoController : IVideoController
    {
        private readonly VideoRepo _videoRepo;

        public IEnumerable<Video> GetAllVideos(SQLiteConnection scope)
        {
            if (scope == null)
                throw new ArgumentNullException(nameof(scope));

            return _videoRepo.GetAllVideos(scope);
        }

        public VideoController()
        {
            _videoRepo = new VideoRepo();
        }
    }
}
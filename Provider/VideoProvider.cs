using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Provider.Contracts;
using VideoStore.Controller;
using VideoStore.Controller.Contracts;
using VideoStore.Models;

namespace Provider
{
    public class VideoProvider : IVideoProvider
    {
        private IDatabaseProvider _dbProvider;
        private IVideoController _videoController;

        public IEnumerable<Video> GetAllVideos()
        {
            using (var scope = _dbProvider.DataAccess.GetScope())
            {
                return _videoController.GetAll(scope);
            }
        }

        public void AddVideo(Video video)
        {
            using(var scope = _dbProvider.DataAccess.GetScope())
            {
                _videoController.Add(scope, video);
            }
        }

        public void UpdateVideo(Video video)
        {
            using(var scope = _dbProvider.DataAccess.GetScope())
            {
                _videoController.Update(scope, video);
            }
        }

        public void DeleteVideo(Video video)
        {
            using(var scope = _dbProvider.DataAccess.GetScope())
            {
                _videoController.Delete(scope, video);
            }
        }

        public VideoProvider(IDatabaseProvider dbProvider)
        {
            if (dbProvider == null)
                throw new ArgumentNullException(nameof(dbProvider));

            _dbProvider = dbProvider;
            _videoController = new VideoController();
        }
    }
}
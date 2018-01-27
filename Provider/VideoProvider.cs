using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Provider.Contracts;
using VideoStore.Controller;
using VideoStore.Models;

namespace Provider
{
    public class VideoProvider : IVideoProvider
    {
        private IDatabaseProvider _dbProvider;
        private VideoController _videoController;

        public IEnumerable<Video> GetAllVideos()
        {
            using (var scope = _dbProvider.DataAccess.GetScope())
            {
                return _videoController.GetAllVideos(scope);
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
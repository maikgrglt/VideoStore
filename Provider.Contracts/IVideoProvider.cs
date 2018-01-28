using System.Collections;
using System.Collections.Generic;
using VideoStore.Models;

namespace Provider.Contracts
{
    public interface IVideoProvider
    {
        IEnumerable<Video> GetAllVideos();
        void AddVideo(Video video);
        void UpdateVideo(Video video);
        void DeleteVideo(Video video);
    }
}
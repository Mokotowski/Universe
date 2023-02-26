using Universe.Models;

namespace Universe.Services.Interfaces
{
    public interface IVideoService
    {
        public List<Video> ListVideo();
        public Video Details(ushort id);
        public List<Video> GetSearched(Search search);
    }
}

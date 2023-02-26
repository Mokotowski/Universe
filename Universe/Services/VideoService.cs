using Microsoft.EntityFrameworkCore;
using Universe.Models;
using Universe.Services.Interfaces;

namespace Universe.Services
{
    public class VideoService : IVideoService
    {
        private readonly DbTestContext _context;
        public VideoService(DbTestContext context)
        {
            _context = context;
        }
        public List<Video> ListVideo()
        {
            return _context.Video.ToList();
        }
        public Video Details(ushort id)
        {
            return _context.Video.Find(keyValues: id);
        }
        public List<Video> GetSearched(Search search)
        {
            search.looking = char.ToUpper(search.looking[0]) + search.looking.Substring(1);
            var videos = _context.Video.Where(m => m.Name.Contains(search.looking)).ToList();
            return videos;
        }

    }
}

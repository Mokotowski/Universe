using Microsoft.AspNetCore.Mvc;
using System;
using Universe.Models;
using Universe.Services.Interfaces;

namespace Universe.Controllers
{
    public class VideoController : Controller
    {

        private readonly IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public IActionResult ListVideo()
        {
            var videos = _videoService.ListVideo();
            return View(videos);
        }

        [HttpGet]
        public IActionResult DetailsVideo(ushort id)
        {
            return View(_videoService.Details(id));
        }

        [HttpGet]
        public IActionResult SearchVideo()
        {
            return View();
        }


        [HttpGet]
        public IActionResult SearchVideoResult(Search search)
        {
            var videos = _videoService.GetSearched(search);
            return View(videos);
        }

        [HttpGet]
        public IActionResult PlayVideo(Video video)
        {
            if (video == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(video);
            }
        }
    }
}

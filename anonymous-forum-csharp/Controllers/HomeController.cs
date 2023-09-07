using anonymous_forum_csharp.Data.Repository.IRepository;
using anonymous_forum_csharp.Models;
using anonymous_forum_csharp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace anonymous_forum_csharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITopicRepository _topicRepository;

        public HomeController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public IActionResult Index()
        {
            var topics = _topicRepository.GetAll().ToList();

            var viewModel = new HomeIndexViewModel
            {
                TopicList = topics
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
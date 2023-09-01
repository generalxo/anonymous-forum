using anonymous_forum_csharp.Data;
using anonymous_forum_csharp.Data.Repository;
using anonymous_forum_csharp.Models;
using anonymous_forum_csharp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace anonymous_forum_csharp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var context = new ApplicationDbContext();
            TopicRepository topicRepository = new TopicRepository(context);

            var topics = topicRepository.GetAll().ToList();
            
            var viewModel = new List<HomeIndexViewModel>();

            foreach (var topic in topics)
            {
                var topicViewModel = new HomeIndexViewModel
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    Description = topic.Description
                };

                viewModel.Add(topicViewModel);
            }
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
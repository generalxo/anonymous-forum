using anonymous_forum_csharp.Data;
using Microsoft.AspNetCore.Mvc;

namespace anonymous_forum_csharp.Controllers
{
    public class ThreadController : Controller
    {
        public IActionResult Index(string topicName)
        {
            var context = new ApplicationDbContext();
            var post = context.Posts.ToList();
            var viewModel = new List<>
            return View();
        }
    }
}

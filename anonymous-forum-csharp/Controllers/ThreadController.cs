using anonymous_forum_csharp.Data.Repository.IRepository;
using anonymous_forum_csharp.Models;
using anonymous_forum_csharp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace anonymous_forum_csharp.Controllers
{
    public class ThreadController : Controller
    {
        private readonly IPostRepository _postRepository;

        public ThreadController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var posts = _postRepository.GetByCondition(x => x.TopicId == id);
            if (!posts.Any())
            {
                // Handle error
            }

            var viewModel = CreateViewModel(posts);

            return View(viewModel);
        }

        public IActionResult ThreadPostBox()
        {
            ThreadCreateViewModel viewModel = new();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ThreadPostBox(ThreadCreateViewModel viewModel, int id)
        {
            Console.WriteLine($"id: {id}, text: {viewModel.Text}, title: {viewModel.Title}");

            var post = new PostModel
            {
                Title = viewModel.Title,
                Text = viewModel.Text,
                TopicId = id
            };
            _postRepository.Create(post);

            return RedirectToAction("Index", new { id = id });
        }

        private static ThreadIndexViewModel CreateViewModel(IQueryable<PostModel> posts)
        {
            var viewModel = new ThreadIndexViewModel
            {
                PostList = posts.Select(u => new PostModel { Id = u.Id, Title = u.Title, Text = u.Text, TopicId = u.TopicId }).ToList(),
            };
            return viewModel;
        }
    }
}

using anonymous_forum.Data.Repository;
using anonymous_forum_csharp.Models;
using anonymous_forum_csharp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace anonymous_forum_csharp.Controllers
{
    public class ThreadController : Controller
    {
        private readonly PostRepository _postRepository;

        public ThreadController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        //public IActionResult Index(int id)
        //{
        //    var posts = _postRepository.GetByCondition(x => x.Id == id);
        //    if (!posts.Any())
        //    {
        //        // Handle error
        //    }

        //    var viewModel = CreateViewModel(posts);
        //    ViewBag.Id = viewModel.Post.Id;
        //    return View(viewModel);
        //}
        [HttpGet]
        public IActionResult Index(int id)
        {
            var posts = _postRepository.GetByCondition(x => x.TopicId == id);
            if (!posts.Any())
            {
                // Handle error
            }

            var viewModel = CreateViewModel(posts);
            TempData["Id"] = id; // Store id in TempData

            return View(viewModel);
        }

        public IActionResult ThreadPostBox()
        {
            ThreadCreateViewModel viewModel = new();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ThreadPostBox(ThreadCreateViewModel viewModel)
        {
            int id = (int)TempData["Id"];
            Console.WriteLine($"id: {id}, text: {viewModel.Text}, title: {viewModel.Title}");

            var post = new PostModel
            {
                Title = viewModel.Title,
                Text = viewModel.Text,
                TopicId = id
            };
            _postRepository.Create(post);

            return RedirectToAction("Index", new { id = id }); // Redirect to Index action
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

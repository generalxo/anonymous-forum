using anonymous_forum.Data.Repository.IRepository;
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

        public IActionResult Index(int id)
        {
            var posts = _postRepository.GetByCondition(x => x.Id == id);
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
        public IActionResult ThreadPostBox(ThreadCreateViewModel viewModel)
        {
            //PostModel post = new();
            //post.Text = viewModel.Text;
            //post.Title = viewModel.Title;


            //_postRepository.Create
            return View();
        }

        private static ThreadIndexViewModel CreateViewModel(IQueryable<PostModel> posts)
        {
            var viewModel = new ThreadIndexViewModel
            {
                PostList = posts.Select(u => new PostModel { Id = u.Id, Title = u.Title, Text = u.Text, TopicId = u.TopicId }).ToList(),
                Post = new PostModel()
            };

            return viewModel;
        }
    }
}
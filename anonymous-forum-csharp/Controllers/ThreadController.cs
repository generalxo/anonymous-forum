using anonymous_forum.Data.Repository;
using anonymous_forum_csharp.Data;
using anonymous_forum_csharp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace anonymous_forum_csharp.Controllers
{
    public class ThreadController : Controller
    {

        public IActionResult Index(int id)
        {
            var threadCreateViewModel = new ThreadCreateViewModel();
            var context = new ApplicationDbContext();
            PostRepository postRepository = new PostRepository(context);
            var posts = postRepository.GetByCondition(x => x.Id == id).AsQueryable().Select( u => new { u.Id, u.Title, u.Text, u.TopicId }).ToList();
            var viewmodelList = new List<ThreadIndexViewModel>();
            //var postList = new ThreadIndexViewModel();
            //postList.Posts = posts.ToList();

            

            foreach (var post in posts)
            {
                var viewmodel = new ThreadIndexViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Text = post.Text
                 };
                viewmodelList.Add(viewmodel);
            }

            Tuple<List<ThreadIndexViewModel>, ThreadIndexViewModel> tuple;
            tuple = new Tuple<List<ThreadIndexViewModel>, ThreadIndexViewModel>(viewmodelList, new ThreadIndexViewModel());
            return View(tuple);
        }

        [HttpPost]
        public IActionResult Create()
        {
            var threadCreateViewModel = new ThreadCreateViewModel();
            return View(threadCreateViewModel);
        }

        public IActionResult OnGetPartial() =>
            new PartialViewResult
        {
            ViewName = "ThreadPostBox",
            ViewData = ViewData
        };
    }
}

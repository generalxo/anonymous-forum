using anonymous_forum_csharp.Data.Repository;
using anonymous_forum_csharp.Models.ViewModels;
using anonymous_forum_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using anonymous_forum.Data.Repository;

namespace anonymous_forum_csharp.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentRepository _commentRepository;
        private readonly PostRepository _postRepository;

        public CommentController(CommentRepository commentRepository, PostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }
        public IActionResult Index(int id)
        {
            var comments = _commentRepository.GetByCondition(x => x.PostId == id);
            var post = _postRepository.GetByCondition(x => x.Id == id);
            TempData["Id"] = id; // Store id in TempData
            var viewModel = CreateViewModel(comments, post);

            return View(viewModel);
        }

        private static CommentViewModel CreateViewModel(IQueryable<CommentModel> comments, IQueryable<PostModel> post)
        {
            var viewModel = new CommentViewModel
            {
                CommentList = comments.Select(u => new CommentModel { Id = u.Id, Text = u.Text, PostId = u.PostId }).ToList(),
                Post = post.Select(u => new PostModel { Id = u.Id, Text = u.Text, Title = u.Title }).FirstOrDefault(),
                AddComment = new AddCommentViewModel()
            };
            return viewModel;
        }
        public IActionResult CommentPostBox()
        {
            AddCommentViewModel viewModel = new();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CommentPostBox(AddCommentViewModel viewModel)
        {
            int id = (int)TempData["Id"];
            Console.WriteLine($"id: {id}, text: {viewModel.Text}");

            var comment = new CommentModel
            {
                Text = viewModel.Text,
                PostId = id
            };
            _commentRepository.Create(comment);

            return RedirectToAction("Index", new { id = id }); // Redirect to Index action
        }
    }
}

using anonymous_forum_csharp.Data.Repository;
using anonymous_forum_csharp.Models.ViewModels;
using anonymous_forum_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace anonymous_forum_csharp.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentRepository _commentRepository;

        public CommentController(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public IActionResult Index(int id)
        {
            var comments = _commentRepository.GetByCondition(x => x.PostId == id);
            var viewModel = CreateViewModel(comments);

            return View(viewModel);
        }

        private static CommentViewModel CreateViewModel(IQueryable<CommentModel> comments)
        {
            var viewModel = new CommentViewModel
            {
                CommentList = comments.Select(u => new CommentModel { Id = u.Id, Text = u.Text, PostId = u.PostId }).ToList(),
            };
            return viewModel;
        }
    }
}

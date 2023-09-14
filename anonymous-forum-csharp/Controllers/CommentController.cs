using anonymous_forum_csharp.Data.Repository.IRepository;
using anonymous_forum_csharp.Helpers;
using anonymous_forum_csharp.Models;
using anonymous_forum_csharp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace anonymous_forum_csharp.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentRepository _commentRepository;
		private readonly IPostRepository _postRepository;

		public CommentController(ICommentRepository commentRepository, IPostRepository postRepository)
		{
			_commentRepository = commentRepository;
			_postRepository = postRepository;
		}
		public IActionResult Index(int id)
		{
			var comments = _commentRepository.GetByCondition(x => x.PostId == id);
			var post = _postRepository.GetByCondition(x => x.Id == id);
			
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
		public IActionResult CommentPostBox(AddCommentViewModel viewModel, int id)
		{
			Console.WriteLine($"id: {id}, text: {viewModel.Text}");
			string? ip = Helper.GetIp(HttpContext);
			var comment = new CommentModel
			{
				Text = viewModel.Text,
				IpAdress = ip,
				PostId = id
			};
			_commentRepository.Create(comment);
			_commentRepository.Save();

			return RedirectToAction("Index", new { id = id });
		}
	}
}

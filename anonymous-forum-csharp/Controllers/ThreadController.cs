using anonymous_forum_csharp.Data.Repository.IRepository;
using anonymous_forum_csharp.Helpers;
using anonymous_forum_csharp.Models;
using anonymous_forum_csharp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace anonymous_forum_csharp.Controllers
{
	public class ThreadController : Controller
	{
		private readonly IPostRepository _postRepository;
		private readonly ITopicRepository _topicRepository;

		public ThreadController(IPostRepository postRepository, ITopicRepository topicRepository)
		{
			_postRepository = postRepository;
			_topicRepository = topicRepository;
		}

		[HttpGet]
		public IActionResult Index(int id)
		{
			var posts = _postRepository.GetByCondition(x => x.TopicId == id);
			var thread = _topicRepository.GetByCondition(x => x.Id == id);
			if (!posts.Any())
			{
				// Handle error
			}

			var viewModel = CreateViewModel(posts, thread);


			string? ip = Helper.GetIp(HttpContext);
			Console.WriteLine(ip);
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
			string? ip = Helper.GetIp(HttpContext);
			var post = new PostModel
			{
				Title = viewModel.Title,
				Text = viewModel.Text,
				IpAdress = ip,
				TopicId = id
			};
			_postRepository.Create(post);
			_postRepository.Save();



			return RedirectToAction("Index", new { id = id });
		}

		private static ThreadIndexViewModel CreateViewModel(IQueryable<PostModel> posts, IQueryable<TopicModel> topic)
		{
			var viewModel = new ThreadIndexViewModel
			{
				PostList = posts.Select(u => new PostModel { Id = u.Id, Title = u.Title, Text = u.Text, TopicId = u.TopicId }).ToList(),
                Topic = topic.Select(u => new TopicModel { Id = u.Id, Name = u.Name }).FirstOrDefault()
            };
			return viewModel;
		}
	}
}

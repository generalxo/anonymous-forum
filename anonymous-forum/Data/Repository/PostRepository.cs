﻿using anonymous_forum.Data.Repository.IRepository;
using anonymous_forum.Models;

namespace anonymous_forum.Data.Repository
{
	public class PostRepository : RepositoryBase<PostModel>, IPostRepository
	{
		public PostRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.Domain.Entities;

namespace Blog.Core.Models.Interfaces
{
    public interface IBlog
    {
        Task<IPageContext> GetPostFeed(int page);
        IPageContext GetBlogContent();
        Task<IPageContext> GetFilteredPostPage(Func<IEnumerable<Post>, IEnumerable<Post>> filter);
    }
}
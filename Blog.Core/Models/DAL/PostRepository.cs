﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;

namespace Blog.Core.Models.DAL
{
    public class PostRepository: IPostRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public IQueryable<string> Posts => GetPostsFromDefaultDirectory();

        public string Path => _hostingEnvironment.ContentRootPath;
        
        public PostRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        /// <summary>Returns posts from default directory</summary>
        private IQueryable<string> GetPostsFromDefaultDirectory()
        {
            //TODO There will be extraction of post metadata and mapping it to Post
            return Directory.GetFiles($"{_hostingEnvironment.ContentRootPath}/Views/_posts", "*.cshtml", SearchOption.AllDirectories)
                            .Select(p => p.Replace(_hostingEnvironment.ContentRootPath, "~"))
                            .AsQueryable();
        }
    }
}
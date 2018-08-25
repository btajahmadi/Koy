using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koy.Blog.Core.Interfaces;
using Koy.Blog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Koy.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostRepository _BlogPostRepository;

        public BlogController(IBlogPostRepository BlogPostRepository)
        {
            _BlogPostRepository = BlogPostRepository;
        }
        public async Task<IActionResult> ReadRandomPost()
        {
            return View(nameof(ReadPost), await _BlogPostRepository.RandomBlogPost());
        }
        public async Task<IActionResult> ReadPost()
        {
            var BlogPostTitle = RouteData.Values["BlogPost"]?.ToString() ?? "";
            return View(await _BlogPostRepository.FindBlogPostByTitle("How to fuck your ass"));
        }
    }
}
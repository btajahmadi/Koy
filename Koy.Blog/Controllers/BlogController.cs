using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koy.Blog.Core.Interfaces;
using Koy.Blog.Core.Models.BlogPostAggregate;
using Koy.Blog.Data.Repositories;
using Koy.Blog.Models;
using Koy.SharedKernel.Common;
using Microsoft.AspNetCore.Mvc;

namespace Koy.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ReadRandomPost()
        {
            return View(nameof(ReadPost), await _blogPostRepository.RandomBlogPost());
        }
        public async Task<IActionResult> ReadPost()
        {
            var BlogPostTitle = RouteData.Values["BlogPost"]?.ToString() ?? "";
            return View(await _blogPostRepository.BlogPostWithTitle("How to fuck your ass"));
        }
        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(BlogPostViewModel model)
        {
            var createNewPostResult = BlogPost.CreateNewPost(model.Title, model.Content);
            if (createNewPostResult.Success)
            {
                await _blogPostRepository.AddBlogPost(createNewPostResult.CreatedEntity);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in createNewPostResult.Notes)
                {
                    ModelState.AddModelError(item.Property, item.Message);
                }
                return View();
            }
        }
    }
}
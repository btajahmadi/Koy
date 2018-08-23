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
        private readonly IArticleRepository _articleRepository;

        public BlogController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<IActionResult> ReadRandomArticle()
        {
            return View(nameof(ReadArticle), await _articleRepository.RandomArticle());
        }
        public async Task<IActionResult> ReadArticle()
        {
            var articleTitle = RouteData.Values["article"]?.ToString() ?? "";
            return View(await _articleRepository.FindArticleByTitle("How to fuck your ass suddenly!"));
        }
    }
}
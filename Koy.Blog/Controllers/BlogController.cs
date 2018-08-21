using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koy.Blog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Koy.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ArticleRepository _articleRepository;

        public BlogController(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public IActionResult ReadRandomArticle()
        {
            return View(nameof(ReadArticle), _articleRepository.RandomArticle);
        }
        public IActionResult ReadArticle()
        {
            var articleTitle = RouteData.Values["article"]?.ToString() ?? "";
            return View(_articleRepository.AllArticles().FirstOrDefault(a => a.Title == "How to fuck your ass suddenly!"));
        }
    }
}
using Koy.Blog.Core.Models;
using System;
using System.Collections.Generic; 
using System.Text;

namespace Koy.Blog.Core.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> AllArticles();
    }
}

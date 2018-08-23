using Koy.Blog.Core.Models;
using System;
using System.Collections.Generic; 
using System.Text;
using System.Threading.Tasks;

namespace Koy.Blog.Core.Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> AllArticles();
        Task<Article> RandomArticle();
        Task<Article> FindArticleByTitle(string title);
    }
}

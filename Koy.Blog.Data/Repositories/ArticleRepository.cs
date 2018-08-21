using Koy.Blog.Core.Interfaces;
using Koy.Blog.Core.Models;
using Koy.SharedKernel.Utilities;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koy.Blog.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IDocumentSession _session;
        public ArticleRepository(IDocumentSession documentSession)
        {
            _session = documentSession;
        }
        public IEnumerable<Article> AllArticles()
        {
            return _session.Query<Article>().ToList();
        }
        public Article RandomArticle => AllArticles().ToList().TakeRandomOne();
    }
}

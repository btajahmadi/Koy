using Koy.Blog.Core.Interfaces;
using Koy.Blog.Core.Models;
using Koy.SharedKernel.Utilities;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koy.Blog.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IAsyncDocumentSession _session;
        public ArticleRepository(IAsyncDocumentSession documentSession)
        {
            _session = documentSession;
        }
        public async Task<IEnumerable<Article>> AllArticles()
        {
            return await _session.Query<Article>().ToListAsync();
        }
        public async Task<Article> FindArticleByTitle(string title)
        {
            var result = await _session.Query<Article>()
                .Search(a => a.Title, title).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Article> RandomArticle()
        {
             QueryStatistics stats;
            _session.Query<Article>().Statistics(out stats);
            var randomNumber = new Random().Next(stats.TotalResults);
            return await _session.LoadAsync<Article>("Articles/" + randomNumber.ToString());
        }
    }
}

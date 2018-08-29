using Koy.Blog.Core.Interfaces;
using Koy.Blog.Core.Models.BlogPostAggregate;
using Koy.SharedKernel.Utilities;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koy.Blog.Data.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly IAsyncDocumentSession _session;

        public BlogPostRepository(IAsyncDocumentSession documentSession)
        {
            _session = documentSession ?? throw new ArgumentNullException();
        }

        public async Task AddBlogPost(BlogPost newPost)
        {
            await _session.StoreAsync(newPost);
        }

        public async Task<IEnumerable<BlogPost>> AllBlogPosts()
        {
            return await _session.Query<BlogPost>().ToListAsync();
        }
        public async Task<BlogPost> BlogPostWithTitle(string title)
        {
            var result = await _session.Query<BlogPost>()
                .Search(a => a.Title, title).FirstOrDefaultAsync();
            return result;
        }

        public async Task<BlogPost> RandomBlogPost()
        {
             QueryStatistics stats;
            _session.Query<BlogPost>().Statistics(out stats);
            var randomNumber = new Random().Next(stats.TotalResults);
            return await _session.LoadAsync<BlogPost>("BlogPosts/" + randomNumber.ToString());
        }
    }
}

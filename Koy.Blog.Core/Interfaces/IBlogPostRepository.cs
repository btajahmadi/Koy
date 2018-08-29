using Koy.Blog.Core.Models;
using Koy.Blog.Core.Models.BlogPostAggregate;
using System;
using System.Collections.Generic; 
using System.Text;
using System.Threading.Tasks;

namespace Koy.Blog.Core.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> AllBlogPosts();
        Task<BlogPost> RandomBlogPost();
        Task<BlogPost> BlogPostWithTitle(string title);
        Task AddBlogPost(BlogPost blogPost);
    }
}

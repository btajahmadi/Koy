using Koy.Blog.Core.Models;
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
        Task<BlogPost> FindBlogPostByTitle(string title);
    }
}

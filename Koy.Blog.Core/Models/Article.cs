using System;

namespace Koy.Blog.Core.Models
{
    public class Article
    {
        public string Title { get; internal set; }
        public DateTime DatePublished { get; internal set; }
    }
}
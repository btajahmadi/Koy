using System;

namespace Koy.Blog.Core.Models.BlogPostAggregate
{
    public class Comment
    {
        public Guid Id { get; private set; }
        public string Commenter { get; private set; }
        public string Text { get; private set; }

    }
}
using Koy.Blog.Core.Models.Validators;
using Koy.SharedKernel.Common;
using Koy.SharedKernel.Utilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Koy.Blog.Core.Models.BlogPostAggregate
{
    public class BlogPost
    {
        private readonly List<Comment> _comments = new List<Comment>();

        private BlogPost() 
        {
            BlogPostId = Guid.NewGuid();
        }
        public Guid BlogPostId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DatePublished { get; private set; }
        public IEnumerable<Comment> Comments => _comments;

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
        public static OperationResult<BlogPost> CreateNewPost(string title, string content)
        {
            var newPost = new BlogPost();
            var validationResult = newPost.SetTitle(title).Merge(newPost.SetContent(content));
            var opResult = new OperationResult<BlogPost>();
            if (!validationResult.Success)
            {
                opResult.CreatedEntity = newPost;
            }
            return opResult;
        }
        public OperationResult SetContent(string content)
        {
            var operationResult = new ContentValidator().Validate(content);
            if (operationResult.Success)
                Content = content;
            return operationResult;
        }
        public OperationResult SetTitle(string title)
        {
            var operationResult = new TitleValidator().Validate(title);
            if (operationResult.Success)
                Title = title;
            return operationResult;
        }
    }
}
using Koy.Blog.Core.Interfaces;
using Koy.SharedKernel.Common;
using Koy.SharedKernel.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koy.Blog.Core.Models.Validators
{
    public class ContentValidator : IValidator
    {
        private readonly int _contentMinimumLength = 75;
        public OperationResult Validate(object obj)
        {
            var content = (string)obj ?? throw new ArgumentException("Content should be a string.");
            var result = new OperationResult();
            if (content.IsBlank())
                result.AddNote(new Notification("Content", "A null or empty content passed to Validate() method of ContentValidator class. Content could not be empty or null."));
            if (content.LengthIsLessThan(75))
                result.AddNote(new Notification("Content", $"A short content passed to Validate() method of ContentValidator class. Content could not be shorter than { _contentMinimumLength }."));
            return result;
        }
    }
}

using Koy.SharedKernel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koy.Blog.Core.Interfaces
{
    public interface IValidator
    {
        OperationResult Validate(object obj);
    }
}

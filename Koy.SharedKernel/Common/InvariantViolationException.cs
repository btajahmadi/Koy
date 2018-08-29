using System;
using System.Collections.Generic;
using System.Text;

namespace Koy.SharedKernel.Common
{
    public class InvariantViolationException : Exception
    {
        public InvariantViolationException(OperationResult operationResult)
        {
            OperationResult = operationResult;
        }
        public OperationResult OperationResult { get; private set; }
    }
}

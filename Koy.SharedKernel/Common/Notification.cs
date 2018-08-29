using System;
using System.Collections.Generic;
using System.Text;

namespace Koy.SharedKernel.Common
{
    public class Notification
    {
        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }
        public string Property { get; private set; }
        public string Message { get; private set; }
    }
}

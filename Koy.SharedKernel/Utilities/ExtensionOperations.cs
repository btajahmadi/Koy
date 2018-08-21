using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koy.SharedKernel.Utilities
{
    public static class ExtensionOperations
    {
        public static T TakeRandomOne<T> (this IList<T> list)
        {
            list = list ?? throw new ArgumentNullException();
            var randomizer = new Random();
            var randomNumber = randomizer.Next(list.Count);
            return list[randomNumber];
        }
    }
}

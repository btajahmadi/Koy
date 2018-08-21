using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koy.Blog.Data
{
    public class DocumentStoreHolder
    {
        public static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);
        public static IDocumentStore Store => store.Value;
        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://127.0.0.1:8081" },
                Database = "Koy"
            }.Initialize();
            return store;
        }
    }
}

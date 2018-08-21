using Koy.Blog.Data.Seeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Koy.Blog.Data.Seeding
{
    public class DataSeeder
    {
        internal IEnumerable<Article> Articles()
        { 
            var reader = XmlReader.Create("article.xml");
            foreach (var item in reader.Dispose)
            {

            }
             
        }

    }
}

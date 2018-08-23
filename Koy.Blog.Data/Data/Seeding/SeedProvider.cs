using Koy.Blog.Data.Seeding.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Koy.Blog.Data.Seeding
{
    public class SeedProvider
    {
        public void Articles()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Article>));
            var reader = new StreamReader("Articles.xml");

            var articles = new List<Article>();
            articles = (List<Article>)xmlSerializer.Deserialize(reader);
            reader.Close();
        }
    }
}

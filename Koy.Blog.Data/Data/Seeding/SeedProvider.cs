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
        public void BlogPosts()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<BlogPost>));
            var reader = new StreamReader("BlogPosts.xml");

            var BlogPosts = new List<BlogPost>();
            BlogPosts = (List<BlogPost>)xmlSerializer.Deserialize(reader);
            reader.Close();
        }
    }
}

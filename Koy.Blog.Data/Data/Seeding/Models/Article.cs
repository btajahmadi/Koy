using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Koy.Blog.Data.Seeding.Models
{
    [XmlRoot]
    internal class Article
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlElement]
        public string Title { get; set; }
        [XmlElement]
        public DateTime DatePublished { get; set; }
        [XmlElement]
        public IEnumerable<Writer> Writers { get; set; }
        [XmlElement]
        public string Content { get; set; }
    }
}

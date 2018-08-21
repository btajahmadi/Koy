using System.Xml.Serialization;

namespace Koy.Blog.Data.Seeding.Models
{
    [XmlRoot]
    internal class Writer
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlElement]
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Koy.Blog.Models
{
    public class BlogPostViewModel
    {
        [Required]
        [StringLength(maximumLength: 35)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Content { get; set; }
    }
}

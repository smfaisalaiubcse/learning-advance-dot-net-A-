using Simple_Blog_Site.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple_Blog_Site.Models
{
    public class BlogViewModel
    {
        public BlogDTO NewBlog { get; set; }
        public List<BlogDTO> AllBlogs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Simple_Blog_Site.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UName { get; set; }
        public string Type { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
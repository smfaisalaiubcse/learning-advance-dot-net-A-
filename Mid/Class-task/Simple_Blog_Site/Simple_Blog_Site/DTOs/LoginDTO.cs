﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Simple_Blog_Site.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string UName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
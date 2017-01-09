using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models.UserModels
{
    public class LogInModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
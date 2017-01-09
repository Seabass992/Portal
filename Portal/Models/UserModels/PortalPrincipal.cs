using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Portal.Helpers.DB;

namespace Portal.Models.UserModels
{
    public class PortalPrincipal : IPrincipal
    {
        public User User { get; set; }

        public bool IsInRole(string roles)
        {
            return User.Roles.Any(r => roles.Contains(r));
        }

        public PortalPrincipal(User user)
        {
            User = user;
            Identity = new GenericIdentity(User.Email);
        }

        public IIdentity Identity { get; }
    }
}
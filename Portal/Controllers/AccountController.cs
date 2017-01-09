using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Portal.Helpers;
using Portal.Helpers.DB;
using Portal.Models.UserModels;

namespace Portal.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: LogIn
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = PortalDbContext.Get())
                {
                    var user =
                        db.Users.FirstOrDefault(
                            u => u.Email.Equals(model.Email, StringComparison.InvariantCultureIgnoreCase));
                    if (user != null)
                    {
                        if (Hashing.CheckPassword(model.Password, user.PasswordHash))
                        {
                            FormsAuthentication.SetAuthCookie(user.Id.ToString(), model.RememberMe);
                            return RedirectToAction("Edit");
                        }
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = PortalDbContext.Get())
                {
                    if (!db.Users.Any(u => u.Email == model.Email))
                    {
                        db.Users.Add(new User()
                        {
                            Email = model.Email,
                            PasswordHash = Hashing.GenerateHash(model.Password)
                        });
                        try
                        {
                            await db.SaveChangesAsync();
                            return RedirectToAction("LogIn");
                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError("", "User Creation Unsuccessful");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Email","An account for that email already exists");
                    }
                }
            }
            return View(model);
        }
    }
}
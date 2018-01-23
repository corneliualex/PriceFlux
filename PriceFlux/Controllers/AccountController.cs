using PriceFlux.Helpers;
using PriceFlux.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PriceFlux.Controllers
{
    public sealed class AuthenticationErrors
    {
        private readonly string name;
        private readonly int value;

        public static readonly AuthenticationErrors UserAlreadyExists = new AuthenticationErrors(1, "User name is already used");
        public static readonly AuthenticationErrors EmailAlreadyExists = new AuthenticationErrors(2, "Email is already used");

        public AuthenticationErrors(int value, string name)
        {
            this.value = value;
            this.name = name;

        }
    }

    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View("UserForm", new User());
        }

        [HttpPost]
        public ActionResult UserForm(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("UserForm", user);
            }

            if (user.Id == 0)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    string hashedPassword = null;
                    using (MD5 md5Hash = MD5.Create())
                    {
                        hashedPassword = MD5Hash.GetMd5Hash(md5Hash, user.Password);
                    }
                    user.Password = hashedPassword;
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Account");
        }
    }
}
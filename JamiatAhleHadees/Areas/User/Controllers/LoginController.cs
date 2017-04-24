using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JamiatAhleHadees.Areas.User.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: User/Login


        public ActionResult Index()
        {
            TempData["message"] = TempData["msg"];
            return View();
        }
   

        public ActionResult SignIn(UserModel model)
        {
            try
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed  ";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception E1)
            {
                TempData["Msg"] = "Login Failed  " + E1.Message;
                return RedirectToAction("Index");
            }


        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login", new { area = "User" });
        }
    }
}
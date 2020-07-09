using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using s1061461999Travel.Models;
using PagedList;

namespace s1061461999Travel.Controllers
{
    public class UserController : Controller
    {
        private MemberEntities db = new MemberEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList(int page=1)
        {
            int pagesize = 3;
            int currentpage = page < 1 ? 1 : page;
            var users = db.Users.OrderBy(o => o.Account);
            var pagedlist = users.ToPagedList(currentpage, pagesize);
            return View(pagedlist);
        }

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserList", "User");
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(User user)
        {
            user.RoleId = 1;
            user.Enabled = false;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("UserList", "User");
            //return View(user);
        }

        public ActionResult IsUserExists(string Account)
        {
            bool check = false;
            User user = db.Users.Find(Account);
            if (user == null)
                check = true;
            return Json(check,JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
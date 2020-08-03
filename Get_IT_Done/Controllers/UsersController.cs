using Get_IT_Done.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Get_IT_Done.ViewModels;

namespace Get_IT_Done.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Users
        public ActionResult Index()
        {
            var usersList = new UsersList
            {
                usersList = _context.Users.Include(m => m.MembershipType).ToList()
            };
            return View(usersList);
        }

        // GET:Users/Detail/{UserID}
        public ActionResult Details(Guid UserID)
        {
            var User = _context.Users.Where(m => m.UserID == UserID).FirstOrDefault();
            return View(User);
        }
    }
}
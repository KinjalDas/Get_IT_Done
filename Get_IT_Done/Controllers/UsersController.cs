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
            var user = _context.Users.Where(m => m.Id == UserID).FirstOrDefault();
            var membershipType = _context.MembershipTypes.Single(m => m.Id == user.MembershipTypeId);
            var userDetails = new UserDetails
            {
                User = user,
                MembershipType = membershipType
            };
            return View(userDetails);
        }

        // GET:Users/AddUser
        public ActionResult AddUser()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            UserForm form = new UserForm
            {
                MembershipTypes = membershipTypes
            };
            return View("UserForm",form);
        }

        // GET:Users/EditUser/{UserID}
        public ActionResult EditUser(Guid UserID)
        {
            var User = _context.Users.Single(m => m.Id == UserID);
            var membershipTypes = _context.MembershipTypes.ToList();
            UserForm form = new UserForm(User)
            {
                MembershipTypes = membershipTypes
            };
            return View("UserForm",form);
        }

        // POST:Users/DeleteUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(Users Users)
        {
            var User = _context.Users.Single(m => m.Id == Users.Id);
            _context.Users.Remove(User);
            _context.SaveChanges();
            return RedirectToAction("Index", "Users");
        }

        // POST:Users/UserFormSubmit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserFormSubmit(Users Users)
        {
            //Users.MembershipType = _context.MembershipTypes.Single(m => m.Id == Users.MembershipTypeId);
            if (!ModelState.IsValid)
            {
                var userForm = new UserForm(Users)
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("UserForm", userForm);
            }

            if(Users.Id == Guid.Empty)
            {
                _context.Users.Add(Users);
            } else
            {
                var User = _context.Users.Single(m => m.Id == Users.Id);
                User.DateOfBirth = Users.DateOfBirth;
                User.MembershipType = Users.MembershipType;
                User.MembershipTypeId = Users.MembershipTypeId;
                User.UserName = Users.UserName;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
    }
}
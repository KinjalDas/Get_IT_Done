using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Get_IT_Done.DTOs;
using Get_IT_Done.Models;

namespace Get_IT_Done.Controllers.Api
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            List<UsersDTO> UserDTOs = new List<UsersDTO>();
            foreach (var User in db.Users.Include(m => m.MembershipType).ToList())
            {
                UserDTOs.Add(DTOMapper.mapper.Map<UsersDTO>(User));
            }
            return Ok(UserDTOs);
        }

        // GET: api/Users/5
        public IHttpActionResult GetUsers(Guid id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        public IHttpActionResult PutUsers(Guid id, UsersDTO usersDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usersDTO.Id)
            {
                return BadRequest();
            }

            var users = DTOMapper.mapper.Map<UsersDTO, Users>(usersDTO);
            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(usersDTO);
        }

        // POST: api/Users
        public IHttpActionResult PostUsers(UsersDTO usersDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          var users = DTOMapper.mapper.Map<UsersDTO, Users>(usersDTO);
            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.Id }, users);
        }

        // DELETE: api/Users/5
        public IHttpActionResult DeleteUsers(Guid id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(Guid id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}
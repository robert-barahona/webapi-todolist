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
using BEU;
using BEU.Transactions;

namespace API.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IQueryable<Users> GetUsers()
        {
            return UsersBLL.Get();
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users user = UsersBLL.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.id_user)
            {
                return BadRequest();
            }

            UsersBLL.Update(user);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsersBLL.Create(user);

            return CreatedAtRoute("DefaultApi", new { id = user.id_user }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users user = UsersBLL.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            UsersBLL.Delete(id);

            return Ok(user);
        }

        //private bool UsersExists(int id)
        //{
        //    return db.Users.Count(e => e.id_user == id) > 0;
        //}
    }
}
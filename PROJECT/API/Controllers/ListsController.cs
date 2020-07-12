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

namespace API.Controllers
{
    public class ListsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Lists
        public IQueryable<List> GetList()
        {
            return db.List;
        }

        // GET: api/Lists/5
        [ResponseType(typeof(List))]
        public IHttpActionResult GetList(int id)
        {
            List list = db.List.Find(id);
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // PUT: api/Lists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutList(int id, List list)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != list.id_list)
            {
                return BadRequest();
            }

            db.Entry(list).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Lists
        [ResponseType(typeof(List))]
        public IHttpActionResult PostList(List list)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.List.Add(list);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = list.id_list }, list);
        }

        // DELETE: api/Lists/5
        [ResponseType(typeof(List))]
        public IHttpActionResult DeleteList(int id)
        {
            List list = db.List.Find(id);
            if (list == null)
            {
                return NotFound();
            }

            db.List.Remove(list);
            db.SaveChanges();

            return Ok(list);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListExists(int id)
        {
            return db.List.Count(e => e.id_list == id) > 0;
        }
    }
}
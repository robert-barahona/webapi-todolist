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
    public class ListsController : ApiController
    {
        // GET: api/Lists
        public IQueryable<List> GetList()
        {
            return ListsBLL.Get();
        }

        // GET: api/Lists/5
        [ResponseType(typeof(List))]
        public IHttpActionResult GetList(int id)
        {
            List list = ListsBLL.Get(id);
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

            ListsBLL.Update(list);

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

            ListsBLL.Create(list);

            return CreatedAtRoute("DefaultApi", new { id = list.id_list }, list);
        }

        // DELETE: api/Lists/5
        [ResponseType(typeof(List))]
        public IHttpActionResult DeleteList(int id)
        {
            List list = ListsBLL.Get(id);
            if (list == null)
            {
                return NotFound();
            }

            ListsBLL.Delete(id);

            return Ok(list);
        }

        //private bool ListExists(int id)
        //{
        //    return db.List.Count(e => e.id_list == id) > 0;
        //}
    }
}
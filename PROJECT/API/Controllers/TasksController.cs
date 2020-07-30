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
    public class TasksController : ApiController
    {
        // GET: api/Tasks
        public IQueryable<Task> GetTask()
        {
            return TasksBLL.Get();
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(int id)
        {
            Task task = TasksBLL.Get(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.id_task)
            {
                return BadRequest();
            }

            TasksBLL.Update(task);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TasksBLL.Create(task);

            return CreatedAtRoute("DefaultApi", new { id = task.id_task }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(int id)
        {
            Task task = TasksBLL.Get(id);
            if (task == null)
            {
                return NotFound();
            }

            TasksBLL.Delete(id);

            return Ok(task);
        }

        //private bool TaskExists(int id)
        //{
        //    return db.Task.Count(e => e.id_task == id) > 0;
        //}
    }
}
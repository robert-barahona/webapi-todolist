using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEU;
using BEU.Transactions;

namespace MVC.Controllers
{
    public class TasksController : Controller
    {
        private Entities db = new Entities();

        // GET: Tasks
        public ActionResult Index()
        {
            return View(TasksBLL.List());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = TasksBLL.Get(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.id_list = new SelectList(db.List, "id_list", "name_list");
            return View();
        }

        // POST: Tasks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_task,title,descr,asigned_to,id_list")] Task task)
        {
            if (ModelState.IsValid)
            {
                TasksBLL.Create(task);
                return RedirectToAction("Index");
            }

            ViewBag.id_list = new SelectList(db.List, "id_list", "name_list", task.id_list);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = TasksBLL.Get(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_list = new SelectList(db.List, "id_list", "name_list", task.id_list);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_task,title,descr,asigned_to,id_list")] Task task)
        {
            if (ModelState.IsValid)
            {
                TasksBLL.Update(task);
                return RedirectToAction("Index");
            }
            ViewBag.id_list = new SelectList(db.List, "id_list", "name_list", task.id_list);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = TasksBLL.Get(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TasksBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

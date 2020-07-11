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
    public class ListsController : Controller
    {
        private Entities db = new Entities();

        // GET: Lists
        public ActionResult Index()
        {
            return View(ListsBLL.List());
        }

        // GET: Lists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = ListsBLL.Get(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // GET: Lists/Create
        public ActionResult Create()
        {
            ViewBag.id_board = new SelectList(db.Board, "id_board", "name_board");
            return View();
        }

        // POST: Lists/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_list,name_list,id_board")] List list)
        {
            if (ModelState.IsValid)
            {
                ListsBLL.Create(list);
                return RedirectToAction("Index");
            }

            ViewBag.id_board = new SelectList(db.Board, "id_board", "name_board", list.id_board);
            return View(list);
        }

        // GET: Lists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = ListsBLL.Get(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_board = new SelectList(db.Board, "id_board", "name_board", list.id_board);
            return View(list);
        }

        // POST: Lists/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_list,name_list,id_board")] List list)
        {
            if (ModelState.IsValid)
            {
                ListsBLL.Update(list);
                return RedirectToAction("Index");
            }
            ViewBag.id_board = new SelectList(db.Board, "id_board", "name_board", list.id_board);
            return View(list);
        }

        // GET: Lists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = ListsBLL.Get(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Lists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListsBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

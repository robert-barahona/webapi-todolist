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
    public class BoardsController : Controller
    {
        private Entities db = new Entities();

        // GET: Boards
        public ActionResult Index()
        {
            return View(BoardsBLL.List());
        }

        // GET: Boards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = BoardsBLL.Get(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // GET: Boards/Create
        public ActionResult Create()
        {
            ViewBag.id_owner = new SelectList(db.Users, "id_user", "first_name");
            return View();
        }

        // POST: Boards/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_board,name_board,id_owner,id_participants")] Board board)
        {
            if (ModelState.IsValid)
            {
                BoardsBLL.Create(board);
                return RedirectToAction("Index");
            }

            ViewBag.id_owner = new SelectList(db.Users, "id_user", "first_name", board.id_owner);
            return View(board);
        }

        // GET: Boards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = BoardsBLL.Get(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_owner = new SelectList(db.Users, "id_user", "first_name", board.id_owner);
            return View(board);
        }

        // POST: Boards/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_board,name_board,id_owner,id_participants")] Board board)
        {
            if (ModelState.IsValid)
            {
                BoardsBLL.Update(board);
                return RedirectToAction("Index");
            }
            ViewBag.id_owner = new SelectList(db.Users, "id_user", "first_name", board.id_owner);
            return View(board);
        }

        // GET: Boards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = BoardsBLL.Get(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardsBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

﻿using System;
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
    public class BoardsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Boards
        public IQueryable<Board> GetBoard()
        {
            return db.Board;
        }

        // GET: api/Boards/5
        [ResponseType(typeof(Board))]
        public IHttpActionResult GetBoard(int id)
        {
            Board board = db.Board.Find(id);
            if (board == null)
            {
                return NotFound();
            }

            return Ok(board);
        }

        // PUT: api/Boards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoard(int id, Board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != board.id_board)
            {
                return BadRequest();
            }

            db.Entry(board).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(id))
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

        // POST: api/Boards
        [ResponseType(typeof(Board))]
        public IHttpActionResult PostBoard(Board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Board.Add(board);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = board.id_board }, board);
        }

        // DELETE: api/Boards/5
        [ResponseType(typeof(Board))]
        public IHttpActionResult DeleteBoard(int id)
        {
            Board board = db.Board.Find(id);
            if (board == null)
            {
                return NotFound();
            }

            db.Board.Remove(board);
            db.SaveChanges();

            return Ok(board);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardExists(int id)
        {
            return db.Board.Count(e => e.id_board == id) > 0;
        }
    }
}
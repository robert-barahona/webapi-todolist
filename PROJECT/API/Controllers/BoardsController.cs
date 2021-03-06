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
using BEU.Transactions;

namespace API.Controllers
{
    public class BoardsController : ApiController
    {
        // GET: api/Boards
        public IQueryable<Board> GetBoard()
        {
            return BoardsBLL.Get();
        }

        // GET: api/Boards/5
        [ResponseType(typeof(Board))]
        public IHttpActionResult GetBoard(int id)
        {
            Board board = BoardsBLL.Get(id);
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

            BoardsBLL.Update(board);

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

            BoardsBLL.Create(board);

            return CreatedAtRoute("DefaultApi", new { id = board.id_board }, board);
        }

        // DELETE: api/Boards/5
        [ResponseType(typeof(Board))]
        public IHttpActionResult DeleteBoard(int id)
        {
            Board board = BoardsBLL.Get(id);
            if (board == null)
            {
                return NotFound();
            }

            BoardsBLL.Delete(id);

            return Ok(board);
        }

        //private bool BoardExists(int id)
        //{
        //    return db.Board.Count(e => e.id_board == id) > 0;
        //}
    }
}
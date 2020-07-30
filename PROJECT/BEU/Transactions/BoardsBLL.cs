using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEU.Transactions
{
    public class BoardsBLL
    {
        public static void Create(Board b)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Board.Add(b);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static IQueryable<Board> Get()
        {
            Entities db = new Entities();
            return db.Board;
        }

        public static Board Get(int? id)
        {
            Entities db = new Entities();
            return db.Board.Find(id);
        }

        public static void Update(Board Board)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Board.Attach(Board);
                        db.Entry(Board).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        
                        Board Board = db.Board.Find(id);
                        List<List> lists = ListsBLL.List();
                        foreach (var item in lists)
                        {
                            if (item.id_board == Board.id_board)
                            {
                                ListsBLL.Delete(item.id_list);
                            }
                        }
                        db.Entry(Board).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Board> List()
        {
            Entities db = new Entities();

            return db.Board.ToList();
        }
    }
}

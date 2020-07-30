using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEU.Transactions
{
    public class ListsBLL
    {
        public static void Create(List l)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.List.Add(l);
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

        public static IQueryable<List> Get()
        {
            Entities db = new Entities();
            return db.List;
        }

        public static List Get(int? id)
        {
            Entities db = new Entities();
            return db.List.Find(id);
        }

        public static void Update(List List)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.List.Attach(List);
                        db.Entry(List).State = System.Data.Entity.EntityState.Modified;
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
                        List List = db.List.Find(id);
                        List<Task> tasks = TasksBLL.List();
                        foreach (var item in tasks)
                        {
                            if (item.id_list == List.id_list)
                            {
                                TasksBLL.Delete(item.id_task);
                            }
                        }
                        db.Entry(List).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<List> List()
        {
            Entities db = new Entities();

            return db.List.ToList();
        }
    }
}

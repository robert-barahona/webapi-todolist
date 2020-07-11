using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEU.Transactions
{
    public class UsersBLL
    {
        public static void Create(Users u)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Users.Add(u);
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

        public static Users Get(int? id)
        {
            Entities db = new Entities();
            return db.Users.Find(id);
        }

        public static void Update(Users User)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Users.Attach(User);
                        db.Entry(User).State = System.Data.Entity.EntityState.Modified;
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

        public static Users GetUser(string email, string password)
        {
            Entities db = new Entities();
            return db.Users.FirstOrDefault(e => e.email == email && e.pass == password);
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Users User = db.Users.Find(id);
                        db.Entry(User).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Users> List()
        {
            Entities db = new Entities();
            return db.Users.ToList();
        }
    }
}

using ASX43O_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected RPGDbContext db;

        public Repository(RPGDbContext db) 
        {
            this.db = db;
        }
        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public abstract T GetOne(int id);
        public abstract void Delete(int id);

        public void Update(T entity)
        {
            db.Update(entity);
        }
    }
}

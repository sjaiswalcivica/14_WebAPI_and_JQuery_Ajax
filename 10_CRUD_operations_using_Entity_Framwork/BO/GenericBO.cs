using _10_CRUD_operations_using_Entity_Framwork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_CRUD_operations_using_Entity_Framwork.BO
{
    public class Repository<T> : IDisposable where T : class
    {
        OrganizationContext db;
        DbSet<T> ds;
        IMemoryCache memoryCache;

        public Repository(OrganizationContext db, IMemoryCache memoryCache)
        {
            this.db = db;
            ds = db.Set<T>();
            this.memoryCache = memoryCache;
        }

        public IEnumerable<T> GetAll()
        {
            Type tp = typeof(T);
            string type = tp.ToString();
            if (memoryCache.Get(type) == null)
            {
                memoryCache.Set(type, ds.ToList());
            }
            return (IEnumerable<T>)memoryCache.Get(type);
            //            return ds.ToList();
        }

        public T GetById(int? id)
        {
            return ds.Find(id);
        }

        public T Add(T entity)
        {
            Type tp = typeof(T);
            string type = tp.ToString();
            ds.Add(entity);
            db.SaveChanges();
            memoryCache.Remove(type);
            return entity;
            //ds.Add(entity);
            //db.SaveChanges();
            //return entity;
        }

        public void Update(T entity)
        {
            Type tp = typeof(T);
            string type = tp.ToString();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            memoryCache.Remove(type);
            //db.Entry(entity).State = EntityState.Modified;
            //db.SaveChanges();
        }

        public void Delete(int? id)
        {
            T entity = ds.Find(id);
            Type tp = typeof(T);
            string type = tp.ToString();
            ds.Remove(entity);
            db.SaveChanges();
            memoryCache.Remove(type);

            //T entity = ds.Find(id);
            //ds.Remove(entity);
            //db.SaveChanges();

        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}

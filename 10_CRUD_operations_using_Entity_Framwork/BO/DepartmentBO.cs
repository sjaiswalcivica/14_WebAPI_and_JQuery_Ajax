using _10_CRUD_operations_using_Entity_Framwork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_CRUD_operations_using_Entity_Framwork.BO
{
    public class DepartmentBO
    {
        //OrganizationContext db;
        Repository<Department> rep;
        public DepartmentBO(OrganizationContext db, IMemoryCache memoryCache)
        {
            this.rep = new Repository<Department>(db, memoryCache);
            //this.db = db;
        }
        public IEnumerable<Department> GetAll()
        {
            return rep.GetAll();
            //IEnumerable<Department> qry = db.Departments;
            //return qry.ToList();
        }
        public Department GetById(int? id)
        {
            return rep.GetById(id);
            //return db.Departments.Find(id);
        }
        public Department Add(Department entity)
        {
            return rep.Add(entity);
            //db.Departments.Add(entity);
            //db.SaveChanges();
            //return entity;
        }
        public void Update(Department entity)
        {
            rep.Update(entity);
            //db.Entry(entity).State = EntityState.Modified;
            //db.SaveChanges();
        }
        public void Delete(int? id)
        {
            rep.Delete(id);
            //Department entity = db.Departments.Find(id);
            //db.Remove(entity);
            //db.SaveChanges();
        }

        public void Dispose()
        {
            rep.Dispose();
            //db.Dispose();
        }
    }


}

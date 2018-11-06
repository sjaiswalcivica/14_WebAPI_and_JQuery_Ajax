using _10_CRUD_operations_using_Entity_Framwork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_CRUD_operations_using_Entity_Framwork.BO
{
    public class EmployeeBO
    {
        Repository<Employee> rep;
        public EmployeeBO(OrganizationContext db, IMemoryCache memoryCache) {
            this.rep = new Repository<Employee>(db, memoryCache);
        }
        public IEnumerable<Employee> GetAll(int deptId = 0)
        {
            return rep.GetAll();
            //IEnumerable<Employee> qry = db.Employees.Include(e => e.Department);
            //if(deptId != 0)
            //{
            //    qry = qry.Where(e => e.FKDeptId == deptId);
            //}
            //return qry.ToList();
        }
        public Employee GetById(int? employeeId)
        {
            return rep.GetById(employeeId);

            //IEnumerable<Employee> qry = db.Employees.Include(e => e.Department)
            //    .Where(e => e.PKEmpId == employeeId);
            //return qry.FirstOrDefault();

//            return db.Employees.Find(employeeId);
        }
        public Employee Add(Employee entity)
        {
            return rep.Add(entity);
            //db.Employees.Add(entity);
            //db.SaveChanges();
            //return entity;
        }

        public void Update(Employee entity)
        {
            rep.Update(entity);
            //db.Entry<Employee>(entity).State = EntityState.Modified;
            //db.SaveChanges();
        }
        public void Delete(int? id)
        {
            rep.Delete(id);
            //Employee entity = db.Employees.Find(id);
            //db.Remove(entity);
            //db.SaveChanges();
        }
        public void Dispose()
        {
            rep.Dispose();
        }




    }
}

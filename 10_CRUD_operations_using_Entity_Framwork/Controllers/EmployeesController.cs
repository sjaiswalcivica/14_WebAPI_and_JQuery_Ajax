using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _10_CRUD_operations_using_Entity_Framwork.Models;
using _10_CRUD_operations_using_Entity_Framwork.BO;
using Microsoft.Extensions.Caching.Memory;

namespace _10_CRUD_operations_using_Entity_Framwork.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeBO objEmployeeBO;
        DepartmentBO objDepartmentBO;

        public EmployeesController(OrganizationContext context, IMemoryCache memoryCache)
        {
            objEmployeeBO = new EmployeeBO(context, memoryCache);
            objDepartmentBO = new DepartmentBO(context, memoryCache);
        }

        // GET: Employees
        public IActionResult Index()
        {
            //var organizationContext = _context.Employees.Include(e => e.Department);
            //return View(await organizationContext.ToListAsync());
            var data = objEmployeeBO.GetAll();
            data = from e in data
                   join d in objDepartmentBO.GetAll()
                   on e.FKDeptId equals d.PKDeptId
                   select new Employee()
                   {
                       PKEmpId = e.PKEmpId,
                       EmpName = e.EmpName,
                       Salary = e.Salary,
                       IsActive = e.IsActive,
                       FKDeptId = d.PKDeptId,
                       Department = d
                   };
            return View(data);
        }

        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var employee = objEmployeeBO.GetById(id);
            if (employee == null)
                return NotFound();
            return View(employee);
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employee = await _context.Employees
            //    .Include(e => e.Department)
            //    .FirstOrDefaultAsync(m => m.PKEmpId == id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewBag.Depts = new SelectList(objDepartmentBO.GetAll(), "PKDeptId", "DeptName");
            return View();
            //ViewData["FKDeptId"] = new SelectList(_context.Departments, "PKDeptId", "PKDeptId");
            //return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PKEmpId,EmpName,Salary,IsActive,FKDeptId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                objEmployeeBO.Add(employee);
                return RedirectToAction("Index");
            }
            ViewBag.Depts = new SelectList(objDepartmentBO.GetAll(), "PKDeptId", "DeptName");
            return View();
            //if (ModelState.IsValid)
            //{
            //    _context.Add(employee);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["FKDeptId"] = new SelectList(_context.Departments, "PKDeptId", "PKDeptId", employee.FKDeptId);
            //return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var employee = objEmployeeBO.GetById(id);
            if (employee == null)
                return NotFound();
            ViewBag.Depts = new SelectList(objDepartmentBO.GetAll(), "PKDeptId", "DeptName", employee.FKDeptId);
            return View(employee);
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employee = await _context.Employees.FindAsync(id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}
            //ViewData["FKDeptId"] = new SelectList(_context.Departments, "PKDeptId", "PKDeptId", employee.FKDeptId);
            //return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PKEmpId,EmpName,Salary,IsActive,FKDeptId")] Employee employee)
        {
            if (id != employee.PKEmpId)
            {
                return new BadRequestResult();
            }
            if (ModelState.IsValid)
            {
                objEmployeeBO.Update(employee);
                return RedirectToAction("Index");
            }
            ViewBag.Depts = new SelectList(objDepartmentBO.GetAll(), "PKDeptId", "DeptName", employee.FKDeptId);
            return View(employee);
            //if (id != employee.PKEmpId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(employee);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!EmployeeExists(employee.PKEmpId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["FKDeptId"] = new SelectList(_context.Departments, "PKDeptId", "PKDeptId", employee.FKDeptId);
            //return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var employee = objEmployeeBO.GetById(id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var employee = await _context.Employees
            //    .Include(e => e.Department)
            //    .FirstOrDefaultAsync(m => m.PKEmpId == id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            objEmployeeBO.Delete(id);
            return RedirectToAction("Index");

            //var employee = await _context.Employees.FindAsync(id);
            //_context.Employees.Remove(employee);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return (objEmployeeBO.GetById(id) != null);
            //return _context.Employees.Any(e => e.PKEmpId == id);
        }
    }
}

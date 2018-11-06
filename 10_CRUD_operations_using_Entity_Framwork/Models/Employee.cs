using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _10_CRUD_operations_using_Entity_Framwork.Models
{
    public class Employee
    {
        [Key]
        public int PKEmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Department")]
        public int FKDeptId { get; set; }
        public Department Department { get; set; }
    }
}

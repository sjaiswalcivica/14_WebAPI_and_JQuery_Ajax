using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _10_CRUD_operations_using_Entity_Framwork.Models
{
    public class Department
    {
        [Key]
        public int PKDeptId { get; set; }
        public string DeptName { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}

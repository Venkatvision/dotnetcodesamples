using EMS_DAL;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EMS_UI.Pages
{
    public class EmployeesByDeptModel : PageModel
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Department> Departments { get; set; } = new();
        public int SelectedDeptId { get; set; }

        public void OnGet(int? deptId)
        {
            Departments = DAL.GetDepartmentList();
            
            if (deptId.HasValue && deptId > 0)
            {
                SelectedDeptId = deptId.Value;
                Employees = DAL.GetEmployeesByDept(deptId.Value);
            }
        }
    }
}
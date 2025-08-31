using EMS_DAL;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EMS_UI.Pages
{
    public class EmployeeListModel : PageModel
    {
        public List<Employee> Employees { get; set; } = new();

        public void OnGet()
        {
            Employees = DAL.GetEmployees();
        }

        public IActionResult OnPost(int empId)
        {
            bool result = DAL.DeleteEmployee(empId);
            
            if (result)
            {
                TempData["Message"] = "Employee deleted successfully";
            }
            else
            {
                TempData["Error"] = "Failed to delete employee";
            }

            return RedirectToPage();
        }
    }
}
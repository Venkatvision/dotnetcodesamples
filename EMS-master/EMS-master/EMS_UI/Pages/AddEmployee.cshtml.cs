using EMS_DAL;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EMS_UI.Pages
{
    public class AddEmployeeModel : PageModel
    {
        public List<Department> Departments { get; set; } = new();
        public List<Employee> Managers { get; set; } = new();

        public void OnGet()
        {
            LoadDropdownData();
        }

        public IActionResult OnPost(string name, string email, string gender, int departmentNo, 
            string dateOfBirth, string dateOfJoining, int reportingTo, long phone, 
            int salary, int commission, string jobTitle)
        {
            try
            {
                var employee = new Employee
                {
                    Name = name,
                    Email = email,
                    Gender = gender,
                    DepartmentNo = departmentNo,
                    DateOfBirth = System.DateTime.Parse(dateOfBirth),
                    DateOfJoining = System.DateTime.Parse(dateOfJoining),
                    ReportingTo = reportingTo == 0 ? null : reportingTo,
                    Phone = phone,
                    Salary = salary,
                    Commission = commission,
                    JobTitle = jobTitle
                };

                bool result = DAL.AddEmployee(employee);
                
                if (result)
                {
                    TempData["Message"] = "Employee added successfully";
                }
                else
                {
                    TempData["Error"] = "Failed to add employee";
                }
            }
            catch (System.Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
            }

            return RedirectToPage("/EmployeeList");
        }

        private void LoadDropdownData()
        {
            Departments = DAL.GetDepartmentList();
            Managers = DAL.GetEmployeeNames();
        }
    }
}
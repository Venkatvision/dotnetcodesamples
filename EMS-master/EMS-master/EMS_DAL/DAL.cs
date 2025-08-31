using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMS_DAL
{
    public static class DAL
    {
        // In-memory data storage
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Number = 1, Name = "John Doe", Email = "john@test.com", Gender = "Male", 
                          DepartmentNo = 1, DateOfBirth = DateTime.Parse("1990-01-01"), 
                          DateOfJoining = DateTime.Parse("2020-01-01"), ReportingTo = null, 
                          Phone = 1234567890, Salary = 50000, Commission = 5000, JobTitle = "Developer" },
            new Employee { Number = 2, Name = "Jane Smith", Email = "jane@test.com", Gender = "Female", 
                          DepartmentNo = 2, DateOfBirth = DateTime.Parse("1985-05-15"), 
                          DateOfJoining = DateTime.Parse("2018-03-01"), ReportingTo = null, 
                          Phone = 9876543210, Salary = 60000, Commission = 0, JobTitle = "Manager" }
        };

        private static List<Department> _departments = new List<Department>
        {
            new Department { DepartmentId = 1, Name = "IT" },
            new Department { DepartmentId = 2, Name = "HR" },
            new Department { DepartmentId = 3, Name = "Finance" },
            new Department { DepartmentId = 4, Name = "Sales" },
            new Department { DepartmentId = 5, Name = "Marketing" }
        };

        private static List<User> _users = new List<User>
        {
            new User { Username = "admin", Password = "admin" },
            new User { Username = "test", Password = "test" }
        };

        private static int _nextEmployeeId = 3;

        public static bool AddEmployee(Employee employee)
        {
            try
            {
                employee.Number = _nextEmployeeId++;
                _employees.Add(employee);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Login(string username, string password)
        {
            return _users.Any(u => u.Username == username && u.Password == password);
        }

        public static bool RegisterUser(string username, string password)
        {
            try
            {
                if (_users.Any(u => u.Username == username)) return false;
                _users.Add(new User { Username = username, Password = password });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteEmployee(int empId)
        {
            try
            {
                var emp = _employees.FirstOrDefault(e => e.Number == empId);
                if (emp != null)
                {
                    _employees.Remove(emp);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateEmployee(Employee employee)
        {
            try
            {
                var existing = _employees.FirstOrDefault(e => e.Number == employee.Number);
                if (existing != null)
                {
                    existing.Name = employee.Name;
                    existing.Email = employee.Email;
                    existing.Gender = employee.Gender;
                    existing.DepartmentNo = employee.DepartmentNo;
                    existing.DateOfBirth = employee.DateOfBirth;
                    existing.DateOfJoining = employee.DateOfJoining;
                    existing.ReportingTo = employee.ReportingTo;
                    existing.Phone = employee.Phone;
                    existing.Salary = employee.Salary;
                    existing.Commission = employee.Commission;
                    existing.JobTitle = employee.JobTitle;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static List<Employee> GetEmployees()
        {
            return _employees.Select(e => new Employee
            {
                Number = e.Number,
                Name = e.Name,
                Email = e.Email,
                Gender = e.Gender,
                Department = _departments.FirstOrDefault(d => d.DepartmentId == e.DepartmentNo)?.Name ?? "Unknown",
                DateOfBirth = e.DateOfBirth,
                DateOfJoining = e.DateOfJoining,
                Phone = e.Phone,
                Salary = e.Salary,
                Commission = e.Commission,
                JobTitle = e.JobTitle
            }).ToList();
        }

        public static Employee GetEmployee(int empId)
        {
            return _employees.FirstOrDefault(e => e.Number == empId);
        }

        public static List<Department> GetDepartmentList()
        {
            return _departments.ToList();
        }

        public static List<Employee> GetEmployeeNames()
        {
            var result = new List<Employee> { new Employee { Number = 0, Name = "No Manager" } };
            result.AddRange(_employees.Select(e => new Employee { Number = e.Number, Name = e.Name }));
            return result;
        }

        public static List<Employee> GetEmployeesByDept(int deptId)
        {
            return _employees.Where(e => e.DepartmentNo == deptId).Select(e => new Employee
            {
                Number = e.Number,
                Name = e.Name,
                Department = _departments.FirstOrDefault(d => d.DepartmentId == e.DepartmentNo)?.Name ?? "Unknown",
                Salary = e.Salary,
                JobTitle = e.JobTitle
            }).ToList();
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmpLoyeeRepository _context;
        public EmployeeController(EmpLoyeeRepository context)
        {
            _context = context;
        }

        [HttpGet("/api/AllEmpoyee")]
        public IEnumerable<EmpViewModel> GetAllEmployees()
        {
            List<Employee> employees = _context.GetEmployees();
            var empList = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmpId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportsTo = emp.ReportsTo
                }
                ).ToList();
            return empList;
        }
        
        [HttpGet("/GetEmployeeById")]
        public Employee GetEmployeeById(int empId)
        {
            return _context.FindEmployee(empId);
        }
        [HttpPut]
        public Employee  AddEmployee([FromBody]Employee emp)
        {
            Employee addedemp = _context.InsertEmployee(emp);
            return addedemp;
        }
        [HttpPost]
        public Employee UpdateEmployee(int id, [FromBody] Employee emp)
        {
            emp.EmployeeId = id;
            Employee savedemp = _context.UpdateEmployee(emp);
            return savedemp;
        }
        [HttpDelete]
        public void RemoveEmployee(int id)
        {
            Employee emp = _context.FindEmployee(id);
            if (emp != null)
            {
                _context.DeleteEmployee(id);
            }

        }

    }
}

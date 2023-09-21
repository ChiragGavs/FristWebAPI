using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
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
        public List<Employee> AllEmployee()
        {
            return _context.GetEmployees();
        }    
    }
}

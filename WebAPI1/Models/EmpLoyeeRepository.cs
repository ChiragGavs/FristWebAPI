using System.Diagnostics.Contracts;

namespace WebAPI1.Models
{
    public class EmpLoyeeRepository
    {
        private NorthwindContext _context;
         public EmpLoyeeRepository (NorthwindContext context)
        {
            _context = context;
        }
       public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee UpdateEmployee(Employee updatedEmployee)
        {



            _context.Employees.Attach(updatedEmployee);
            _context.SaveChanges();
            return updatedEmployee;

        }
    }
}

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
        public Employee InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
           
        }
       
        public Employee FindEmployee(int employeeId)
        {
            return _context.Employees.Find(employeeId);
        }
        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            _context.SaveChanges();
            return updatedEmployee;

        }
        public void DeleteEmployee(int employeeId)
        {
            var emp = _context.Employees.Find(employeeId);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("employee doesn not exist");
            }
        }
    }
}

using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using samplepro2.Data;
using samplepro2.Entity;
using samplepro2.Interfaces.Manager;
using samplepro2.Interfaces.Repository;
using samplepro2.Models;
using samplepro2.Repository;

namespace samplepro2.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        public bool Add(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        public bool CreateEmp(Employee employee)
        {
            return _employeeRepository.CreateEmployee(employee);
        }

        public bool DeleteEmp(Employee employee)
        {
            return _employeeRepository.DeleteEmployee(employee);
        }

        public Employee GetEmp(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        public IQueryable<Employee> GetEmps()
        {
            return _employeeRepository.GetEmployees();
        }

        public bool Save()
        {
            return _employeeRepository.Save();
        }

        public bool UpdateEmp(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }

        public List<FullEmployee> GetFullEmp()
        {
            return _employeeRepository.GetFullEmployee();
        }
        public List<Employee> SortEmployeeByDOJ()
        {
            return _employeeRepository.SortEmployeeByDateOfJoining();
        }
    }
}

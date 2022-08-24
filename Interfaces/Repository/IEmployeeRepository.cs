using EF.Core.Repository.Interface.Repository;
using samplepro2.Entity;
using samplepro2.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace samplepro2.Interfaces.Repository
{
    public interface IEmployeeRepository:ICommonRepository<Employee>
    {
        IQueryable<Employee> GetEmployees();
        Employee GetEmployee(int id);

        public List<FullEmployee> GetFullEmployee();
        Department GetDepartmentName(int id);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool Save();
        public List<Employee> SortEmployeeByDateOfJoining();
    }
}

using EF.Core.Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using samplepro2.Data;
using samplepro2.Interfaces.Repository;
using samplepro2.Models;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Web.Http;
using samplepro2.Entity;

namespace samplepro2.Repository
{
    public class EmployeeRepository : CommonRepository<Employee>, IEmployeeRepository
    {
        private readonly samplepro2DbContext _dbContext;

        public EmployeeRepository(samplepro2DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public bool CreateEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            return Save();
        }

        public bool DeleteEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            return Save();
        }

        public Employee GetEmployee(int id)
        {
            return _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
        }

        public Department GetDepartmentName(int id)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.DepartmentId == id);
        }

        public IQueryable<Employee> GetEmployees()
        {
            return _dbContext.Employees.AsQueryable();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            return Save();
        }
        public List<FullEmployee> GetFullEmployee()
        {
            var query = (from employee in _dbContext.Employees
                        join department in _dbContext.Departments
                                        on employee.DepartmentId equals department.DepartmentId

                         select new FullEmployee()
                         {
                             EmployeeId = employee.EmployeeId,
                             EmployeeName = employee.EmployeeName,
                             PhoneNumber = employee.PhoneNumber,
                             age = employee.age,
                             EmailId = employee.EmailId,
                             DateOfJoining = employee.DateOfJoining,
                             DepartmentName= department.DepartmentName,
                         }).ToList();

            
            return query;           
        }
        public List<Employee> SortEmployeeByDateOfJoining()
        {
            var query = (from employee in _dbContext.Employees
                         orderby employee.DateOfJoining ascending
                         select employee).ToList();
            return query;
        }
                  
        }
    }


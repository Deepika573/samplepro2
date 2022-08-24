using EF.Core.Repository.Repository;
using samplepro2.Data;
using samplepro2.Entity;
using samplepro2.Interfaces.Repository;

namespace samplepro2.Repository
{
    public class DepartmentRepository : CommonRepository<Department>, IDepartmentRepository
    {
        private readonly samplepro2DbContext _dbContext;

        public DepartmentRepository(samplepro2DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public bool CreateDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
            return Save();
        }

        public bool DeleteDepartment(Department department)
        {
            _dbContext.Departments.Remove(department);
            return Save();
        }

        public Department GetDepartment(int id)
        {
            return _dbContext.Departments.FirstOrDefault(x => x.DepartmentId == id);
        }

        public IQueryable<Department> GetDepartments()
        {
            return _dbContext.Departments.AsQueryable();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateDepartment(Department department)
        {
            _dbContext.Departments.Update(department);
            return Save();
        }
        public List<Employee> GetEmployeeDetails(string name)
        {
            var query = (from employee in _dbContext.Employees
                         join department in _dbContext.Departments
                                         on employee.DepartmentId equals department.DepartmentId
                         where department.DepartmentName == name

                         select new Employee()
                         {
                             EmployeeId = employee.EmployeeId,
                             EmployeeName = employee.EmployeeName,
                             PhoneNumber = employee.PhoneNumber,
                             age = employee.age,
                             EmailId = employee.EmailId,
                             DateOfJoining = employee.DateOfJoining,
                             DepartmentId = department.DepartmentId,
                         }).ToList();


            return query;

        }
    }
}

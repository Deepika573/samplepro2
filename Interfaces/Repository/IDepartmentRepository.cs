using EF.Core.Repository.Interface.Repository;
using samplepro2.Entity;

namespace samplepro2.Interfaces.Repository
{
    public interface IDepartmentRepository : ICommonRepository<Department>
        {
            IQueryable<Department> GetDepartments();
            Department GetDepartment(int id);

            bool CreateDepartment(Department department);
            bool UpdateDepartment(Department department);
            bool DeleteDepartment(Department department);
            bool Save();
        public List<Employee> GetEmployeeDetails(string name);
    }
}

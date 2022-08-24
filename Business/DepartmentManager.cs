using samplepro2.Entity;
using samplepro2.Interfaces.Business;
using samplepro2.Interfaces.Repository;

namespace samplepro2.Business
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }
        public bool Add(Department department)
        {
            return _departmentRepository.Add(department);
        }

        public bool CreateDep(Department department)
        {
            return _departmentRepository.CreateDepartment(department);
        }

        public bool DeleteDep(Department department)
        {
            return _departmentRepository.DeleteDepartment(department);
        }

        public Department GetDep(int id)
        {
            return _departmentRepository.GetDepartment(id);
        }

        public IQueryable<Department> GetDeps()
        {
            return _departmentRepository.GetDepartments();
        }

        public bool Save()
        {
            return _departmentRepository.Save();
        }

        public bool UpdateDep(Department department)
        {
            return _departmentRepository.UpdateDepartment(department);
        }
        public List<Employee> GetEmployeeDet(string name)
        {
            return _departmentRepository.GetEmployeeDetails(name);
        }
    }
}

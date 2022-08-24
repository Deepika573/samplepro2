using samplepro2.Entity;

namespace samplepro2.Interfaces.Business
{
    public interface IDepartmentManager
    {
        bool Add(Department entity);
        IQueryable<Department> GetDeps();
        Department GetDep(int id);
        bool CreateDep(Department department);
        bool UpdateDep(Department department);
        bool DeleteDep(Department department);
        bool Save();
        public List<Employee> GetEmployeeDet(string name);
    }
}

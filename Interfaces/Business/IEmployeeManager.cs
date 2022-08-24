using EF.Core.Repository.Interface.Manager;
using samplepro2.Entity;
using samplepro2.Models;

namespace samplepro2.Interfaces.Manager
{
    public interface IEmployeeManager
    {
        public List<FullEmployee> GetFullEmp();
        bool Add(Employee entity);
        IQueryable<Employee> GetEmps();
        Employee GetEmp(int id);
        bool CreateEmp(Employee employee);
        bool UpdateEmp(Employee employee);
        bool DeleteEmp(Employee employee);
        bool Save();
        public List<Employee> SortEmployeeByDOJ();
    }
}

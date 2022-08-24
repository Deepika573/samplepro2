using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using samplepro2.Data;
using samplepro2.Entity;
using samplepro2.Interfaces.Manager;
using samplepro2.Interfaces.Repository;
using samplepro2.Manager;
using samplepro2.Models;


namespace samplepro2.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]

    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
       
        [HttpGet]
        public IQueryable Get()
        {
            return _employeeManager.GetEmps();
        }

        [HttpGet]
        public List<FullEmployee> GetFullEmployees()
        {
            return _employeeManager.GetFullEmp();
        }

        [HttpGet]
        public List<Employee> SortEmployeeByDateOfJoining()
        {
            return _employeeManager.SortEmployeeByDOJ();
        }

        [HttpPost]
        public Employee Add(Employee employee)
        {
            bool isSaved = _employeeManager.Add(employee);
            if (isSaved)
            {
                return employee;
            }
            return null;
        }
        
        [HttpPut("{Id:int}")]
        public IActionResult Update(int Id, [FromBody] Employee employee)
        {
            if (employee == null || Id != employee.EmployeeId)
                return BadRequest(ModelState);

            if (!_employeeManager.UpdateEmp(employee))
            {
                ModelState.AddModelError("", $"Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        
        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int Id)
        {
            var depobj = _employeeManager.GetEmp(Id);

            if (!_employeeManager.DeleteEmp(depobj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

}
}
//public class DepartmentsController : Controller
//{
//private readonly samplepro2DbContext dbContext;

//public DepartmentsController(samplepro2DbContext dbContext)
//{
// this.dbContext = dbContext;
//}
/*public class DepartmentsController : ControllerBase
{
samplepro2DbContext _dbContext;
DepartmentManager _departmentManager;

    public DepartmentsController(samplepro2DbContext dbContext)
    {
        _dbContext = dbContext;
    _departmentManager = new DepartmentManager(dbContext);
    }*/
/*[HttpGet]
         public async Task<IActionResult> GetDepartements()
       {
           return Ok(await _dbContext.Departments.ToListAsync());
       }
       [HttpGet]

   public IQueryable Get()
   {
       return _departmentRepository.GetDepartments();
   }*/
/* public List<Department> GetAll()
         {
             var departements = _departmentManager.GetAll().ToList();
             return departements;
         }*/

/*[HttpPost]
public async Task<IActionResult> AddDepartment(AddDepartmentRequest addDepartmentRequest)
{
    var department = new Department()
    {
        Id = Guid.NewGuid(),
        EmployeeId = addDepartmentRequest.EmployeeId,
        EmployeeName = addDepartmentRequest.EmployeeName,   
        PhoneNumber = addDepartmentRequest.PhoneNumber,
        age= addDepartmentRequest.age,
        EmailId = addDepartmentRequest.EmailId,
        DepartmentName = addDepartmentRequest.DepartmentName
    };
    await _dbContext.Departments.AddAsync(department);
    await _dbContext.SaveChangesAsync();

    return Ok("Employee added");
}
[HttpPost]
public async Task<IActionResult> Post([FromBody] Department department)
{
    if (department == null)
        return BadRequest(ModelState);

    if (!_departmentRepository.CreateDepartment(department))
    {
        ModelState.AddModelError("", $"Something went wrong while saving record");
        return StatusCode(500, ModelState);
    }

    return Ok(department);
}*/
/*[HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] Guid id, UpdateDepartmentRequest updateDepartmentRequest)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            if(department != null)
            {
                department.EmployeeId = updateDepartmentRequest.EmployeeId;
                department.EmployeeName = updateDepartmentRequest.EmployeeName;
                department.PhoneNumber = updateDepartmentRequest.PhoneNumber;
                department.EmailId = updateDepartmentRequest.EmailId;
                department.DepartmentName = updateDepartmentRequest.DepartmentName;

                await _dbContext.SaveChangesAsync();
                return Ok("Employee updated");
            }
            return NotFound();

        }*/

/*[HttpPut]
[Route("{id:guid}")]
public async Task<IActionResult> UpdateDepartment([FromRoute] Guid id, UpdateDepartmentRequest updateDepartmentRequest)
{
    var department = await _dbContext.Departments.FindAsync(id);
    if (department != null)
    {
        department.EmployeeId = updateDepartmentRequest.EmployeeId;
        department.EmployeeName = updateDepartmentRequest.EmployeeName;
        department.PhoneNumber = updateDepartmentRequest.PhoneNumber;
        department.EmailId = updateDepartmentRequest.EmailId;
        department.DepartmentName = updateDepartmentRequest.DepartmentName;

        await _dbContext.SaveChangesAsync();
        return Ok("Employee updated");
    }
    return NotFound();

}*/
/*[HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] Guid id)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            if(department != null)
            {
                _dbContext.Remove(department);
                await _dbContext.SaveChangesAsync();
                return Ok("Employee deleted");
            }
            return NotFound();
        }*/
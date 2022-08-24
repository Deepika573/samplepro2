using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using samplepro2.Entity;
using samplepro2.Interfaces.Business;

namespace samplepro2.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "admin")]

    public class DepartmentsController : ControllerBase
        {
            private readonly IDepartmentManager _departmentManager;

            public DepartmentsController(IDepartmentManager departmentManager)
            {
                _departmentManager = departmentManager;
            }

            [HttpGet]

            public IQueryable Get()
            {
                return _departmentManager.GetDeps();
            }

        [HttpGet("{name}")]

        public List<Employee> GetEmployeesByDepartmentName(string name)
        {
            return _departmentManager.GetEmployeeDet(name);
        }

        [HttpPost]
            public Department Add(Department department)
            {
                bool isSaved = _departmentManager.Add(department);
                if (isSaved)
                {
                    return department;
                }
                return null;
            }

            [HttpPut("{Id:int}")]
            public IActionResult Update(int Id, [FromBody] Department department)
            {
                if (department == null || Id != department.DepartmentId)
                    return BadRequest(ModelState);

                if (!_departmentManager.UpdateDep(department))
                {
                    ModelState.AddModelError("", $"Something went wrong while updating");
                    return StatusCode(500, ModelState);
                }

                return NoContent();
            }

            [HttpDelete("{Id:int}")]
            public IActionResult Delete(int Id)
            {
                var depobj = _departmentManager.GetDep(Id);

                if (!_departmentManager.DeleteDep(depobj))
                {
                    ModelState.AddModelError("", $"Something went wrong while deleting");
                    return StatusCode(500, ModelState);
                }

                return NoContent();
            }

        }
    }

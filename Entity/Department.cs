using samplepro2.Models;
using System.ComponentModel.DataAnnotations;

namespace samplepro2.Entity
{
    public class Department
    {
        [Key]
        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "DepartmentName is required")]
        public string DepartmentName { get; set; }
    }
}

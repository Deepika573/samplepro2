using System.ComponentModel.DataAnnotations;

namespace samplepro2.Models
{
    public class FullEmployee
    {       
        public int EmployeeId { get; set; }        
        public string EmployeeName { get; set; }       
        public string PhoneNumber { get; set; }        
        public int age { get; set; }
        public string EmailId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string DepartmentName { get; set; }
    }
}

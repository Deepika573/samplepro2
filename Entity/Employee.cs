using System.ComponentModel.DataAnnotations;

namespace samplepro2.Entity
{
    public class Employee
    {

        [Required(ErrorMessage = "EmployeeId is required")]
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only characters are allowed")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^(\(?\s*\d{3}\s*[\)\-\.]?\s*)?[2-9]\d{2}\s*[\-\.]\s*\d{4}$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(18, 65)]
        public int age { get; set; }

        [Required(ErrorMessage = "Email id is required")]
        [RegularExpression(@"^\S+@\S+$", ErrorMessage = "Please enter a valid email address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "DateOfJoining is required")]
        //[RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Date format is invalid. Enter date in YYYY-MM-DD format")]
        public DateTime DateOfJoining { get; set; }

        [Required(ErrorMessage = "Department id is required")]
        public int DepartmentId { get; set; }
    }
}

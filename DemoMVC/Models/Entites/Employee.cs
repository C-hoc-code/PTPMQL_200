using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entites
{
    public class Employee
    {
        [Key]
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public string HireDate { get; set; }
    }
}

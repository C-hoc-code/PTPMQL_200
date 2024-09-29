using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entites
{
    public class Employee
    {
        [Key]
        public string EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeAddress { get; set; }
    }
}
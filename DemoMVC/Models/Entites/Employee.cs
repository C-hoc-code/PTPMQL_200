using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entites
{
    public class Employee : Person
    {
        public string EmployeeID { get; set; }

        public string CongTy { get; set; }
    }
}
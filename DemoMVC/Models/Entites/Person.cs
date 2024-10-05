using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entites
{
    public class Person
    {
        [Key]
        public string PersonID { get; set; }

        public string HoTen { get; set; }

        public string QueQuan { get; set; }
    }
}
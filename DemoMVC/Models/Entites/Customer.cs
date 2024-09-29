using System.ComponentModel.DataAnnotations; 

namespace DemoMVC.Models.Entites
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        [MinLength(3)]
        [Required(ErrorMessage = "Đây là phần bắt buộc nhập")]

        public string FullName { get; set; }

        public string? Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
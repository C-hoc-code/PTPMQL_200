

using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entites
{
    public class Student
    {
        [Key]
        public string StudentID { get; set; }
        public string FullName { get; set; }

        public int? MaLop { get; set; }
        public LopHoc? LopHoc { get; set; }

    }
}
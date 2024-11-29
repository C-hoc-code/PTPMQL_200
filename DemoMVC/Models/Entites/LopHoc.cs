using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entites
{
    public class LopHoc
    {
        [Key]
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public ICollection<Student>? Students{ get; set; }
    }
}
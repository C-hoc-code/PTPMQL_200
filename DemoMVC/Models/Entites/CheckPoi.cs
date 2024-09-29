using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entites
{
    public class CheckPoi
    {
        [Key]
        public string PoiId { get; set; }
        public string NamePoi { get; set; }

        public string poi { get; set; }
    }
}
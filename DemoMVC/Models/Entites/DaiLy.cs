using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entites
{
    public class DaiLy : HeThongPhanPhoi
    {
        public string MaDaiLy { get; set; }

        public string TenDaiLy { get; set; }

        public string DiaChi { get; set; }

        public string NguoiDaiDien { get; set; }

        public string DienThoai { get; set; }
    }
}
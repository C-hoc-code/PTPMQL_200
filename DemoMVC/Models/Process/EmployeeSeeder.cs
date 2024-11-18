using Bogus;
using DemoMVC.Data;
using DemoMVC.Models.Entites;

namespace DemoMVC.Models.Process
{
    public class EmployeeSeeder
    {
        private readonly ApplicationContext _context;

        public EmployeeSeeder(ApplicationContext context)
        {
            _context = context;
        }

        public void SeedEmployees(int n)
        {
            var employees = GenerateEmployees(n);
            _context.Employee.AddRange(employees);  // Thêm danh sách nhân viên vào cơ sở dữ liệu
            _context.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
        }

        private List<Employee> GenerateEmployees(int n)
        {
            var faker = new Faker<Employee>()
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())  // Sinh tên đầu
                .RuleFor(e => e.LastName, f => f.Name.LastName())  // Sinh tên họ
                .RuleFor(e => e.Address, f => f.Address.FullAddress())  // Sinh địa chỉ
                .RuleFor(e => e.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))  // Sinh ngày sinh (từ 18 tuổi đến 30 năm trước)
                .RuleFor(e => e.Position, f => f.Name.JobTitle())  // Sinh vị trí công việc
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))  // Sinh email
                .RuleFor(e => e.HireDate, f => f.Date.Past(10));  // Sinh ngày thuê (từ 10 năm trước)
            
            return faker.Generate(n);  // Tạo ra danh sách nhân viên
        }
    }
}

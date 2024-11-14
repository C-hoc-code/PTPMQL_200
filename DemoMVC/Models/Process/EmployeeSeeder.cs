// using Bogus;
// using DemoMVC.Data;
// using DemoMVC.Models.Entites;

// namespace DemoMVC.Models.Process
// {
//     public class EmployeeSeeder
//     {
//         private readonly ApplicationContext _context;
//         public EmployeeSeeder(ApplicationContext context)
//         {
//             _context = context;
//         }
//         public void SeedEmployees(int n)
//         {
//             var employees = GenerateEmployees(n);
//             _context.Employee.AddRange(employees);
//             _context.SaveChanges();
//         }
//         private List<Employee> GenerateEmployees(int n)
//         {
//              var faker = new Faker<Employee>()
//                 .RuleFor(e => e.FirstName, f => f.Name.FirstName())
//                 .RuleFor(e => e.LastName, f => f.Name.LastName())
//                 .RuleFor(e => e.Address, f => f.Address.FullAddress())
//                 .RuleFor(e => e.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
//                 .RuleFor(e => e.Position, f => f.Name.JobTitle())
//                 .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
//                 .RuleFor(e => e.HireDate, f => f.Date.Past(10));
//             return faker.Generate(n);
//         }
//     }
// }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Models.Entites;

namespace DemoMVC.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<Person> Person { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<HeThongPhanPhoi> HeThongPhanPhoi { get; set; } = default!;

        public DbSet<DaiLy> DaiLy { get; set; } = default!;


    }
}

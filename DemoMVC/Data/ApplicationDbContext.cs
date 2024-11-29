using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Models.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DemoMVC.Models;
using DemoMVC.Controllers;

namespace DemoMVC.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
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
        public DbSet<MemberUnit> MemberUnit { get; set; } = default!;
        public DbSet<LopHoc> LopHoc { get; set; } = default!;

         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<LopHoc>()
            .HasMany(e => e.Students)
            .WithOne(e => e.LopHoc)
            .HasForeignKey(e => e.MaLop)
            .OnDelete(DeleteBehavior.Restrict);
    }
    }
}

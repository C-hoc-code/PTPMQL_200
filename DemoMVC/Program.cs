using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DemoMVC.Data;
using Microsoft.AspNetCore.Identity;
using DemoMVC.Models;
using Microsoft.Extensions.Options;
using DemoMVC.Models.Process;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security;

var builder = WebApplication.CreateBuilder(args);

// Gửi về maill
builder.Services.AddOptions();
var mailSettings = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailSettings);
builder.Services.AddTransient<IEmailSender, SendMailService>();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationContext' not found.")));

// builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationContext>();

// Quản lí role
builder.Services.AddRazorPages();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();


builder.Services.AddControllersWithViews();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Mặc định khóa đăng nhâp
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình mật khẩu
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;

    // Cấu hình xác thực tài khoản gửi về emaill và sdt
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

    //Cấu hình tài khoản người dùng
    options.User.RequireUniqueEmail = true;
});

// Cấu hình coockie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

// Thêm sửa xóa Claim cho user
builder.Services.AddAuthorization(options =>
{
    foreach (var permission in Enum.GetValues(typeof(SystemPermissions)).Cast<SystemPermissions>())
    {
        options.AddPolicy(permission.ToString(), policy => 
        policy.RequireClaim("Permission",permission.ToString()));
    }   
    // options.AddPolicy("Role", policy => policy.RequireClaim("Role", "AdminOnly"));
    // options.AddPolicy("Permission", policy => policy.RequireClaim("Role", "EmployeeOnly"));
    // options.AddPolicy("PolicyAdmin", policy => policy.RequireRole("Admin"));
    // options.AddPolicy("PolicyEmployee", policy => policy.RequireRole("Employee"));
    // options.AddPolicy("PolicyByPhoneNumber", policy => policy.Requirements.Add(new PolicyByPhoneNumberRequirement()));
});
builder.Services.AddSingleton<IAuthorizationHandler, PolicyByPhoneNumberHandler>();

// Employee
builder.Services.AddTransient<EmployeeSeeder>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});



var app = builder.Build();

// Employee
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<EmployeeSeeder>();
    seeder.SeedEmployees(1000);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

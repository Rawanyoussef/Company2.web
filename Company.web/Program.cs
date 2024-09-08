using Company.Data.Contexts;
using Company.Reposatory.Interfaces;
using Company.Reposatory.Reposatory;
using Company.Services.Services;
using Company.Servies.Mapping;
using Company.web.Interfaces;
using Company.web.Interfaces.services;
using Microsoft.EntityFrameworkCore;

namespace Company.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CompanyDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmployeeReposatory, EmployeeReposatory>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddScoped<IDepartmentServices, DepartmentService>();
            builder.Services.AddAutoMapper(x=>x.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new DepartmentProfile()));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

using Book.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Book_club
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin");
            });
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["DefaultConnection"], b => b.MigrationsAssembly("Book.Database")));
            services.AddSession();

            services.AddIdentity<IdentityUser,IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Accounts/Login";
                options.LogoutPath = "/Accounts/Logout";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Role","Admin"));
            });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();/*
                endpoints.MapControllers();*/
            });

        }
    }
}

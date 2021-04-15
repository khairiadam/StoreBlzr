using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Data;
using Server.Services.Authentication;
using Server.Services.Categories;
using Server.Services.Orders;
using Server.Services.Products;
using Server.Services.Users;
using Shared;
using System.Linq;

namespace StoreBlzr.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public readonly string AllowSpecificOrigins = "_AllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //!!_ Allow API Access
            services.AddCors(op =>
                       {
                           op.AddPolicy(
                               AllowSpecificOrigins, builder => builder
                                   .AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                           );
                       });

            //!! Add Identity with Roles ===>
            services.AddIdentity<AppClient, IdentityRole>(opt => opt.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<StoreDbContext>();


            //!! Add DBContext ===>
            services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("ConnString")));


            //!! _ DependencyInjection ===>
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryService, CategoryService>();

            //!! _ AddAutoMapper
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(c =>
            {
                c.AllowNullCollections = true;
                // c.AllowNullDestinationValues = true;

            });

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}

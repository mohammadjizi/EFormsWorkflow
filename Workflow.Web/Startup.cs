using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Web.Mvc;
using Workflow.Data.Infrastructure;
using Workflow.Data.Repositories;
using Workflow.Forms.Repositories;
using Workflow.Service;
using Workflow.Web.Data;

namespace WorkflowForms
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddDbContext<WorkflowEntities>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            Workflow.Web.Mappings.AutoMapperConfiguration.Configure();

            var builder = new ContainerBuilder();

            //// If you want to set up a controller for, say, property injection
            //// you can override the controller registration after populating services.


            //// When you do service population, it will include your controller
            //// types automatically.
            builder.Populate(services);

            builder.RegisterType<Disposable>().As<IDisposable>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<ApplicationDescriptionRepository>().As<IApplicationDescriptionRepository>();
            builder.RegisterType<ApplicationDetailRepository>().As<IApplicationDetailRepository>();
            builder.RegisterType<EquationCustomerRepository>().As<IEquationCustomerRepository>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<ApplicationDescriptionService>().As<IApplicationDescriptionService>();
            builder.RegisterType<ApplicationDetailService>().As<IApplicationDetailService>();
            builder.RegisterType<EquationCustomerService>().As<IEquationCustomerService>();

            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

}

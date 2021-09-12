using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.Services;
using CampusCRM.DAL;
using CampusCRM.DAL.Contexts;
using CampusCRM.DAL.Interfaces;
using CampusCRM.MVC.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CampusCRM.Mail;
using CampusCRM.Mail.Interfaces;
using CampusCRM.MVC.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace CampusCRM.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            // services.AddDbContext<CampusContext>();
            services.AddDbContext<CampusContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("CampusConnectionStringDB")));
       

            services.AddDefaultIdentity<IdentityUser>(
                    options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CampusContext>();

            //services.AddIdentity<IdentityUser, IdentityRole>(
            //        options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddDefaultUI()
            //    .AddEntityFrameworkStores<CampusContext>()
            //    .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.AddPolicy("ManageAndDevDepart", policy => //AllRolesFromManagementAndDevelopmentDepartment
                    policy.RequireRole("Admin", "Manager"));
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ITeacherService, TeacherService>();
            
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IStudentRequestService, StudentRequestService>();

            // services.AddTransient<IMailService, EmailService>();

            EmailSettingsModel emailSettings = new EmailSettingsModel();
            Configuration.GetSection("EmailSettings").Bind(emailSettings);
            EmailService emailService = new EmailService(emailSettings);
            services.AddSingleton(emailService);
            services.Configure<SecurityOptions>(
                Configuration.GetSection(SecurityOptions.SectionTitle));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IOptions<SecurityOptions> securityOptions,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
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

            loggerFactory.AddFile($"Logs/log.txt");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateRoles(serviceProvider, securityOptions).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider, IOptions<SecurityOptions> securityOptions)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "Manager" };
            foreach (var roleName in roles)
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });


            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var adminUser = await userManager.FindByEmailAsync(securityOptions.Value.AdminUserEmail);
            if (adminUser != null)
                await userManager.AddToRoleAsync(adminUser, "Admin");

            var managerUser = await userManager.FindByEmailAsync(Configuration["Security:ManagerUserEmail"]);
            if (managerUser != null) 
                await userManager.AddToRoleAsync(managerUser, "Manager");


        }
    }
}

using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOffice.ServiceInterfaces.ReferencialAsset;
using LimbaBackOffice.ServiceInterfaces.WorkSpace;
using LimbaBackOffice.ServiceInterfaces.WorkSpaceAsset;
using LimbaBackOffice.Services;
using LimbaBackOffice.Services.ReferencialAsset;
using LimbaBackOffice.Services.WorkSpaceAsset;
using LimbaBackOfficeData.Repositories;
using LimbaBackOfficeData.Repositories.WorkSpaceAsset;
using LimbaBackOfficeData.RepositoryInterfaces;
using LimbaBackOfficeData.RepositoryInterfaces.ReferencialAsset;
using LimbaBackOfficeData.RepositoryInterfaces.WorkSpaceAsset;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;




namespace LimbaBackOffice
{
    public class Startup
    {
        private IDbConnection _db = new SqlConnection();
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _db = new SqlConnection(Configuration["Data:DefaultConnection:ConnectionString"]);

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IWorkSpaceService, WorkSpaceService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IWorkSpaceUserService, WorkSpaceUserService>();
            services.AddScoped<ITaskLogService, TaskLogService>();

            services.AddScoped<IAppUserRespository, AppUserRespository>();
            services.AddScoped<IWorkSpaceRespository, WorkSpaceRespository>();
            services.AddScoped<IDepartmentRespository, DepartmentRespository>();
            services.AddScoped<IWorkSpaceUserRepository, WorkSpaceUserRepository>();
            services.AddScoped<ITaskLogRepository, TaskLogRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

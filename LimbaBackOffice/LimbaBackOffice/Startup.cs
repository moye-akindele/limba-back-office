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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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
            var secretKey = Configuration["Data:IssuerSignInKey"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    //ValidIssuer = "",
                    //ValidAudience = "",

                    ValidIssuer = Configuration["Data:baseUrl"],
                    ValidAudience = Configuration["Data:baseUrl"],

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

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

            AddServices(services);
            AddRepositories(services);

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

            app.UseAuthentication();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // List of Controller Services.
        public void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IWorkSpaceService, WorkSpaceService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IWorkSpaceUserService, WorkSpaceUserService>();
            services.AddScoped<ITaskLogService, TaskLogService>();
        }

        // List of Controller Repositories.
        public void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IAppUserRespository, AppUserRespository>();
            services.AddScoped<IWorkSpaceRespository, WorkSpaceRespository>();
            services.AddScoped<IDepartmentRespository, DepartmentRespository>();
            services.AddScoped<IWorkSpaceUserRepository, WorkSpaceUserRepository>();
            services.AddScoped<ITaskLogRepository, TaskLogRepository>();
        }
    }
}

using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOffice.Services;
using LimbaBackOfficeData.Repositories;
using LimbaBackOfficeData.RepositoryInterfaces;
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

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _db = new SqlConnection(Configuration["Data:DefaultConnection:ConnectionString"]);

            services.AddScoped<IAppUserService, AppUserService>();

            services.AddScoped<IAppUserRespository, AppUserRespository>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

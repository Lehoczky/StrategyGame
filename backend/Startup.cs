using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace backend
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
            services.AddDbContext<StrategyGameContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("Database")
            ));

            services.AddControllers();
            // services.AddScoped<IBuildingRepository, MockBuildingRepository>();
            // services.AddScoped<IUnitRepository, MockUnitRepository>();
            // services.AddScoped<IUpgradeRepository, MockUpgradeRepository>();
            // services.AddScoped<IUserRepository, MockUserRepository>();

            services.AddScoped<IBuildingRepository, SqlBuildingRepository>();
            services.AddScoped<IUnitRepository, SqlUnitRepository>();
            services.AddScoped<IUpgradeRepository, SqlUpgradeRepository>();
            services.AddScoped<IUserRepository, sqlUserRepository>();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersInventory.DAL;
using ComputersInventory.DAL.Interfaces;
using ComputersInventory.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ComputersInventory
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins1";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string[] OriginList = Configuration.GetValue<string>("OriginList").Split(',');
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(OriginList)
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();

                                  });
            });
            services.AddDbContext<ComputerInventoryContext>(ops => ops.UseSqlServer(Configuration.GetConnectionString("ComputersInventory")));
            services.AddScoped<IComputerTypeRepository, ComputerTypeRepository>();
            services.AddScoped<IComputerRepository, ComputerRepository>();
            services.AddScoped<IFormFactorRepository, FormFactorRepository>();
            services.AddScoped<IScreenSizeRepository, ScreenSizeRepository>();
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

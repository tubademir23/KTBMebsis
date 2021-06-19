using KTB.API.DTOs.ErrorHandling;
using KTB.Core.Repositories;
using KTB.Core.Services;
using KTB.Core.UnitOfWorks;
using KTB.Data;
using KTB.Data.Repositories;
using KTB.Data.UnitOfWorks;
using KTB.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace KTB.API
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IGenericRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<IEserService, EserService>();
            services.AddScoped<IUyeService, UyeService>();
            services.AddScoped<IMeslekService, MeslekService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
           {
               options.UseNpgsql(Configuration.GetConnectionString("MebsisConnection"));

           });
            
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseExceptionHandler(c =>
            {
                c.Run(async context =>
                {
                     var ex = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                    ErrorDto errorDto = new ErrorDto(500);
                    errorDto.Errors.Add(ex.Message);
                    var response = new { error = ex.Message };
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                });
            });
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

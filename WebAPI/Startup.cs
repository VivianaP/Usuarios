using Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Persistence;
using Shared;
using WebAPI.Extensions;

namespace WebAPI
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAplicationLayer();
            services.AddSharedInfraestructure(Configuration);
            services.AddPersistenceInfraestructure(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }


        //  Uncomment if using a custom DI container
        //  public void ConfigureContainer(ContainerBuilder builder)
        //  {
        //  }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseErrorHandlingMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}

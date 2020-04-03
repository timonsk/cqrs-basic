using CQRS.Handlers.Commands;
using CQRS.Handlers.Queries;
using CQRS.Interfaces.Commands;
using CQRS.Interfaces.Queries;
using CQRS.Interfaces.Storage;
using CQRS.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQRS
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
            RegisterDependencies(services);
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

        private void RegisterDependencies(IServiceCollection services)
        {
            // Register product handlers
            services.AddScoped<IProductCommandHandler, ProductCommandHandler>();
            services.AddScoped<IProductQueryHandler, ProductQueryHandler>();

            // Register category handlers
            services.AddScoped<ICategoryCommandHandler, CategoryCommandHandler>();
            services.AddScoped<ICategoryQueryHandler, CategoryQueryHandler>();

            services.AddSingleton<IInMemoryStorage, InMemoryStorage>();
        }
    }
}

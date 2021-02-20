using canalhice.api.Helpers;
using canalhice.services.commands;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Canalhice
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.Configure<IISOptions>(o =>
            {
                o.ForwardClientCertificate = false;
            });
            services.AddSwaggerGen();

            services.AddMediatR(Assembly.GetExecutingAssembly());


            var assemblyCommands = typeof(PrimeiroServicoHandler).Assembly;

            services.AddMediatR(assemblyCommands);
            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(RequestGenericExceptionHandler<,,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseRouting();

            app.UseCors("PermitirTodos");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Canalhice api v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=ControllerInicial}/{action=RotaInicial}/{id?}");
            });

        }
    }
}

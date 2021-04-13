using AutoMapper;
using FiledPaymentService.DB;
using FiledPaymentService.PaymentProviders.Interfaces;
using FiledPaymentService.Repositories.Interfaces;
using FiledPaymentService.Services.Commands.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FiledPaymentService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<FiledDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("conn")));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.Scan(
                    x =>
                    {
                        var entryAssembly = Assembly.GetEntryAssembly();
                        var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
                        var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);

                        x.FromAssemblies(assemblies)
                            .AddClasses(classes => classes.AssignableTo(typeof(IUnitOfWork)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime()
                            .AddClasses(classes => classes.AssignableTo(typeof(IPaymentStatusRepository)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime()
                            .AddClasses(classes => classes.AssignableTo(typeof(IPaymentRepository)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime()
                            .AddClasses(classes => classes.AssignableTo(typeof(ICheapPaymentGateway)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime()
                            .AddClasses(classes => classes.AssignableTo(typeof(IExpensivePaymentGateway)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime()
                            .AddClasses(classes => classes.AssignableTo(typeof(IPremiumPaymentGateway)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime()
                            .AddClasses(classes => classes.AssignableTo(typeof(IInvoker)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime()
                            .AddClasses(classes => classes.AssignableTo(typeof(ILogger<>)))
                            .AsImplementedInterfaces()
                            .WithSingletonLifetime();
                    });
        }

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

using FormularzWinForms.Presenters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularzWinForms.Models.Configurations
{
    public static class FormConfiguration
    {
        public static IServiceProvider ServiceProvider { get; set; } = default!;

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.RegisterServices();
               });

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IXmlSaveToFile, XmlSaveToFile>();
            services.AddTransient<IXmlReadFromFile, XmlReadFromFile>();
            services.AddTransient<IEmployeeModel, Employee>();
            services.AddTransient<IEmployeeView, EmployeeView>();
            services.AddTransient<EmployeePresenter>();

            return services;
        }
    }
}

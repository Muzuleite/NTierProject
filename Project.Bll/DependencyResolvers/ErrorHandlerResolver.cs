using Microsoft.Extensions.DependencyInjection;
using Project.Bll.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DependencyResolvers
{
    public static class ErrorHandlerResolver
    {
        public static void AddErrorHandlerService(this IServiceCollection services)
        {
            services.AddScoped<IErrorHandler, ErrorHandler>();
        }
    }
}

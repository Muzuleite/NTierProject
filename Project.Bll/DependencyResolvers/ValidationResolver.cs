using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DependencyResolvers
{
    public static class ValidationResolver
    {
        public static void AddValidationServices(this IServiceCollection services)
        {
            // Validation assembly’sini otomatik tara
            services.AddValidatorsFromAssembly(typeof(ValidationResolver).Assembly);
        }
    }
}

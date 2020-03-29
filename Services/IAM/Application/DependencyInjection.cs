using System;
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nmro.IAM.Application.Interfaces;

namespace Nmro.IAM.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("ASSEMBLY: AddMediatR SCAN IN {0}", assembly.GetName().Name);

            services.AddScoped<IPasswordProcessor, PasswordProcessor>();
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);

            return services;
        }
    }
}

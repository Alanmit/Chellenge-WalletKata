﻿using Application.Common.Interfaces;
using Infrastructure.Queries;
using Infrastructure.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Boopstrap
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddTransient<IWalletKataDbContextEntity, WalletKataDbContextEntity>();
            
            return services;
        }

    }
}

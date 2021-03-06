﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation;
using FluentValidation.AspNetCore;
using UserManagementAPI.Filters;

namespace UserManagementAPI.Installers
{
    public class MVCInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddMvc(options => options.Filters.Add<ValidationFilter>());
            services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new Info() { Title = "UserManagment API", Version = "v1" }); });
          
        }
    }
}

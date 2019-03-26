using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CashPrototype_v2._2.Web.Api.Core.AutoMapper;
using CashPrototype_v2._2.Web.Api.Core.Interfaces;
using CashPrototype_v2._2.Web.Api.Core.Services;
using CashPrototype_v2._2.Web.Api.Infrastructure.Entities.Users;
using CashPrototype_v2._2.Web.Api.Infrastructure.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CashPrototype_v2._2.Web.Api
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
            services.AddDbContext<CashDbContext>(opt => opt.UseMySQL(Configuration["mySqlConnection:localConnectionString"]));
            //services.AddDbContext<AuthenticationDbContext>(opt => opt.UseMySQL(Configuration["mySqlConnection:localConnectionString"]));

            services.AddDefaultIdentity<User>().AddEntityFrameworkStores<CashDbContext>();
            //services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<AuthenticationDbContext>();

            services.AddScoped<IServiceAccount, ServiceAccount>();
            services.AddScoped<IServiceAccountType, ServiceAccountType>();
            services.AddScoped<IServiceCategory, ServiceCategory>();
            services.AddScoped<IServiceCategoryType, ServiceCategoryType>();
            services.AddScoped<IServiceCurrency, ServiceCurrency>();
            services.AddScoped<IServicePerson, ServicePerson>();
            services.AddScoped<IServicePersonType, ServicePersonType>();
            services.AddScoped<IServicePurchase, ServicePurchase>();
            services.AddScoped<IServiceTransaction, ServiceTransaction>();
            services.AddScoped<IServiceTransactionType, ServiceTransactionType>();
            services.AddScoped<IServiceTransactionRetentive, ServiceTransactionRetentive>();
            services.AddScoped<IServiceAuthenticationUser, ServiceAuthenticationUser>();

            services.AddAutoMapper();

            services.AddLogging();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IMapper mapper)
        {
            loggerFactory.CreateLogger("Error");
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

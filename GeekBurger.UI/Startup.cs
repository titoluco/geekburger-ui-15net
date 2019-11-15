using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GeekBurger.UI.Helper;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using GeekBurger.UI.Service;
using GeekBurger.UI.Polly;


namespace GeekBurger.UI
{
    public class Startup
    {
        public static IConfiguration Configuration;
        public IHostingEnvironment HostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var mvcCoreBuilder = services.AddMvcCore();
            mvcCoreBuilder
            .AddFormatterMappings()
            .AddJsonFormatters()
            .AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Swagger Implementation",
                    Description = "Available Web APIs",
                    TermsOfService = "None"
                });
            });

            
            services.AddSingleton<IMetodosApi, MetodosApi>();
            services.AddSingleton<IServiceBusTopics, ServiceBusTopics>();
            services.AddSingleton<IReceiveMessagesFactory, ReceiveMessagesFactory>();
            services.AddSingleton<IReadStoreCatalog, ReadStoreCatalog>();
            services.AddAutoMapper();
            services.AddSignalR();
            services.AddPollyPolicies();

            services.AddSingleton<IShowDisplayService, ShowDisplayService>();
            services.AddSingleton<ILogService, LogService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            if (HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseMvc();

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseSignalR(routes =>
            {
                routes.MapHub<MessageHub>("/messagehub");
            });
            
            //criação dos tópicos e subscribers
            app.ApplicationServices.GetService<IServiceBusTopics>();
            
            //instancia que receberá as mensagens
            app.ApplicationServices.GetService<IReceiveMessagesFactory>();

            //instancia da lista de catálogos
            app.ApplicationServices.GetService<IReadStoreCatalog>();
            
        }
    }
}

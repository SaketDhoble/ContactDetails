using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Cors.Infrastructure;
using ContactDetails.StaticStuff;
using ContactDetails.BL;
using ContactDetails.BL.Interfaces;
using ContactDetails.DAL;
using ContactDetails.DAL.Interfaces;

namespace ContactDetails
{
    public class Startup
    {
        public static string ConnectionString { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", corsBuilder.Build());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Contact Details API", Version = "v1" });
                c.OperationFilter<SwaggerFileOperationFilter>();
            });

            services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; });
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddScoped<ITblContactDetailsBL, TblContactDetailsBL>();
            services.AddScoped<ITblContactDetailsDAL, TblContactDetailsDAL>();


            services.AddMvc();
            ConnectionString = Configuration.GetSection("Data:DefaultConnection").Value.ToString();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Contact Details API V1");
            });

            app.UseMvc(); ;
        }
    }
}

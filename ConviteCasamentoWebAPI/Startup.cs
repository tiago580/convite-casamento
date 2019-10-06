using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ConviteCasamentoRepositorio;
using ConviteCasamentoNegocio;
using AutoMapper;

namespace ConviteCasamentoWebAPI
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder => {
                builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
            }));
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ConviteCasamentoContext> (
                   options => options.UseSqlServer(
                       Configuration.GetConnectionString("AppConnection")));
            //services.AddControllers();
            services.AddMvc(o => o.EnableEndpointRouting = false);
            services.AddScoped<IEventoRepositorio, EventoRepositorio>();
            services.AddScoped<IEventoNegocio, EventoNegocio>();
            
            services.AddScoped<IConvidadoRepositorio, ConvidadoRepositorio>();
            services.AddScoped<IConvidadoNegocio, ConvidadoNegocio>();
            
            services.AddScoped<DbContext, ConviteCasamentoContext>();

            services.AddAutoMapper(typeof(ConviteCasamentoNegocioMapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();
            app.UseCors("MyPolicy");

            app.UseStatusCodePages();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}

using ASX43O_HFT_2021221.Logic;
using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ASX43O_HFT_2021221.Endpoint.Services;

namespace ASX43O_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient <IPlayerCharacterLogic, PlayerCharacterLogic> ();
            services.AddTransient <IPlayerRaceLogic, PlayerRaceLogic> ();
            services.AddTransient <IPlayerClassLogic, PlayerClassLogic> ();
            //services.AddTransient <IPlayerSkillLogic, PlayerSkillLogic> ();
            services.AddTransient <IPlayerItemLogic, PlayerItemLogic> ();
            services.AddTransient <INonCrudLogic, NonCrudLogic>();
            
            services.AddTransient <ICharacterRepository, PlayerCharRepo>();
            services.AddTransient <IRaceRepository, PlayerRaceRepo> ();
            services.AddTransient <IClassRepository, PlayerClassRepo> ();
            //services.AddTransient <ISkillRepository, PlayerSkillRepo> ();
            services.AddTransient <IItemRepository, PlayerItemRepo> ();

            //services.AddTransient<DbContext, RPGDbContext>();
            services.AddTransient<RPGDbContext, RPGDbContext>();

            services.AddSignalR();

            services.AddControllers();

            services.AddSwaggerGen( c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASX43O_HFT_2021221.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASX43O_HFT_2021221.Endpoint v1"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:42818"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}

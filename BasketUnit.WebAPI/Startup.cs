using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BasketUnit.WebAPI.Services;

namespace BasketUnit.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddOptions();
            services.AddControllers();
            services.AddDbContext<MainDatabaseContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MainDatabaseContext")));
            services.AddScoped<IRepositoriesWrapper, RepositoriesWrapper>();
            services.AddTransient<IAppRoleService, AppRoleService>();
            services.AddTransient<IAppUserRoleService, AppUserRoleService>();
            services.AddTransient<IAppUserService, AppUserService>();
            services.AddTransient<IFunctionalityAppRoleService, FunctionalityAppRoleService>();
            services.AddTransient<IFunctionalityService, FunctionalityService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IGameRefereesService, GameRefereesService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGameTeamService, GameTeamsService>();
            services.AddTransient<ICoachService, CoachService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IRefereeService, RefereeService>();
            services.AddTransient<IStatsService, StatsService>();
            services.AddTransient<IArenaService, ArenaService>();
            services.AddTransient<ITeamFirstLineupService, TeamFirstLineupService>();
            services.AddTransient<ITeamLineupService, TeamLineupService>();
            services.AddTransient<ITeamScheduleActivityService, TeamScheduleActivityService>();
            services.AddTransient<ITeamScheduleService, TeamScheduleService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IWorkoutService, WorkoutService>();
            services.AddTransient<IWorkoutTypeService, WorkoutTypeService>();
            services.AddTransient<INationalityService, NationalityService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

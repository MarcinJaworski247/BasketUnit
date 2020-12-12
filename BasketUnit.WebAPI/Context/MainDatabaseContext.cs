using BasketUnit.WebAPI.Configurations;
using BasketUnit.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Context
{
    public class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext (DbContextOptions<MainDatabaseContext> options)
            : base(options)
        { }
        //Add-Migration InitialCreate
        //Update-Database
        #region AppUsers
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Functionality> Functionalities { get; set; }
        public DbSet<FunctionalityAppRole> FunctionalityAppRoles { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        #endregion
        #region Games
        public DbSet<Game> Games { get; set; }
        public DbSet<GameReferees> GameReferees { get; set; }
        public DbSet<GameTeams> GameTeams { get; set; }
        #endregion
        #region People
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<PlayerInjury> PlayerInjuries { get; set; }
        #endregion
        #region Stats
        public DbSet<Stats> Stats { get; set; }
        #endregion
        #region Teams
        public DbSet<Arena> Arenas { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamFirstLineup> TeamFirstLineups { get; set; }
        public DbSet<TeamLineup> TeamLineups { get; set; }
        public DbSet<TeamSchedule> TeamSchedules { get; set; }
        public DbSet<TeamScheduleActivity> TeamScheduleActivities { get; set; }
        public DbSet<College> Colleges { get; set; }
        #endregion
        #region Workouts
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region AppUsers
            builder.ApplyConfiguration(new AppRoleConfiguration());
            //builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppUserRoleConfiguration());
            builder.ApplyConfiguration(new FunctionalityAppRoleConfiguration());
            builder.ApplyConfiguration(new FunctionalityConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());
            #endregion
            #region Games
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new GameRefereesConfiguration());
            builder.ApplyConfiguration(new GameTeamsConfiguration());
            #endregion
            #region People
            builder.ApplyConfiguration(new CoachConfiguration());
            builder.ApplyConfiguration(new PlayerConfiguration());
            builder.ApplyConfiguration(new RefereeConfiguration());
            builder.ApplyConfiguration(new PlayerInjuryConfiguration());
            #endregion
            #region Stats
            builder.ApplyConfiguration(new StatsConfiguration());
            #endregion
            #region Teams
            builder.ApplyConfiguration(new ArenaConfiguration());
            builder.ApplyConfiguration(new TeamConfiguration());
            builder.ApplyConfiguration(new TeamFirstLineupConfiguration());
            builder.ApplyConfiguration(new TeamLineupConfiguration());
            builder.ApplyConfiguration(new TeamScheduleActivityConfiguration());
            builder.ApplyConfiguration(new TeamScheduleConfiguration());
            builder.ApplyConfiguration(new CollegeConfiguration());
            #endregion
            #region Workouts
            builder.ApplyConfiguration(new WorkoutConfiguration());
            builder.ApplyConfiguration(new WorkoutTypeConfiguration());
            #endregion
        }
    }
}

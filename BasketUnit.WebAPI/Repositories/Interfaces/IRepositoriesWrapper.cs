using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface IRepositoriesWrapper : IDisposable
    {
        IAppRoleRepository AppRoleRepository { get; }
        IAppUserRepository AppUserRepository { get; }
        IAppUserRoleRepository AppUserRoleRepository { get; }
        IFunctionalityAppRoleRepository FunctionalityAppRoleRepository { get; }
        IFunctionalityRepository FunctionalityRepository { get; }
        IPersonRepository PersonRepository { get; }
        IGameRefereesRepository GameRefereesRepository { get; }
        IGameRepository GameRepository { get; }
        IGameTeamsRepository GameTeamsRepository { get; }
        ICoachRepository CoachRepository { get; }
        IPlayerRepository PlayerRepository { get; }
        IRefereeRepository RefereeRepository { get; }
        IStatsRepository StatsRepository { get; }
        IArenaRepository ArenaRepository { get; }
        ITeamFirstLineupRepository TeamFirstLineupRepository { get; }
        ITeamLineupRepository TeamLineupRepository { get; }
        ITeamRepository TeamRepository { get; }
        ITeamScheduleActivityRepository TeamScheduleActivityRepository { get; }
        ITeamScheduleRepository TeamScheduleRepository { get; }
        IWorkoutRepository WorkoutRepository { get; }
        IWorkoutTypeRepository WorkoutTypeRepository { get; }
        INationalityRepository NationalityRepository { get; }
        Task<int> CommitAsync();
    }
}

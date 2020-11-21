using BasketUnit.WebAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class RepositoriesWrapper : IRepositoriesWrapper
    {
        private readonly MainDatabaseContext _context;
        private AppRoleRepository _appRoleRepository;
        private AppUserRepository _appUserRepository;
        private AppUserRoleRepository _appUserRoleRepository;
        private FunctionalityAppRoleRepository _functionalityAppRoleRepository;
        private FunctionalityRepository _functionalityRepository;
        private PersonRepository _personRepository;
        private GameRefereesRepository _gameRefereesRepository;
        private GameRepository _gameRepository;
        private GameTeamsRepository _gameTeamsRepository;
        private CoachRepository _coachRepository;
        private PlayerRepository _playerRepository;
        private RefereeRepository _refereeRepository;
        private StatsRepository _statsRepository;
        private ArenaRepository _arenaRepository;
        private TeamFirstLineupRepository _teamFirstLineupRepository;
        private TeamLineupRepository _teamLineupRepository;
        private TeamRepository _TeamRepository;
        private TeamScheduleActivityRepository _teamScheduleAcitivityRepository;
        private TeamScheduleRepository _teamScheduleRepository;
        private WorkoutRepository _workoutRepository;
        private WorkoutTypeRepository _workoutTypeRepository;
        private NationalityRepository _nationalityRepository;

        public RepositoriesWrapper(MainDatabaseContext context)
        {
            this._context = context;
        }
        public IAppRoleRepository AppRoleRepository => _appRoleRepository = _appRoleRepository ?? new AppRoleRepository(_context);
        public IAppUserRepository AppUserRepository => _appUserRepository = _appUserRepository ?? new AppUserRepository(_context);
        public IAppUserRoleRepository AppUserRoleRepository => _appUserRoleRepository = _appUserRoleRepository ?? new AppUserRoleRepository(_context);
        public IFunctionalityAppRoleRepository FunctionalityAppRoleRepository => _functionalityAppRoleRepository = _functionalityAppRoleRepository ?? new FunctionalityAppRoleRepository(_context);
        public IFunctionalityRepository FunctionalityRepository => _functionalityRepository = _functionalityRepository ?? new FunctionalityRepository(_context);
        public IPersonRepository PersonRepository => _personRepository = _personRepository ?? new PersonRepository(_context);
        public IGameRefereesRepository GameRefereesRepository => _gameRefereesRepository = _gameRefereesRepository ?? new GameRefereesRepository(_context);
        public IGameRepository GameRepository => _gameRepository = _gameRepository ?? new GameRepository(_context);
        public IGameTeamsRepository GameTeamsRepository => _gameTeamsRepository = _gameTeamsRepository ?? new GameTeamsRepository(_context);
        public ICoachRepository CoachRepository => _coachRepository = _coachRepository ?? new CoachRepository(_context);
        public IPlayerRepository PlayerRepository => _playerRepository = _playerRepository ?? new PlayerRepository(_context);
        public IRefereeRepository RefereeRepository => _refereeRepository = _refereeRepository ?? new RefereeRepository(_context);
        public IStatsRepository StatsRepository => _statsRepository = _statsRepository ?? new StatsRepository(_context);
        public IArenaRepository ArenaRepository => _arenaRepository = _arenaRepository ?? new ArenaRepository(_context);
        public ITeamFirstLineupRepository TeamFirstLineupRepository => _teamFirstLineupRepository = _teamFirstLineupRepository ?? new TeamFirstLineupRepository(_context);
        public ITeamLineupRepository TeamLineupRepository => _teamLineupRepository = _teamLineupRepository ?? new TeamLineupRepository(_context);
        public ITeamRepository TeamRepository => _TeamRepository = _TeamRepository ?? new TeamRepository(_context);
        public ITeamScheduleActivityRepository TeamScheduleActivityRepository => _teamScheduleAcitivityRepository = _teamScheduleAcitivityRepository ?? new TeamScheduleActivityRepository(_context);
        public ITeamScheduleRepository TeamScheduleRepository => _teamScheduleRepository = _teamScheduleRepository ?? new TeamScheduleRepository(_context);
        public IWorkoutRepository WorkoutRepository => _workoutRepository = _workoutRepository ?? new WorkoutRepository(_context);
        public IWorkoutTypeRepository WorkoutTypeRepository => _workoutTypeRepository = _workoutTypeRepository ?? new WorkoutTypeRepository(_context);
        public INationalityRepository NationalityRepository => _nationalityRepository = _nationalityRepository ?? new NationalityRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

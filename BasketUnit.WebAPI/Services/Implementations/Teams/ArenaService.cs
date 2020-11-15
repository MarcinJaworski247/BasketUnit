using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class ArenaService : IArenaService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public ArenaService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<SelectModelBinder<int>> GetArenasToLookup()
        {
            return RepositoriesWrapper.ArenaRepository.GetArenasToLookup();
        }
        public List<Arena> GetArenas()
        {
            return RepositoriesWrapper.ArenaRepository.GetArenas();
        }
        public Arena AddArena(AddArenaVM model)
        {
            return RepositoriesWrapper.ArenaRepository.AddArena(model);
        }
        public DetailsArenaVM SetArenaDetails(int arenaId)
        {
            return RepositoriesWrapper.ArenaRepository.SetArenaDetails(arenaId);
        }
        public EditArenaVM EditArena(EditArenaVM model)
        {
            return RepositoriesWrapper.ArenaRepository.EditArena(model);
        }
        public void DeleteArena(int arenaId)
        {
            RepositoriesWrapper.ArenaRepository.DeleteArena(arenaId);
        }
    }
}

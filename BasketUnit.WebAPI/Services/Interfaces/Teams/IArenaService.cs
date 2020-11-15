using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface IArenaService
    {
        List<SelectModelBinder<int>> GetArenasToLookup();
        List<Arena> GetArenas();
        Arena AddArena(AddArenaVM model);
        DetailsArenaVM SetArenaDetails(int arenaId);
        EditArenaVM EditArena(EditArenaVM model);
        void DeleteArena(int arenaId);
    }
}

using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface IGameService
    {
        void AddGame(AddGameVM model);
        List<ClosestGamesWidgetVM> GetClosestGamesToWidget();
    }
}

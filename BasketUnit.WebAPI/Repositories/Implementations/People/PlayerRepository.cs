using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Enums;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<Player> GetPlayers()
        {
            return MainDatabaseContext.Players.ToList();
        }
        public Player AddPlayer(AddPlayerVM model)
        {
            Player player = new Player
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                Position = (Position)model.PositionId,
                Number = model.Number,
                Avatar = model.Avatar,
                NationalityId = model.NationalityId
            };
            MainDatabaseContext.Players.Add(player);
            MainDatabaseContext.SaveChanges();

            return player;
        }
        public DetailsPlayerVM SetPlayerDetails(int playerId)
        {
            Player player = MainDatabaseContext.Players.Where(x => x.Id == playerId).FirstOrDefault();
            DetailsPlayerVM detailsPlayerVM = new DetailsPlayerVM
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                FullName = player.FirstName + " " + player.LastName,
                Avatar = player.Avatar,
                Position = player.Position.ToString(),
                Number = player.Number,
                BirthDate = player.BirthDate,
                NationalityId = player.NationalityId
            };
            return detailsPlayerVM;
        }
        public EditPlayerVM EditPlayer(EditPlayerVM model)
        {
            Player player = MainDatabaseContext.Players.Where(x => x.Id == model.Id).FirstOrDefault();

            player.FirstName = model.FirstName;
            player.LastName = model.LastName;
            player.Avatar = model.Avatar;
            player.Position = model.Position;
            player.BirthDate = model.BirthDate;
            player.Number = model.Number;
            player.NationalityId = model.NationalityId;

            MainDatabaseContext.Players.Update(player);
            MainDatabaseContext.SaveChanges();
            return model;
        }
        public void DeletePlayer(int playerId)
        {
            Player player = MainDatabaseContext.Players.Where(x => x.Id == playerId).FirstOrDefault();
            MainDatabaseContext.Players.Remove(player);
            MainDatabaseContext.SaveChanges();
        }
        public List<Player> GetFirstLineupPlayers()
        {
            List<Player> firstLineup = MainDatabaseContext.TeamFirstLineups.Where(x => x.TeamId == 1).Select(x => x.Player).ToList();
            return firstLineup;
        }
    }
}

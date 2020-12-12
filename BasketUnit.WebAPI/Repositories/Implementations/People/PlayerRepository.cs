using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Enums;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        public List<ListPlayersVM> GetPlayers()
        {
            List<ListPlayersVM> players = MainDatabaseContext.Players.Include(x => x.TeamLineup).Include(x => x.Stats).Include(x => x.Nationality).Include(x=> x.College).Select(x => new ListPlayersVM() {
                Id = x.Id,
                Avatar = x.Avatar,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FullName = x.FirstName +  " "  + x.LastName,
                BirthDate = x.BirthDate,
                PositionId = (int)x.Position,
                NationalityId = x.Nationality.Id,
                PlayerNumber = x.Number,
                TeamId = x.TeamLineup.FirstOrDefault().TeamId,
                Height = x.Height,
                Weight = x.Weight,
                College = x.College.City + " " + x.College.Name,
                CollegeId = x.CollegeId
            }).ToList();

            return players;
        }
        public List<ListPlayersVM> GetTeamPlayers()
        {
            List<ListPlayersVM> players = MainDatabaseContext.Players.Include(x => x.College).Include(x => x.Injuries).Include(x => x.TeamLineup).Include(x => x.Stats).Include(x => x.Nationality).Where(x => x.TeamLineup.FirstOrDefault().TeamId == 2).Select(x => new ListPlayersVM()
            {
                Id = x.Id,
                Avatar = x.Avatar,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FullName = x.FirstName + " " + x.LastName,
                BirthDate = x.BirthDate,
                PositionId = (int)x.Position,
                NationalityId = x.Nationality.Id,
                PlayerNumber = x.Number,
                Height = x.Height,
                Weight = x.Weight,
                College = x.College.Name,
                TeamId = x.TeamLineup.FirstOrDefault().TeamId,
                IsInjured = DateTime.Now < x.Injuries.FirstOrDefault().InjuredTo
            }).ToList();

            return players;
        }
        public Player AddPlayer(AddPlayerVM model)
        {
            Player player = new Player
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                Position = (Position)model.PositionId,
                Number = model.PlayerNumber,
                Avatar = model.Avatar,
                NationalityId = model.NationalityId,
                Height = model.Height,
                Weight = model.Weight,
                CollegeId = model.CollegeId
            };
            MainDatabaseContext.Players.Add(player);
            MainDatabaseContext.SaveChanges();

            if (model.TeamId.HasValue)
            {
                TeamLineup teamLineup = new TeamLineup
                {
                    TeamId = (int)model.TeamId,
                    PlayerId = player.Id
                };
                MainDatabaseContext.TeamLineups.Add(teamLineup);
                MainDatabaseContext.SaveChanges();
            }

            return player;
        }
        public DetailsPlayerVM SetPlayerDetails(int playerId)
        {
            DetailsPlayerVM data = MainDatabaseContext.Players.Include(x => x.College).Include(x => x.Injuries).Include(x => x.TeamLineup).ThenInclude(y => y.Team).Include(x => x.Nationality).Where(x => x.Id == playerId).Select(x => new DetailsPlayerVM()
            {
                Id = x.Id,
                FirstName = x.FirstName, 
                LastName = x.LastName,
                FullName = x.FirstName + " " + x.LastName,
                Avatar = Convert.ToBase64String(x.Avatar),
                Position = x.Position.ToString(),
                PlayerNumber = x.Number,
                BirthDate = x.BirthDate,
                NationalityId = x.NationalityId,
                Nationality = x.Nationality.Name,
                NationalityFlag = Convert.ToBase64String(x.Nationality.Flag),
                TeamId = x.TeamLineup.FirstOrDefault().TeamId,
                PositionId = (int)x.Position,
                Team = x.TeamLineup.FirstOrDefault().Team.City + " " + x.TeamLineup.FirstOrDefault().Team.Name,
                College = x.College.City + " " + x.College.Name,
                CollegeBadge = Convert.ToBase64String(x.College.Badge),
                CollegeId = x.CollegeId,
                Height = x.Height,
                Weight = x.Weight,
                //InjuredTo = (DateTime.Now < x.Injuries.FirstOrDefault().InjuredTo) ? x.Injuries.FirstOrDefault().InjuredTo : null
                InjuredTo = null,
                Injury = string.Empty,
                IsInjured = false
                
            }).FirstOrDefault();


            return data;
        }
        public EditPlayerVM EditPlayer(EditPlayerVM model)
        {
            Player player = MainDatabaseContext.Players.Where(x => x.Id == model.Id).FirstOrDefault();
            TeamLineup teamLineup = MainDatabaseContext.TeamLineups.Where(x => x.PlayerId == model.Id).FirstOrDefault();

            player.FirstName = model.FirstName;
            player.LastName = model.LastName;
            player.Avatar = model.Avatar;
            player.Position = (Position)model.PositionId;
            player.BirthDate = model.BirthDate;
            player.Number = model.PlayerNumber;
            player.NationalityId = model.NationalityId;
            player.Height = model.Height;
            player.Weight = model.Weight;
            player.CollegeId = model.CollegeId;

            MainDatabaseContext.Players.Update(player);
            MainDatabaseContext.SaveChanges();

            if(model.TeamId.HasValue)
            {
                teamLineup.TeamId = (int)model.TeamId;
                MainDatabaseContext.TeamLineups.Update(teamLineup);
                MainDatabaseContext.SaveChanges();
            }

            return model;
        }
        public void DeletePlayer(int playerId)
        {
            Player player = MainDatabaseContext.Players.Where(x => x.Id == playerId).FirstOrDefault();
            MainDatabaseContext.Players.Remove(player);
            MainDatabaseContext.SaveChanges();

            TeamLineup teamLineup = MainDatabaseContext.TeamLineups.Where(x => x.PlayerId == playerId).FirstOrDefault();
            if(teamLineup != null)
            {
                MainDatabaseContext.Remove(teamLineup);
                MainDatabaseContext.SaveChanges();
            }
        }
        public List<DetailsPlayerVM> GetFirstLineupPlayers()
        {
            List<DetailsPlayerVM> data = MainDatabaseContext.TeamFirstLineups.Include(x => x.Player).Where(x => x.TeamId == 2).Select(x => new DetailsPlayerVM()
            {
                FirstName = x.Player.FirstName + " " + x.Player.LastName,
                Position = x.Player.Position.ToString(),
                PositionId = (int)x.Player.Position,
                Avatar = Convert.ToBase64String(x.Player.Avatar)
            }).ToList();

            return data;
        }
        public List<PlayerInjury> GetPlayerInjuries(int playerId)
        {
            return MainDatabaseContext.PlayerInjuries.Where(x => x.PlayerId == playerId).ToList();
        }
        public void AddPlayerInjury(AddPlayerInjuryVM data)
        {
            PlayerInjury playerInjury = new PlayerInjury
            {
                PlayerId = data.PlayerId,
                InjuredTo = data.AddInjuredTo,
                Injury = data.AddInjury
            };
            MainDatabaseContext.PlayerInjuries.Add(playerInjury);
            MainDatabaseContext.SaveChanges();
        }
    }
}

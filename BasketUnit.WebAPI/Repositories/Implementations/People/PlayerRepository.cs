﻿using BasketUnit.WebAPI.Context;
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
            //List<Player> players = MainDatabaseContext.Players.ToList();

            //List<TeamLineup> teamLineups = MainDatabaseContext.TeamLineups.ToList();


            //// to fix!! change to left join
            //List<ListPlayersVM> result = players.Join(teamLineups, x => x.Id, y => y.PlayerId, (x, y) => new ListPlayersVM()
            //{
            //    Id = x.Id,
            //    Avatar = x.Avatar,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    FullName = x.FirstName + " " + x.LastName,
            //    BirthDate = x.BirthDate,
            //    PositionId = (int)x.Position,
            //    NationalityId = x.NationalityId,
            //    PlayerNumber = x.Number,
            //    TeamId = y.TeamId
            //}).ToList();


            List<ListPlayersVM> players = MainDatabaseContext.Players.Include(x => x.TeamLineup).Include(x => x.Stats).Include(x => x.Nationality).Select(x => new ListPlayersVM() {
                Id = x.Id,
                Avatar = x.Avatar,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FullName = x.FirstName +  " "  + x.LastName,
                BirthDate = x.BirthDate,
                PositionId = (int)x.Position,
                NationalityId = x.Nationality.Id,
                PlayerNumber = x.Number,
                TeamId = x.TeamLineup.FirstOrDefault().TeamId
            }).ToList();

            return players;
        }
        public List<ListPlayersVM> GetTeamPlayers()
        {
            List<ListPlayersVM> players = MainDatabaseContext.Players.Include(x => x.TeamLineup).Include(x => x.Stats).Include(x => x.Nationality).Where(x => x.TeamLineup.FirstOrDefault().TeamId == 2).Select(x => new ListPlayersVM()
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
                TeamId = x.TeamLineup.FirstOrDefault().TeamId
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
                NationalityId = model.NationalityId
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
            //Player player = MainDatabaseContext.Players.Where(x => x.Id == playerId).FirstOrDefault();
            //int? playersTeamId = MainDatabaseContext.TeamLineups.Where(x => x.PlayerId == playerId).Select(x => x.TeamId).FirstOrDefault();
            //string team = MainDatabaseContext.Teams.Where(x => x.Id == (int)playersTeamId).Select(x => x.City + " " + x.Name).FirstOrDefault();
            //string nationality = MainDatabaseContext.Nationalities.Where(x => x.Id == player.NationalityId).Select(x => x.Name).FirstOrDefault();
            //DetailsPlayerVM detailsPlayerVM = new DetailsPlayerVM
            //{
            //    Id = player.Id,
            //    FirstName = player.FirstName,
            //    LastName = player.LastName,
            //    FullName = player.FirstName + " " + player.LastName,
            //    Avatar = Convert.ToBase64String(player.Avatar),
            //    Position = player.Position.ToString(),
            //    PlayerNumber = player.Number,
            //    BirthDate = player.BirthDate,
            //    NationalityId = player.NationalityId,
            //    TeamId = playersTeamId,
            //    PositionId = (int)player.Position,
            //    Nationality = nationality,
            //    Team = team
            //};

            DetailsPlayerVM data = MainDatabaseContext.Players.Include(x => x.TeamLineup).ThenInclude(y => y.Team).Include(x => x.Nationality).Where(x => x.Id == playerId).Select(x => new DetailsPlayerVM()
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
                TeamId = x.TeamLineup.FirstOrDefault().TeamId,
                PositionId = (int)x.Position,
                Team = x.TeamLineup.FirstOrDefault().Team.City + " " + x.TeamLineup.FirstOrDefault().Team.Name
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
            // to do team id parameter
            //List<DetailsPlayerVM> firstLineup = new List<DetailsPlayerVM>();
            //List<int> teamFirstLineups = MainDatabaseContext.TeamFirstLineups.Where(x => x.TeamId == 1).Select(x => x.PlayerId).ToList();
            //MainDatabaseContext.Players.Where(x => teamFirstLineups.Contains(x.Id)).Select(x => new DetailsPlayerVM() {
            //    FullName = x.FirstName + " " + x.LastName,
            //    Position = x.Position.ToString(),
            //    PlayerNumber = x.Number,
            //    Avatar = Convert.ToBase64String(x.Avatar)
            //}).ToList();
            //List<Player> players = MainDatabaseContext.Players.ToList();
            //foreach(var item in players)
            //{
            //    foreach(var x in teamFirstLineups)
            //    {
            //        if(item.Id == x)
            //        {
            //            DetailsPlayerVM dp = new DetailsPlayerVM
            //            {
            //                FullName = item.FirstName + " " + item.LastName,
            //                Position = item.Position.ToString(),
            //                PlayerNumber = item.Number,
            //                Avatar = Convert.ToBase64String(item.Avatar)
            //            };
            //            firstLineup.Add(dp);
            //        }
            //    }
            //}

            List<DetailsPlayerVM> data = MainDatabaseContext.TeamFirstLineups.Include(x => x.Player).Where(x => x.TeamId == 2).Select(x => new DetailsPlayerVM()
            {
                FirstName = x.Player.FirstName + " " + x.Player.LastName,
                Position = x.Player.Position.ToString(),
                PositionId = (int)x.Player.Position,
                Avatar = Convert.ToBase64String(x.Player.Avatar)
            }).ToList();

            return data;
        }
    }
}

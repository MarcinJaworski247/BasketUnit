using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Services;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class ArenaRepository : Repository<Arena>, IArenaRepository
    {
        public ArenaRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<SelectModelBinder<int>> GetArenasToLookup()
        {
            List<Arena> arenas = MainDatabaseContext.Arenas.ToList();
            List<SelectModelBinder<int>> result = arenas.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.Name
            }).ToList();
            return result;
        }
        public List<Arena> GetArenas()
        {
            return MainDatabaseContext.Arenas.ToList();
        }
        public Arena AddArena(AddArenaVM model)
        {
            Arena arena = new Arena
            {
                Name = model.Name,
                Capacity = model.Capacity,
                Address = model.Address
            };
            MainDatabaseContext.Arenas.Add(arena);
            MainDatabaseContext.SaveChanges();

            return arena;
        }
        public DetailsArenaVM SetArenaDetails(int arenaId)
        {
            Arena arena = MainDatabaseContext.Arenas.Where(x => x.Id == arenaId).FirstOrDefault();
            DetailsArenaVM detailsArenaVM = new DetailsArenaVM
            {
                Id = arena.Id,
                Name = arena.Name,
                Capacity = arena.Capacity,
                Address = arena.Address
            };
            return detailsArenaVM;
        }
        public EditArenaVM EditArena(EditArenaVM model)
        {
            Arena arena = MainDatabaseContext.Arenas.Where(x => x.Id == model.Id).FirstOrDefault();

            arena.Name = model.Name;
            arena.Capacity = model.Capacity;
            arena.Address = model.Address;

            MainDatabaseContext.Arenas.Update(arena);
            MainDatabaseContext.SaveChanges();
            return model;
        }
        public void DeleteArena(int arenaId)
        {
            Arena arena = MainDatabaseContext.Arenas.Where(x => x.Id == arenaId).FirstOrDefault();
            // to do if arena == null
            MainDatabaseContext.Arenas.Remove(arena);
            MainDatabaseContext.SaveChanges();
        }
    }
}

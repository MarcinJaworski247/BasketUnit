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
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}

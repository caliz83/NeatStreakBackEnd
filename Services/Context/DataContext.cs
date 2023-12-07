using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeatStreakBackEnd.Models;
using Microsoft.EntityFrameworkCore; 

namespace NeatStreakBackEnd.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> UserInfo { get; set; }

        public DbSet<ChoreItemModel> ChoreInfo { get; set; }
        
        public DataContext(DbContextOptions options) : base(options) {

        }

        //function to create the tables themselves
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    
}
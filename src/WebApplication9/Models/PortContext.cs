using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.Data.Entity;
//using Microsoft.Data.Entity.Infrastructure;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using WebApplication9.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

namespace WebApplication9.Models
{
    public class PortContext : DbContext
    {
        public PortContext()
        {
            Database.EnsureCreated();
        }
        //public PortContext(DbContextOptions<PortContext> options) : base(options){ }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            var connString = Startup.Configuration["Data:PortContextConnection"];
            option.UseSqlServer(connString);
            base.OnConfiguring(option);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thumanya.DataAccessLayer.DatabaseEntities;

namespace Thumanya.DataAccessLayer
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext(DbContextOptions<CMSDbContext> options)
           : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Auther> Authers { get; set; }
        public DbSet<ChannelType> ChannelTypes { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CMSDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
            // Apply all configurations from the assembly
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PogoWebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoWebCore
{
    public class PogoContext: DbContext
    {
        public DbSet<LandmarkType> LandmarkTypes;
        public DbSet<Landmark> Landmarks;

        public PogoContext(DbContextOptions<PogoContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LandmarkType>();
            modelBuilder.Entity<Landmark>()
                .HasOne<LandmarkType>()
                .WithMany().HasForeignKey(l => l.TypeId)
                .IsRequired();
            /*
            modelBuilder.Entity<LandmarkType>().HasData(
                new LandmarkType { Id =,Name = "", ImageFileName="" }
                );
            modelBuilder.Entity<Landmark>().HasData(
                new Landmark { Id = , Lattitude = , Longitude = , Name = "", TypeId = }
                );
            */
            base.OnModelCreating(modelBuilder);
        }
    }
}

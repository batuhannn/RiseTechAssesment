using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class GuideDbContext : DbContext
    {
        public GuideDbContext(DbContextOptions<GuideDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<CommunicationInfo> CommunicationInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

 

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne<CommunicationInfo>(x => x.CommunicationInfo).WithOne(c => c.User).HasForeignKey<CommunicationInfo>(c => c.UserId).IsRequired();
            });



        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartReward.Models
{
    public class SmartRewardEntities : DbContext
    {
        public SmartRewardEntities()
            : base("SmartRewardEntities")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }

         // Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>().HasRequired(n => n.Sender).WithMany(u => u.SendedNotifications).WillCascadeOnDelete(false);
            modelBuilder.Entity<Notification>().HasRequired(n => n.Receiver).WithMany(u => u.ReceivedNotifications).WillCascadeOnDelete(false);
        }
    }
}
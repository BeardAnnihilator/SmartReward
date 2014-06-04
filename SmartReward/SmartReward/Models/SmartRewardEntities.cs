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

         // Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
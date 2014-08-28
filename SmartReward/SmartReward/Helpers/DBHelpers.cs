using SmartReward.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartReward.Helpers
{
    public static class DBHelpers
    {
        #region get user
        public static User GetSmartRewardUser(this System.Security.Principal.IPrincipal user, SmartRewardEntities db)
        {
            if (user == null || String.IsNullOrEmpty(user.Identity.Name))
            {
                return null;
            }
            try
            {
                return db.Users.SingleOrDefault(u => u.Email == user.Identity.Name);
            }
            catch
            {
                return null;
            }
        }

        public static User GetSmartRewardUser(string userEmail, SmartRewardEntities db)
        {
            if (String.IsNullOrEmpty(userEmail))
            {
                return null;
            }
            try
            {
                return db.Users.SingleOrDefault(u => u.Email == userEmail);
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
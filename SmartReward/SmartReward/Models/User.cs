using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartReward.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Email { get; set; }

        virtual public List<User> Parents { get; set; }
        virtual public List<User> Childs { get; set; }
        virtual public List<Notification> ReceivedNotifications { get; set; }
        virtual public List<Notification> SendedNotifications { get; set; }

        public bool SendBindingChildRequest(User target, SmartRewardEntities db)
        {
            if (!Childs.Contains(target)
                && SendedNotifications.Where(n =>
                    n.Receiver.UserId.Equals(target.UserId)
                    && n.TypeNotificationCode == "BINDING_CHILD?"
                    && n.Response == null)
                    .ToList().Count == 0)
            {
                this.SendedNotifications.Add(new Notification { Sender = this, Receiver = target, TypeNotificationCode = "BINDING_CHILD?" });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SendBindingParentRequest(User target, SmartRewardEntities db)
        {
            if (!Parents.Contains(target)
                && SendedNotifications.Where(n =>
                    n.Receiver.UserId.Equals(target.UserId)
                    && n.TypeNotificationCode == "BINDING_PARENT?"
                    && n.Response == null)
                    .ToList().Count == 0)
            {
                this.SendedNotifications.Add(new Notification { Sender = this, Receiver = target, TypeNotificationCode = "BINDING_PARENT?" });
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
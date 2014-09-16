using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartReward.Models
{
     [Table("Notifications")]
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string TypeNotificationCode { get; set; }
        public bool? Value { get; set; }
        public bool Seen { get; set; }
        virtual public Notification Query { get; set; }
        virtual public Notification Response { get; set; }
        virtual public User Sender { get; set; }
        virtual public User Receiver { get; set; }

    }
}
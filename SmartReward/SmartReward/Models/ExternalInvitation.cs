using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartReward.Models
{
    [Table("ExternalInvitations")]
    public class ExternalInvitation
    {
        [Key]
        public int Id { get; set; }
        public string TypeNotificationCode { get; set; }
        public string EmailTarget { get; set; }
        virtual public User Sender { get; set; }
    }
}
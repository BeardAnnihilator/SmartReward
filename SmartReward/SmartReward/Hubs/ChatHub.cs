using Microsoft.AspNet.SignalR;
using SmartReward.Models;
using System.Threading.Tasks;
using System.Linq;

namespace SmartReward
{
    [Authorize]
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        /// <summary>
        /// This method sends notifications to a specific user identified by its Context.User.Identity.Name (email when I write these lines)
        /// </summary>
        /// <param name="who">Context.User.Identity.Name of the target</param>
        /// <param name="message"></param>
        public void SendChatMessage(string who, string message)
        {
            string name = Context.User.Identity.Name;

            Clients.Group(who).addChatMessage(name + ": " + message);
        }

        /// <summary>
        /// Used tp sends the number of un-oppened notification to the client
        /// </summary>
        /// <param name="who"></param>
        /// <param name="nbrNotif"></param>
        public void Notify(string who, int nbrNotif)
        {
            Clients.Group(who).Notify(nbrNotif);
        }

        /// <summary>
        /// This method is called when the client connects to the hub (via javascript)
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            Groups.Add(Context.ConnectionId, name);

            SmartRewardEntities db = new SmartRewardEntities();
            User user = db.Users.Where(u => u.Email.Equals(name)).FirstOrDefault();
            if (user != null)
            {
                int unseenNotif = user.ReceivedNotifications.Where(n => !n.Seen).Count();
                if (unseenNotif > 0)
                    Notify(name, unseenNotif);
            }
            return base.OnConnected();
        }
    }
}
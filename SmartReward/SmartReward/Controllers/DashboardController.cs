using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartReward.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            //IHubContext hub =  GlobalHost.ConnectionManager.GetHubContext<ChatHub>();

            //hub.Clients.Group("a@yopmail.com").addChatMessage("coucou");
            return View();
        }
    }
}

using System.Web.Mvc;

namespace SmartReward.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Dashboard");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

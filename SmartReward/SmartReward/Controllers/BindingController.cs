using SmartReward.Filters;
using SmartReward.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartReward.Helpers;
using SmartReward.Models;
using PagedList;

namespace SmartReward.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class BindingController : Controller
    {
        private SmartRewardEntities db = new SmartRewardEntities();

        public ActionResult AutoComplete(string term)
        {
            var model = db.Users
                .Where(u => u.Email.StartsWith(term))
                .Take(5)
                .Select(r => new { label = r.Email });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Binding/

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            
            var model = new BindingViewModel();
            var user = User.GetSmartRewardUser(db);
            model.result = db.Users
                .Where(u => u.UserId != user.UserId && (searchTerm == null || u.Email.Contains(searchTerm)))
                .OrderBy(u => u.UserId)
                .ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Members", model);
            }

            return View(model);
        }

        public ActionResult BindingChild(int targetId)
        {
            var user = User.GetSmartRewardUser(db);
            var target = db.Users.Find(targetId);

            bool res = user.SendBindingChildRequest(target, db);

            if (Request.IsAjaxRequest())
            {
                return null;
            }
            return RedirectToAction("Index");
        }
    }
}
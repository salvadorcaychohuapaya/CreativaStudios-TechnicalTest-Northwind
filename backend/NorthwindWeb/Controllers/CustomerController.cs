using NorthwindWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly NorthwindRepository _repository = new NorthwindRepository();

        public ActionResult CustomersByCountry()
        {
            return View();
        }

        public ActionResult CustomerOrdersInformation(string id)
        {
            ViewBag.CustomerId = id;
            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var url = filterContext.HttpContext.Request.RawUrl;
            var ip = filterContext.HttpContext.Request.UserHostAddress;

            _repository.InsertWebTracker(url, ip);
        }
    }
}
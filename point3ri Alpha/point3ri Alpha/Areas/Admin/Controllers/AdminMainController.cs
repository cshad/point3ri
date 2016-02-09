using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace point3ri_Alpha_0._51.Areas.Admin.Controllers
{
    public class AdminMainController : Controller
    {
        // GET: Admin/AdminMain
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
using Academic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academic.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherRepository _repository = new TeacherRepository();

        public ActionResult Index()
        {
            var teachers = _repository.GetAll();
            return Json(teachers, JsonRequestBehavior.AllowGet);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
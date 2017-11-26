using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssesmentApplication.Models.ViewModel;
using AssesmentApplication.Models.DBModel;
using AssesmentApplication.Models.EntityManager;

namespace AssesmentApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        [HttpGet]
        public ActionResult MainAction()
        {
            DuesMemberEntityManager mgr = new DuesMemberEntityManager();
            ReportViewModel model = mgr.getModelToShowOnHomePage();
            return View(model);
        }
        [HttpPost]
        public ActionResult MainAction(ReportViewModel model, string action)
        {
            DuesMemberEntityManager mgr = new DuesMemberEntityManager();
            mgr.getModelToShowOnHomePage();
            


            return View();
        }

        [HttpGet]
        public ActionResult ReportGenerate(ReportViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult ReportGenerate(ReportViewModel model, string action)
        {
            switch (action)
            {
                case "GenerateReport":
                    return RedirectToAction("ReportGenerate", "Home");

                case "Clear":
                    break;


            }
            return View(model);
        }

    }
}
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
            Session.Clear();
            ModelState.Clear();
            DuesMemberEntityManager mgr = new DuesMemberEntityManager();
            ReportViewModel model = mgr.getModelToShowOnHomePage();
            return View(model);
        }
       
        [HttpGet]
        public ActionResult ReportGenerate()
        {
            ReportViewModel mdl = (ReportViewModel)TempData["InputDataModel"];
            DuesMemberEntityManager mgr = new DuesMemberEntityManager();
            ReportViewModel modelView = new ReportViewModel();
            if (!(mdl.AgeGroup1[1].Equals("") || mdl.AgeGroup2[1].Equals("") || mdl.AgeGroup3[1].Equals("")) && !(mdl.ListOfSelectedStates ==null))
            {
                modelView = mgr.getModelToShowReportAsPerAgeGroupAndSelectedStates(mdl);
            }
            else if (! (mdl.ListOfSelectedStates == null))
            {
                modelView = mgr.getModelToShowReportAsPerSelectedStates(mdl);
            }
            else if ( !(mdl.AgeGroup1[1].Equals("") || mdl.AgeGroup2[1].Equals("") || mdl.AgeGroup3[1].Equals("")))
            {
                modelView = mgr.getModelToShowReportAsPerAgeGroup(mdl);
            }
                return View(modelView);
        }

        [HttpPost]
        public ActionResult ReportGenerate(ReportViewModel model, string action)
        {
            ReportViewModel mdl = new ReportViewModel();
            mdl.AgeGroup1 = model.AgeGroup1;
            mdl.AgeGroup2 = model.AgeGroup2;
            mdl.AgeGroup3 = model.AgeGroup3;
            mdl.ListOfSelectedStates = model.ListOfSelectedStates;

            TempData["InputDataModel"] = mdl;

            switch (action)
            {
                case "GenerateReport":
                    return RedirectToAction("ReportGenerate", "Home");
                case "Reset":
                 
                    return RedirectToAction("MainAction","Home");
            }
            return View(model);
        }

    }
}
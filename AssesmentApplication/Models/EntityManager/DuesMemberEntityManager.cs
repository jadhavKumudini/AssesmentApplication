using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssesmentApplication.Models.ViewModel;
using AssesmentApplication.Models.DBModel;

namespace AssesmentApplication.Models.EntityManager
{
    public class DuesMemberEntityManager
    {

        public ReportViewModel getModelToShowOnHomePage()
        {
            List<string> statesList = getStatesList();

            ReportViewModel mdl = new ReportViewModel();
            mdl.ListOfStatesToShow = statesList;

            return mdl;
        }

        public List<string> getStatesList()
        {
            using(masterEntities db = new masterEntities())
            {
                var results = db.Table1.Select(c => c.DuesMembState).Distinct().ToList();
                return results;
            }
        }

    }
}
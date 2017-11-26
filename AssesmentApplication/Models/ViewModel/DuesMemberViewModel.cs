using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssesmentApplication.Models.DBModel;
using AssesmentApplication.Models.EntityManager;

namespace AssesmentApplication.Models.ViewModel
{
    public class DuesMemberViewModel
    {
        public List<DuesMember> listOfDuesMemberForAgeGroup1;
        public List<DuesMember> listOfDuesMemberForAgeGroup2;
        public List<DuesMember> listOfDuesMemberForAgeGroup3;
        public List<DuesMember> listOfDuesMemberForMultipleStates;

        public DuesMemberViewModel() { }

        
    }
}
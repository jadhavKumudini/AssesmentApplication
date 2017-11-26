using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AssesmentApplication.Models.ViewModel
{
    public class ReportViewModel
    {
        public List<DuesMember> ListDuesMemberOfGroup1 { get; set; }
        public List<DuesMember> ListDuesMemberOfGroup2 { get; set; }
        public List<DuesMember> ListDuesMemberOfGroup3 { get; set; }

        public List<DuesMember> ListDuesMemberOfMultipleCity { get; set; }
        public List<string> ListOfSelectedStates { get; set; }

        [Display(Name= "Select States")]
        public List<string> ListOfStatesToShow { get; set; }

        [Display(Name = "Enter Lower and higher limits for Age Group1")]
        public List<string> AgeGroup1 { get; set; }
        [Display(Name = "Enter Lower and higher limits for Age Group2")]
        public List<string> AgeGroup2 { get; set; }
        [Display(Name = "Enter Lower and higher limits for Age Group3")]
        public List<string> AgeGroup3 { get; set; }

        public string selectedSingleState { get; set; }

    }
}
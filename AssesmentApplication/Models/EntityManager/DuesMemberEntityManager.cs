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
            using (masterEntities db = new masterEntities())
            {
                var results = db.Table1.Select(c => c.DuesMembState).Distinct().ToList();
                return results;
            }
        }

        public ReportViewModel getModelToShowReportAsPerAgeGroup(ReportViewModel mdl)
        {
            ReportViewModel newmodel = new ReportViewModel();

            newmodel.labelForGroup1Ages = "Age Group From" + " " + mdl.AgeGroup1[0] + " to " + mdl.AgeGroup1[1];
            newmodel.labelForGroup2Ages = "Age Group From" + " " + mdl.AgeGroup2[0] + " to " + mdl.AgeGroup2[1];
            newmodel.labelForGroup3Ages = "Age Group From" + " " + mdl.AgeGroup3[0] + " to " + mdl.AgeGroup3[1];

            newmodel.ListDuesMemberOfGroup1 = getListOfDuesMemeberUnderGroup(mdl.AgeGroup1);
            newmodel.ListDuesMemberOfGroup2 = getListOfDuesMemeberUnderGroup(mdl.AgeGroup2);
            newmodel.ListDuesMemberOfGroup3 = getListOfDuesMemeberUnderGroup(mdl.AgeGroup3);
            return newmodel;
        }

        internal ReportViewModel getModelToShowReportAsPerAgeGroupAndSelectedStates(ReportViewModel mdl)
        {
            ReportViewModel model1 = getModelToShowReportAsPerAgeGroup(mdl);
            ReportViewModel model2 = getModelToShowReportAsPerSelectedStates(mdl);
            model1.ListDuesMemberOfMultipleCity = model2.ListDuesMemberOfMultipleCity;
            model1.labelForStatesData = model2.labelForStatesData;
            return model1;
        }

        internal ReportViewModel getModelToShowReportAsPerSelectedStates(ReportViewModel mdl)
        {
            ReportViewModel newmodel = new ReportViewModel();
            List<string> states = mdl.ListOfSelectedStates;
            string label = "Report for selected states ";
            foreach(string s in states)
            {
                if (states.Last().Equals(s))
                {
                    label = label + s;
                }
                else
                {
                    label = label + s + ",";
                }
            }
            newmodel.labelForStatesData = label;
            newmodel.ListDuesMemberOfMultipleCity = getListOfDuesMemeberUnderSelectedStates(states);

            return newmodel;
        }

        public List<string> getInBetweenYears(string minyear, string maxyear)
        {
            List<string> years = new List<string>();
            int max = Convert.ToInt32(maxyear);
            int min = Convert.ToInt32(minyear);
            int len = max - min;
            for(int i =0; i<=len; i++)
            {
                years.Add(min.ToString());
                min = min + 1;
            }
            return years;
        }

        public List<DuesMember> getListOfDuesMemeberUnderGroup(List<string> ageGroup)
        {
            int lowerAge = Convert.ToInt32(ageGroup[0].Trim());
            int upperAge = Convert.ToInt32(ageGroup[1].Trim());
            DuesMember member = new DuesMember();
            string birthYrMin = member.getBirthYear(lowerAge);
            string birthYrMax = member.getBirthYear(upperAge);

            List<string> years = getInBetweenYears(birthYrMax, birthYrMin);
            List<DuesMember> members = new List<DuesMember>();
            using (masterEntities db = new masterEntities())
            {
               
                foreach(string yr in years)
                {
                   var results = db.Table1.Where(p => (p.DuesMembBirthDate.StartsWith(yr))).Select(p => new DuesMember
                    {
                        DuesMemberFirstName = p.DuesMembFirstName,
                        DuesMemberLastName = p.DuesMembLastName,
                        DuesMemberAddress1 = p.DuesMembAddress1,
                        DuesMemberAddress2 = p.DuesMembAddress2,
                        DuesMemberCity = p.DuesMembCity,
                        DuesMemberState = p.DuesMembState,
                        DuesMemberZipCode = p.DuesMembZipCode,
                        DuesMemberEmailAddress = p.DuesMembEmailAddress,
                        DuesMemberBirthDate = p.DuesMembBirthDate,
                        DuesMemberPhone = p.DuesMembPhone,
                        DuesMemberSSN = p.DuesMembSSN

                    }).ToList<DuesMember>();

                    members.AddRange(results);
                }
            }
            List<DuesMember> newMembers = new List<DuesMember>();
            foreach (DuesMember m in members)
            {
                m.MailingAddress = m.getMailingAddressDuesMember(m.DuesMemberAddress1, m.DuesMemberAddress2, m.DuesMemberCity, m.DuesMemberState, m.DuesMemberZipCode);
                m.Age = m.getAge(m.DuesMemberBirthDate);
                if((Convert.ToInt32(m.Age.Trim()) >= lowerAge) && (Convert.ToInt32(m.Age.Trim())<=upperAge) )
                {
                    newMembers.Add(m);
                }
            }
            return newMembers;
        }

        public List<DuesMember> getListOfDuesMemeberUnderSelectedStates(List<string> states)
        {
            List<DuesMember> members = new List<DuesMember>();
            using (masterEntities db = new masterEntities())
            {

                foreach (string state in states)
                {
                    var results = db.Table1.Where(p => (p.DuesMembState.Equals(state.Trim()))).Select(p => new DuesMember
                    {
                        DuesMemberFirstName = p.DuesMembFirstName,
                        DuesMemberLastName = p.DuesMembLastName,
                        DuesMemberAddress1 = p.DuesMembAddress1,
                        DuesMemberAddress2 = p.DuesMembAddress2,
                        DuesMemberCity = p.DuesMembCity,
                        DuesMemberState = p.DuesMembState,
                        DuesMemberZipCode = p.DuesMembZipCode,
                        DuesMemberEmailAddress = p.DuesMembEmailAddress,
                        DuesMemberBirthDate = p.DuesMembBirthDate,
                        DuesMemberPhone = p.DuesMembPhone,
                        DuesMemberSSN = p.DuesMembSSN
                    }).ToList<DuesMember>();

                    members.AddRange(results);
                }
            }
            foreach (DuesMember m in members)
            {
                m.MailingAddress = m.getMailingAddressDuesMember(m.DuesMemberAddress1, m.DuesMemberAddress2, m.DuesMemberCity, m.DuesMemberState, m.DuesMemberZipCode);               
            }
            return members;
        }
    }
}

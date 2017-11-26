using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AssesmentApplication.Models.ViewModel
{
    public class DuesMember
    {
        [Key]
        public string DuesMemberSSN { get; set; } 
        public string DuesMemberTempPensionNo{ get; set; }
        public string DuesMemberPermPensionNo { get; set; }
        public string DuesMemberStartDate { get; set; }
        public string DuesMemberBillStatus { get; set; }
        public string DuesMemberEndDate { get; set; }
        public string DuesMemberLastName { get; set; }
        public string DuesMemberFirstName { get; set; }
        public string DuesMemberAddress1 { get; set; }
        public string DuesMemberAddress2 { get; set; }
        public string DuesMemberCity { get; set; }
        public string DuesMemberState { get; set; }
        public string DuesMemberZipCode { get; set; }
        public string DuesMemberPhone { get; set; }
        public string DuesMemberEmailAddress { get; set; }
        public string DuesMemberDateEntered { get; set; }
        public string DuesMemberBirthDate { get; set; }
        public string DuesMemberRetirementDate { get; set; }
        public string DuesMemberBenefitDate { get; set; }
        public string DuesMemberDeathDate { get; set; }
        public string DuesMemberSpouseLastName { get; set; }
        public string DuesMemberSpouseFirstName { get; set; }
        public string DuesMemberMarriageDate { get; set; }

        public string MailingAddress { get; set; }
        public string Age { get; set; }

        public DuesMember(string duesMemberSSN, string duesMemberTempPensionNo, string duesMemberPermPensionNo, string duesMemberStartDate, string duesMemberBillStatus, string duesMemberEndDate, string duesMemberLastName, string duesMemberFirstName, string duesMemberAddress1, string duesMemberAddress2, string duesMemberCity, string duesMemberState, string duesMemberZipCode, string duesMemberPhone, string duesMemberEmailAddress, string duesMemberDateEntered, string duesMemberBirthDate, string duesMemberRetirementDate, string duesMemberBenefitDate, string duesMemberDeathDate, string duesMemberSpouseLastName, string duesMemberSpouseFirstName, string duesMemberMarriageDate)
        {
            DuesMemberSSN = duesMemberSSN;
            DuesMemberTempPensionNo = duesMemberTempPensionNo;
            DuesMemberPermPensionNo = duesMemberPermPensionNo;
            DuesMemberStartDate = duesMemberStartDate;
            DuesMemberBillStatus = duesMemberBillStatus;
            DuesMemberEndDate = duesMemberEndDate;
            DuesMemberLastName = duesMemberLastName;
            DuesMemberFirstName = duesMemberFirstName;
            DuesMemberAddress1 = duesMemberAddress1;
            DuesMemberAddress2 = duesMemberAddress2;
            DuesMemberCity = duesMemberCity;
            DuesMemberState = duesMemberState;
            DuesMemberZipCode = duesMemberZipCode;
            DuesMemberPhone = duesMemberPhone;
            DuesMemberEmailAddress = duesMemberEmailAddress;
            DuesMemberDateEntered = duesMemberDateEntered;
            DuesMemberBirthDate = duesMemberBirthDate;
            DuesMemberRetirementDate = duesMemberRetirementDate;
            DuesMemberBenefitDate = duesMemberBenefitDate;
            DuesMemberDeathDate = duesMemberDeathDate;
            DuesMemberSpouseLastName = duesMemberSpouseLastName;
            DuesMemberSpouseFirstName = duesMemberSpouseFirstName;
            DuesMemberMarriageDate = duesMemberMarriageDate;
        }

        public DuesMember(string duesMemberLastName, string duesMemberFirstName, string duesMemberAddress1, string duesMemberAddress2, string duesMemberCity, string duesMemberState, string duesMemberZipCode, string duesMemberEmailAddress, string duesMemberBirthDate)
        {
            DuesMemberLastName = duesMemberLastName;
            DuesMemberFirstName = duesMemberFirstName;
            DuesMemberAddress1 = duesMemberAddress1;
            DuesMemberAddress2 = duesMemberAddress2;
            DuesMemberCity = duesMemberCity;
            DuesMemberState = duesMemberState;
            DuesMemberZipCode = duesMemberZipCode;
            DuesMemberEmailAddress = duesMemberEmailAddress;
            DuesMemberBirthDate = duesMemberBirthDate;
        }

        public DuesMember(string duesMemberLastName, string duesMemberFirstName, string duesMemberEmailAddress, string mailingAddress, string age)
        {
            DuesMemberLastName = duesMemberLastName;
            DuesMemberFirstName = duesMemberFirstName;
            DuesMemberEmailAddress = duesMemberEmailAddress;
            MailingAddress = mailingAddress;
            Age = age;
        }

        public string getMailingAddressDuesMember(string address1, string city, string state, string zip)
        {
            return (address1 + " " + city + ", " + state + "," + zip);
        }

        public string getAge(string birthDate)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(birthDate);
            int age = (now - dob) / 10000;
            return age.ToString();
        }
        
    }
}
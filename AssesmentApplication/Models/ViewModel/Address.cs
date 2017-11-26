using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssesmentApplication.Models.ViewModel
{
    public class Address
    {
        public string DuesMemberAddress1 { get; set; }
        public string DuesMemberAddress2 { get; set; }
        public string DuesMemberCity { get; set; }
        public string DuesMemberState { get; set; }
        public string DuesMemberZipCode { get; set; }

        public string MailingAddress { get; set; }

        public Address(string duesMemberAddress1, string duesMemberAddress2, string duesMemberCity, string duesMemberState, string duesMemberZipCode)
        {
            DuesMemberAddress1 = duesMemberAddress1;
            DuesMemberAddress2 = duesMemberAddress2;
            DuesMemberCity = duesMemberCity;
            DuesMemberState = duesMemberState;
            DuesMemberZipCode = duesMemberZipCode;
        }

        public string getMailingAddressDuesMember (){
            return (DuesMemberAddress1 + " " + DuesMemberCity + ", " + DuesMemberState + "," + DuesMemberZipCode);
        }

    }
}
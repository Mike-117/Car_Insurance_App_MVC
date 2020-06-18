using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceAppMVC.ViewModels
{
    public class ClientVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Email { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public Nullable<int> CarYear { get; set; }
        public Nullable<bool> DUI { get; set; }
        public Nullable<int> SpeedingTickets { get; set; }
        public Nullable<bool> FullCoverage { get; set; }
        public Nullable<int> Quote { get; set; }
    }
}
using CarInsuranceAppMVC.Models;
using CarInsuranceAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                var clients = db.Clients;
                var clientsVm = new List<ClientVM>();
                foreach (var client in clients)
                {
                    var clientVm = new ClientVM();
                    clientVm.Id = client.Id;
                    clientVm.FirstName = client.FirstName;
                    clientVm.LastName = client.LastName;
                    //clientVm.DateOfBirth = client.DateOfBirth;
                    clientVm.Email = client.Email;
                    //clientVm.CarMake = client.CarMake;
                    //clientVm.CarModel = client.CarModel;
                    //clientVm.CarYear = client.CarYear;
                    //clientVm.DUI = client.DUI;
                    //clientVm.SpeedingTickets = client.SpeedingTickets;
                    //clientVm.FullCoverage = client.FullCoverage;
                    clientVm.Quote = client.Quote;
                    clientsVm.Add(clientVm);
                }

                return View(clientsVm);
            }
        }
    }
}
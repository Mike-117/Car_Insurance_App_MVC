using CarInsuranceAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Success(string firstName, string lastName, string email, DateTime dateOfBirth, string carMake, string carModel, string carYear, bool dui, string speedingTickets, bool fullCoverage)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || dateOfBirth == null || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel) || string.IsNullOrEmpty(carYear) || string.IsNullOrEmpty(speedingTickets))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceEntities db = new CarInsuranceEntities())
                {
                    {
                        var client = new Client();
                        client.FirstName = firstName;
                        client.LastName = lastName;
                        client.DateOfBirth = dateOfBirth;
                        client.Email = email;
                        client.CarMake = carMake.ToLower();
                        client.CarModel = carModel.ToLower();
                        client.CarYear = Convert.ToInt32(carYear);
                        client.DUI = dui;
                        client.SpeedingTickets = Convert.ToInt32(speedingTickets);
                        client.FullCoverage = fullCoverage;


                        int baseQuote = 50;
                        int age = DateTime.Now.Year - dateOfBirth.Year;
                        if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                        {
                            age -= 1;
                        }
                        if (age < 18)
                        {
                            baseQuote += 100;
                        }
                        else if (age < 25 || age > 100)
                        {
                            baseQuote += 25;
                        }

                        if (Convert.ToInt32(carYear) < 2000 || Convert.ToInt32(carYear) > 2015)
                        {
                            baseQuote += 25;
                        }

                        if (carMake == "porsche")
                        {
                            baseQuote = (carModel == "911 carrera") ? baseQuote + 50 : baseQuote + 25;
                        }

                        baseQuote += (Convert.ToInt32(speedingTickets) * 10);

                        if (dui)
                        {
                            baseQuote += (baseQuote / 4);
                        }

                        if (fullCoverage)
                        {
                            baseQuote += (baseQuote / 2);
                        }

                        client.Quote = baseQuote;

                        db.Clients.Add(client);
                        db.SaveChanges();

                        ViewBag.FirstName = client.FirstName;
                        ViewBag.LastName = client.LastName;
                        ViewBag.DateOfBirth = client.DateOfBirth;
                        ViewBag.Email = client.Email;
                        ViewBag.CarMake = client.CarMake;
                        ViewBag.CarModel = client.CarModel;
                        ViewBag.CarYear = client.CarYear;
                        ViewBag.DUI = client.DUI;
                        ViewBag.SpeedingTickets = client.SpeedingTickets;
                        ViewBag.FullCoverage = client.FullCoverage;
                        ViewBag.Quote = client.Quote;

                    }
                    return View();
                }

                
            }
        }
    }
}
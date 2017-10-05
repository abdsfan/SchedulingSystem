using Microsoft.AspNet.Identity;
using SchedulingSystem.Models;
using SchedulingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulingSystem.Controllers
{
    public class RatingController : Controller
    {
        public ApplicationDbContext context;

        public RatingController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult SearchForDriver()
        {
            var dataForRating = new DataForRatingViewModel();
            return View(dataForRating);

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SearchForDriver(DataForRatingViewModel data)
        {
            var cap = context.Caps.FirstOrDefault(n => n.CapNumber == data.CapNumber);
            if(cap != null)
            {
                var date = context.Schedules.FirstOrDefault(n => n.Cap.Id == cap.Id && n.ShiftDate == data.DateOfDay && (n.StartTime.Hour <= data.TimeOfDay.Hour && n.EndTime.Hour >= data.TimeOfDay.Hour));
                if(date == null)
                {
                    ModelState.AddModelError("", "invalid entry, Try again. ");
                    return View(data);
                }
                var user = date.ApplicationUser.Id;

                var driverInfo = new ScoringDriver
                {
                    UserId = user,
                    CapId = cap.Id,
                };


                //create new view model for user id and cap id
                //instantiate it here and assig the value to it
                //then create the view and r
                return RedirectToAction("ScoringDriver", driverInfo);
            }

            ModelState.AddModelError("", "invalid entry, Try again. ");
            return View();
        }

        [AllowAnonymous]
        public ActionResult ScoringDriver(ScoringDriver driverInfo)
        {
            return View(driverInfo);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDriverScore(ScoringDriver driverInfo)
        {
            if(driverInfo.DriverScore > 10)
            {
                //this is not working, needs fixing
                ModelState.AddModelError("", "invalid score, Try again. ");
                return View("ScoringDriver", driverInfo);
            }

            var user = context.Users.FirstOrDefault(u => u.Id == driverInfo.UserId);
            var cap = context.Caps.FirstOrDefault(c => c.Id == driverInfo.CapId);
            var newRating = new Rating
            {
                DateRated = DateTime.Today,
                ApplicationUser = user,
                Cap = cap,
                Score = driverInfo.DriverScore
            };
            context.Ratings.Add(newRating);
            context.SaveChanges();        
            return RedirectToAction("Index", "Home");            
        }

        public ActionResult DriverScore()
        {
            double totalScore = 0;
            var user = User.Identity.GetUserId();
            var scoreList = context.Ratings.Where(m => m.ApplicationUser.Id == user).ToList();
            foreach(var eachScore in scoreList)
            {
                totalScore += eachScore.Score;
            }
            var performanceScore = ((totalScore / scoreList.Count)/10) * 100;
            var driverScore = new DriverScore
            {
                Score = performanceScore
            };
            return View(driverScore);
        }

        // POST: Rating/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rating/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using SchedulingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulingSystem.Controllers
{
    public class SchedulerController : Controller
    {
        private ApplicationDbContext context;

        public SchedulerController()
        {
            context = new ApplicationDbContext();
        }
            

        // GET: Scheduler
        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult getEvent()
        {
            var schedule = context.Schedules.ToList();
            //var model = new Model { };
            return Json(schedule);
        }
    }
}
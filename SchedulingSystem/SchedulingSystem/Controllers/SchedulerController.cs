using SchedulingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchedulingSystem.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            //var schedule = context.Schedules.ToList();
            //var test = context.Schedules.Select(s => s.Id );
            var model = (from s in context.Schedules
                         select 
             new ShowScheduledShiftsViewModel
            {
                Id = s.Id ,
                ResourceId = s.Cap.Id ,
                Start = s.StartTime, 
                End = s.EndTime, 
                Title = s.ApplicationUser.Email
            }).ToList();
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return Json(JsonConvert.SerializeObject(model, camelCaseFormatter ), JsonRequestBehavior.AllowGet);
        }
    }
}
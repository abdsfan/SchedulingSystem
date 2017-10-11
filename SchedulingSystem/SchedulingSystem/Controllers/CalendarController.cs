
using Newtonsoft.Json;
using SchedulingSystem.Models;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SchedulingSystem.Controllers
{
    public class CalendarController : ApiController
    {
        private ApplicationDbContext context;

        public CalendarController()
        {
            context = new ApplicationDbContext();

        }
        // GET api/<controller>
        public JsonResult Get()
        {
            var model = (from s in context.Schedules
                         select
             new ShowScheduledShiftsViewModel
             {
                 Id = s.Id,
                 ResourceId = s.Cap.Id,
                 Start = s.StartTime,
                 End = s.EndTime,
                 Title = s.ApplicationUser.Email
             }).ToList();

            return Json(JsonConvert.SerializeObject(model, new JsonSerializerSettings { }), JsonRequestBehavior.AllowGet);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
using System;
using SchedulingSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SchedulingSystem.ViewModels;
using RestSharp;
using RestSharp.Authenticators;

namespace SchedulingSystem.Controllers
{
    public class PaymentController : Controller
    {
        private ApplicationDbContext context;
        public PaymentController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Payment
        public ActionResult PaymentsDetail()
        {
            //var paymentList =  "";
            var user = User.Identity.GetUserId();
            var userScheduledShifts = context.Schedules.Where(u => u.ApplicationUser.Id == user && u.Payment.Status == "outstanding" ).ToList();

            var totalBalance = userScheduledShifts.Sum(x => x.Payment.Amount);
            var model = new OutstandingBalanceViewModel
            {
                TotalBalance = totalBalance,
                ScheduleDetails = userScheduledShifts
            };
            //var outstandBalanceShifts = (from u in userScheduledShifts
            //                             join p in context.Payments on u.Payment.Id equals p.Id
            //                             where p.Status == "outstanding"
            //                             select new OutstandingBalanceViewModel
            //                             {
            //                                 outstanding = new List<OutstandingBalance>
            //                                 {
            //                                     new OutstandingBalance
            //                                     {
            //                                          ShiftDate = u.ShiftDate,
            //                                          Cost = p.Amount
            //                                     }
            //                                 }
            //                            }).FirstOrDefault();

            return View(model);
        }
        
        public ActionResult SubmitPayment(OutstandingBalanceViewModel model)
        {
            //SendSimpleMessage();
            return RedirectToAction("Paymentconfirmation");
        }

        public ActionResult PaymentConfirmation()
        {
            return View();
        }

        public static IRestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
            new HttpBasicAuthenticator("api",
                                      "key-5054f6dcaa3b7decfe100243fcf3cffc");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox3d87e8505d9144558b123e3dfb3f70ca.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Green Cap <greencapmadison@gmail.com>");
            request.AddParameter("to", "Abdullah <abdsfan@gmail.com>");
            request.AddParameter("subject", "Payment Confirmation");
            request.AddParameter("text", "Hello Abdullah, We had received your payment! Thank you. ");
            request.Method = Method.POST;
            return client.Execute(request);
        }
        //postmaster @sandbox3d87e8505d9144558b123e3dfb3f70ca.mailgun.org
        // You can see a record of this email in your logs: https://mailgun.com/app/logs .

        // You can send up to 300 emails/day from this sandbox server.
        // Next, you should add your own domain so you can send 10,000 emails/month for free.
    }
}
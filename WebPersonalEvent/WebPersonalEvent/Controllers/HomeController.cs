using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPersonalEventsOrganization.Models;
using System.Web.Security;
using System.Data;
using System.Globalization;

namespace MvcPersonalEventsOrganization.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to Events Organizing...!";

            return View();
        }

        public ActionResult CreateNewEvent()
        {
            //If user is invalid then go to login
            if(new tbUsersServices().isUserLogin()==false)
                return RedirectToAction("LogOn", "Account");

            return View();
        }
    
        public ActionResult DeleteEvent(string mNumber)
        {

            if (mNumber != null)
            {
                try
                {
                    new tbEventsModelService().DeleteEvent(mNumber);
                    return RedirectToAction("PersonalHome");
                }
                catch
                {

                }
            }

            
            return View();
        }
        public ActionResult EditEvent(string mNumber)
        {
            if (mNumber != null)
            {
                tbEventsModel tbEventsModel = new tbEventsModel();
                string strID = mNumber;
                DataTable dt = new tbEventsModelService().GetEvents(strID);
                if (dt.Rows.Count > 0)
                {
                    tbEventsModel.ID = dt.Rows[0]["ID"].ToString();
                    tbEventsModel.EventType = dt.Rows[0]["EventType"].ToString();
                    var date = DateTime.ParseExact(dt.Rows[0]["EventDate"].ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tbEventsModel.EventDate = date;
                    tbEventsModel.Remarks =(dt.Rows[0]["Remarks"].ToString());
                    return View(tbEventsModel);
                }
            }

            return View();
        }
        [HttpPost]
        public ActionResult EditEvent(tbEventsModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = new tbEventsModelService().CreateEvent(model.ID, model.EventType, model.EventDate, model.Remarks);

                if (createStatus == MembershipCreateStatus.Success)
                {

                    return RedirectToAction("PersonalHome", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }


            return View(model);
        }
        [HttpPost]
        public ActionResult CreateNewEvent(tbEventsModel model)
        {

            
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = new tbEventsModelService().CreateEvent(model.ID,model.EventType ,model.EventDate ,model.Remarks );

                if (createStatus == MembershipCreateStatus.Success)
                {

                    return RedirectToAction("PersonalHome", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

           
            return View(model);
        }


        public ActionResult PersonalHome()
        {

            //If user is invalid then go to login
            if (new tbUsersServices().isUserLogin() == false)
                return RedirectToAction("LogOn", "Account");
            return View();
        }
    }
}

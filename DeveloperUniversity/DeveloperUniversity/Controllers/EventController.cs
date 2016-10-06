using System;
using System.Linq;
using System.Web.Mvc;
using DeveloperUniversity.Models;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;

namespace DeveloperUniversity.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;

            scheduler.Config.first_hour = 6;
            scheduler.Config.last_hour = 20;

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }
        [HttpPost]
        public ContentResult Data(DateTime from, DateTime to)
        {
            var apps = _db.Events.Where(e => e.EventStartDate < to && e.EventEndDate >= from).ToList();
            return new SchedulerAjaxData(apps);
        }
        [HttpGet]
        public ContentResult Data()
        {
            var apps = _db.Set<Event>().ToList();
            return new SchedulerAjaxData(apps);
        }

        public ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Event>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        Event EV = new Event();
                        EV.Description = changedEvent.Description;
                        EV.EventName = changedEvent.EventName;
                        EV.EventStartDate = changedEvent.EventStartDate;
                        EV.EventEndDate = changedEvent.EventEndDate;
                        EV.Description = changedEvent.Description;
                        _db.Events.Add(EV);
                        _db.SaveChanges();

                        break;
                }
                _db.SaveChanges();
                action.TargetId = Convert.ToInt64(changedEvent.EventId);
            }
            catch (Exception)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }
    }
}
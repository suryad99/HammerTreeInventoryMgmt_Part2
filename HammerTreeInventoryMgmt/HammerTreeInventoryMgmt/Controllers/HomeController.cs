using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Data.Repository;
using Hammer.Data.BusinesssModel;

namespace HammerTreeInventoryMgmt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult GetHammersInventory(FormCollection form)
        {
            HammerRepository repo = new HammerRepository();
            var data = repo.GetHammers().ToList();

            //data = null;
            if (data == null || data.Count <= 0)
            {
                return Json(new
                {
                    success = true,
                    totalNumberOfRecords = 0,
                    noRecordFoundMessage = "No  Data Found",
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = true,
                    noRecordFoundMessage = (data.Count > 0 ? "" : "No  Data Found"),
                    serverData = data.Select(h => new
                    {
                        HammerId = h.HammerId,
                        HammerName = h.HammerName,
                        HammerDescription = h.HammerDescription,
                        Category = h.Category
                    }).ToArray()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveHammers(string hammerName, string category, string description)
        {
            HammerRepository repo = new HammerRepository();
            HammerDTO dto = new HammerDTO
            {

                HammerName = hammerName,
                HammerDescription = description,
                Category = category
            };
            var data = repo.SaveHammers(dto);

            //data = null;
            if (data == null)
            {
                return Json(new
                {
                    success = true,
                    totalNumberOfRecords = 0,
                    noRecordFoundMessage = "No  Data Found",
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = true,
                    noRecordFoundMessage = (data == null ? "" : "No  Data Found"),
                    serverData = new
                    {
                        HammerId = data.HammerId,
                        HammerName = data.HammerName,
                        HammerDescription = data.HammerDescription,
                        Category = data.Category
                    }
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateHammers(string hammerName, string category, string description)
        {
            HammerRepository repo = new HammerRepository();
            HammerDTO dto = new HammerDTO
            {

                HammerName = hammerName,
                HammerDescription = description,
                Category = category
            };
            var data = repo.SaveHammers(dto);

            //data = null;
            if (data == null)
            {
                return Json(new
                {
                    success = true,
                    totalNumberOfRecords = 0,
                    noRecordFoundMessage = "No  Data Found",
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = true,
                    noRecordFoundMessage = (data == null ? "" : "No  Data Found"),
                    serverData = new
                    {
                        HammerId = data.HammerId,
                        HammerName = data.HammerName,
                        HammerDescription = data.HammerDescription,
                        Category = data.Category
                    }
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteHammers(string hammerid)
        {
            HammerRepository repo = new HammerRepository();
            HammerDTO dto = new HammerDTO
            {

                HammerId = Convert.ToInt32(hammerid)
            };
            var data = repo.DeleteHammers(dto);

            //data = null;
            if (data == true)
            {
                return Json(new
                {
                    success = true,
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = false,
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hammer.Data.Repository;
using Hammer.Data.BusinesssModel;

namespace HammerTreeInventoryMgmt.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCategoryInventory(FormCollection form)
        {
            CategoryRepository repo = new CategoryRepository();
            var data = repo.GetCategories().ToList();

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
                        CategoryId = h.CategoryId,
                        CategoryName = h.CategoryName,
                        CategoryDescription = h.CategoryDescription,
                    }).ToArray()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveCategory(string categoryid, string category, string description)
        {
            CategoryRepository repo = new CategoryRepository();
            CategoryDTO dto = new CategoryDTO
            {

                CategoryName = category,
                CategoryDescription = description,
            };
            var data = repo.SaveCategory(dto);

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
                        CategoryId = data.CategoryId,
                        CategoryName = data.CategoryName,
                        CategoryDescription = data.CategoryDescription,
                    }
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateCategory(string categoryid, string category, string description)
        {
            CategoryRepository repo = new CategoryRepository();
            CategoryDTO dto = new CategoryDTO
            {
                CategoryId = Convert.ToInt32(categoryid),
                CategoryName = category,
                CategoryDescription = description,
            };
            var data = repo.SaveCategory(dto);

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
                        CategoryId = data.CategoryId,
                        CategoryName = data.CategoryName,
                        CategoryDescription = data.CategoryDescription,
                    }
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteCategory(string categoryid)
        {
            CategoryRepository repo = new CategoryRepository();
            CategoryDTO dto = new CategoryDTO
            {

                CategoryId = Convert.ToInt32(categoryid)
            };
            var data = repo.DeleteCategory(dto);

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
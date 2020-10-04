using FileUploadBusiness;
using FileUploadData.Model;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FileUploadWeb.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            IFileUploadService serice = new FileUploadBIL();
            var result = serice.getAll();
            if (result.Status)
            {
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Error = result.Message;
            }

            return View(result.Objects);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            IFileUploadService serice = new FileUploadBIL();
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                var result = serice.insert(path);
                if (result.Status)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Error = result.Message;
                }
            }
            else
            {
                ViewBag.Error = "You have not specified a file.";
            }
            return View();
        }
        [HttpGet]
        public JsonResult GetByStatus(string status)
        {
            IFileUploadService serice = new FileUploadBIL();
            var result = serice.getByStatus(status);
            return Json(new { draw=1, recordsTotal =result.TotalRecord, recordsFiltered = result.TotalRecord, data = result.Objects }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetByCurrency(string currency)
        {
            IFileUploadService serice = new FileUploadBIL();
            var result = serice.getByCurrency(currency);
            return Json(new { draw = 1, recordsTotal = result.TotalRecord, recordsFiltered = result.TotalRecord, data = result.Objects }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetByDateRange(DateTime startDate,DateTime endDate)
        {
            IFileUploadService serice = new FileUploadBIL();
            var result = serice.getByDateRange(startDate, endDate);
            return Json(new { draw = 1, recordsTotal = result.TotalRecord, recordsFiltered = result.TotalRecord, data = result.Objects }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            IFileUploadService serice = new FileUploadBIL();
            var result = serice.getAll();
            return Json(new { draw = 1, recordsTotal = result.TotalRecord, recordsFiltered = result.TotalRecord, data = result.Objects }, JsonRequestBehavior.AllowGet);
        }
    }
}
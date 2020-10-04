﻿using FileUploadBusiness;
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
            return View(serice.getAll());
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
                if (result)
                {
                    try
                    {                        
                        ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                else
                {

                    ViewBag.Message = result;
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }
    }
}
using FileUploadBusiness;
using System.Web.Mvc;

namespace FileUploadWeb.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            IFileUploadService serice = new FileUploadBIL();
            return View();
        }
    }
}
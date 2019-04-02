using System;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ViewController : Controller
    {
        // GET: View
        private Models.PRGDBEntities2 db = new Models.PRGDBEntities2();
        public ActionResult ViewPage()
        {
            var Items = db.ViewPageList1;
            return View(Items);
        }

        public ActionResult DownloadData(string name, string url)
        {
            DateTime thisDay = DateTime.Now;
            OfferList offerList = new OfferList
            {
                UserName = "User",
                Date = thisDay.ToString(),
                NameOfOffer = name
            };
            db.OfferList.Add(offerList);
            db.SaveChanges();
            byte[] fileBytes = System.IO.File.ReadAllBytes(url);
            string fileName = "Your_File.zip";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
           
        }
    }
}
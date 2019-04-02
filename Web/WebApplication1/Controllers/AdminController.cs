using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private Models.PRGDBEntities2 db = new Models.PRGDBEntities2();
        public ActionResult AdminPage()
        {
            var Items = db.RegistrationList;
            return View(Items);
        }
        [HttpPost]
        public ActionResult AddElements(string title, string description, string listOfFeatures, string descriptionAfter, string url)
        {

            var Items = db.ViewPageList1;
           foreach(var item in Items)
            {
                if(item.Title == title)
                {
                    item.Description = description;
                    item.ListOfFeatures = listOfFeatures;
                    item.DescriptionAfter = descriptionAfter;
                    item.URL = url;
                   db.SaveChangesAsync();
                    return Redirect("/Admin/RegistationListElemets");
                }
            }

            ViewPageList1 viewPage = new ViewPageList1
            {
                Title = title,
                Description = description,
                ListOfFeatures = listOfFeatures,
                DescriptionAfter = descriptionAfter,
                URL = url
            };

            db.ViewPageList1.Add(viewPage);
            db.SaveChanges();
            return Redirect("/Admin/RegistationListElemets");
        }
        public ActionResult RegistationListElemets()
        {
            var Items = db.RegistrationList;
            return View(Items);
        }
        public ActionResult OfferListElements()
        {
            var Items = db.OfferList;
            return View(Items);
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private Models.PRGDBEntities2 db = new Models.PRGDBEntities2();
        public ActionResult Index()
        {
            var Items = db.RegistrationList;
            return View(Items);
        }
        [HttpPost]
       public ActionResult Form(string userName, string password, string email)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            RegistrationList registrationList = new RegistrationList
            {
                UserName = userName,
                Password = password,
                Email = email
            };

            var Items = db.RegistrationList;
            if (!(Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase)))
            {
                return Redirect("/Home/Index");
            }
            if (userName == "" || email == "" || password == "")
            {
                return Redirect("/Home/Index");
            }
            
            foreach(var Item in Items)
            {
                if(Item.UserName == userName)
                {
                    return Redirect("/Home/Index");
                }
                else if(Item.Email == email)
                {
                    return Redirect("/Home/Index");
                }
            }
            db.RegistrationList.Add(registrationList);
            db.SaveChanges();
            return Redirect("/View/ViewPage");
        }
        public ActionResult FormLogin(string userName, string password)
        {
            RegistrationList r = null;
            if(userName == "admin" && password == "admin")
            {
                return Redirect("/Admin/RegistationListElemets");
            }
            r = db.RegistrationList.FirstOrDefault(u => u.UserName == userName && u.Password == password || u.Email == userName && u.Password == password);
            if(r == null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect("/View/ViewPage");
            }
            
        }
        public string Count()
        {
            int count = 0;
            List<int> listOfInt = new List<int>();
            List<string> list = new List<string>();
            var Items = db.OfferList;
            foreach (var Item in Items)
            {
                if (list.IndexOf(Item.NameOfOffer) == -1)
                {
                    list.Add(Item.NameOfOffer);
                }
            }
            foreach (string i in list)
            {
                foreach (var Item in Items)
                {
                    if (i == Item.NameOfOffer)
                    {
                        count++;
                    }
                }
                listOfInt.Add(count);
                count = 0;
            }
            int f = 0;
            string SomeString = "";
            foreach (string i in list)
            {
                SomeString += listOfInt[f] + " : " + i + " ";
                f++;
            }
            return SomeString;
        }

        //public string DataIn(string date)
        //{
        //    string outp = "";
        //    var Items = db.OfferList;
        //    foreach(var item in Items)
        //    {
        //        if(item.Date == date)
        //        {
        //            outp += item.NameOfOffer + "   ";
        //        }
        //    }
        //    return outp;
        //}

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeaMODEPortal.Models;



namespace SeaMODEPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Out";
                ViewBag.LoginError = 0;
            }
            else
            {
                ViewBag.LoggedStatus = "In";
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Authorize(Login LoginModel)
        {
            seamodeEntities3 db = new seamodeEntities3();
            var LoggedUser = db.Login.SingleOrDefault(x => x.UserName == LoginModel.UserName && x.PassWord == LoginModel.PassWord);
            if(LoggedUser != null)
            {
                ViewBag.LoginMessage = "Successfull login";
                ViewBag.LoggedStatus = "In";
                ViewBag.LogginError = 0; //Ei virhettä
                Session["UserName"] = LoggedUser.UserName;
                Session["Boat"] = LoggedUser.BoatID;
                Session["AccLvl"] = LoggedUser.AccessLvl;
                Session["LoginID"] = LoggedUser.LoginID;
                return RedirectToAction("LoggedIn", "Home"); //Onnistunut kirjautuminen vie tähän metodiin
            }
            else
            {
                
                ViewBag.LoginMessage = "Login unsuccessfull";
                ViewBag.LoggedStatus = "Out";
                ViewBag.LoginError = 1; //Pakotetaan modaali login-ruutu uudelleen => Virhe kirjautumis yrityksessä
                LoginModel.LoginErrorMessage = "Unknown username or password.";
                return View("Index", LoginModel);
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            ViewBag.LoggedStatus = "Out";
            return RedirectToAction("Index", "Home"); //Uloskirjautumisen jälkeen etusivulle
        }
    }
}
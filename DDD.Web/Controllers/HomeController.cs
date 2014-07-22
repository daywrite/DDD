using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDD.Domain.Models;
using DDD.Application.Imple;
namespace DDD.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
        public ActionResult Index()
        {
            //User u = userService.GetByKey(new Guid("be8c6f0a-5b11-e411-b59f-446d57c14a18"));

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

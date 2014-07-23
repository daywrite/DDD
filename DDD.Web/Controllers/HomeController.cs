using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDD.Domain.Models;
using DDD.Application.Imple;
using DDD.Infrastructure.Caching;
using log4net;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace DDD.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        //private readonly ICacheProvider _cacheProvider;
        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }
        public ActionResult Index()
        {
            

            //User u = _userService.GetByKey(new Guid("be8c6f0a-5b11-e411-b59f-446d57c14a18"));
            //_cacheProvider.Add("user", "u", u);
            //User _u = (User)_cacheProvider.Get("user", "u");

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

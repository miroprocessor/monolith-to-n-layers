using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Customertreatments1.Data;
using Customertreatments1.Models;

namespace Customertreatments1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        //   private ApplicationUserManager _userManager;

        public HomeController( UserManager<IdentityUser> userManager)
        {
   
            _userManager = userManager;

        }




        public IActionResult Index()
        {
             var userid = _userManager.GetUserId(HttpContext.User);
            IdentityUser user = _userManager.FindByIdAsync(userid).Result;



            return View(user);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

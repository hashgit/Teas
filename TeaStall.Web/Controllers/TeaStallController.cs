using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaStall.Services.Models;

namespace TeaStall.Web.Controllers
{
    public class TeaStallController : Controller
    {
        private readonly ITeaStallServiceManager _teaStallServiceManager;

        public TeaStallController(ITeaStallServiceManager teaStallServiceManager)
        {
            _teaStallServiceManager = teaStallServiceManager;
        }

        // GET: TeaStall
        public JsonResult GetTeaBases()
        {
            var bases = _teaStallServiceManager.GetTeaBases();
            return Json(bases, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFlavors()
        {
            var bases = _teaStallServiceManager.GetFlavors();
            return Json(bases, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetToppings()
        {
            var bases = _teaStallServiceManager.GetToppings();
            return Json(bases, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Linq;
using System.Web.Mvc;
using Contracts.Wip;
using Contracts.Wip.Commands;
using Domain;
using Persistence;

namespace Web.Controllers
{
    public class WipController : Controller
    {
        //
        // GET: /Default1/
        [HttpGet]
        public ActionResult Index()
        {
            return View(Repository.GetAll().ToList());
        }

        [HttpPost]
        public ActionResult Index(string test)
        {
            MvcApplication.Bus.Send(new ReleaseWip {WipId = Guid.NewGuid()});
            return RedirectToAction("Index");
        }

    } 
}
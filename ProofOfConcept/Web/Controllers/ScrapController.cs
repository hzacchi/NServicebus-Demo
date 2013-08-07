using System;
using System.Linq;
using System.Web.Mvc;
using Contracts.Scrap;
using Contracts.Scrap.Commands;
using Domain;
using Persistence;

namespace Web.Controllers
{
    public class ScrapController : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var wip = Repository.GetAll<WipItem>().Where(o => o.Station == "Scrap").ToList();
            return View(wip);
        }

        [HttpPost]
        public ActionResult Scrap(Guid id)
        {
            MvcApplication.Bus.Send(new ScrapWip { WipId = id });
            return RedirectToAction("Index");
        }
    }
}
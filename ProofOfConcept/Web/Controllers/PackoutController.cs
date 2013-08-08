using System;
using System.Linq;
using System.Web.Mvc;
using Contracts.Packout;
using Contracts.Packout.Commands;
using Domain;
using Persistence;

namespace Web.Controllers
{
    public class PackoutController : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var wip = Repository.GetAll().Where(o => o.Station == "Packout").ToList();
            return View(wip);
        }

        [HttpPost]
        public ActionResult Pack(Guid id)
        {
            MvcApplication.Bus.Send(new PackWip { WipId = id });
            return RedirectToAction("Index");
        }

    }
}
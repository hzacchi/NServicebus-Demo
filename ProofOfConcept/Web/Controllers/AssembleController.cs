using System;
using System.Linq;
using System.Web.Mvc;
using Contracts.Assemble;
using Contracts.Assemble.Commands;
using Domain;
using Persistence;

namespace Web.Controllers
{
    public class AssembleController : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var wip = Repository.GetAll().Where(o => o.Station == "Assemble").ToList();
            return View(wip);
        }

        [HttpPost]
        public ActionResult Pass(Guid id)
        {
            MvcApplication.Bus.Send(new PassAssemble { WipId = id });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Fail(Guid id)
        {
            MvcApplication.Bus.Send(new FailAssemble { WipId = id });
            return RedirectToAction("Index");
        }
    }
}
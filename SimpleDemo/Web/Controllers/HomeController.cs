using System.Web.Mvc;
using Messages;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var state = System.IO.File.Exists(State.FilePath)
                            ? JsonConvert.DeserializeObject<State>(System.IO.File.ReadAllText(State.FilePath))
                            : new State();

            return View(state);
        }

    }
}

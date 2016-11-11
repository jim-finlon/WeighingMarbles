using System.Web.Mvc;
using WeighingMarbles.Services;

namespace WeighingMarbles.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = new MarbleService();
            var vm = service.StartProcess(40, 17);
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
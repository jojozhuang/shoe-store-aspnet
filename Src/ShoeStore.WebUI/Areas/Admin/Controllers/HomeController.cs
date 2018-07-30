using System.Linq;
using System.Web;
using System.Web.Mvc;
using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
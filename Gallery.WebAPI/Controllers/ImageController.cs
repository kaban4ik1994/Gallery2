using System.Web.Http;
using System.Web.Mvc;
namespace Gallery.WebAPI.Controllers
{
    public class ImageController : ApiController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
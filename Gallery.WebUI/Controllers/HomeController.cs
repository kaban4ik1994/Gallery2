using System.Linq;
using System.Web.Mvc;
using Gallery.Models.Models;
using Gallery.Util.Conrete;
using Gallery.Util.Interfaces;
using Gallery.WebUI.Helpers;
using Gallery.WebUI.Models.Home;

namespace Gallery.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPictureUtil _pictureUtil;
        private readonly IDepartamentUtil _departamentUtil;

        public HomeController()
        {
            _pictureUtil=new PictureUtil(ConfigHeper.PictureApiUrl);
            _departamentUtil=new DepartamentUtil(ConfigHeper.DepartamentApiUrl);
        }

        public ActionResult Index(string departament)
        {
            
            var model = new HomeViewModel {SelectedDepartament = departament};
            if (string.IsNullOrEmpty(departament))
            {
                model.Pictures = _pictureUtil.GetPicturess().ToList();
            }
            
            else
            {
                var dep = _departamentUtil.GetDepartamentByName(departament);
                model.Pictures = dep == null ? _pictureUtil.GetPicturess().ToList() : dep.Picture.ToList();
            }

            for (var i = 0; i < model.Pictures.Count; i++) // костыль, ибо ограничения на принимаемое кол-во данных
            {
                model.Pictures[i] = _pictureUtil.GetPictureById(model.Pictures[i].PictureId);
            }

            return View(model);
        }
    }
}
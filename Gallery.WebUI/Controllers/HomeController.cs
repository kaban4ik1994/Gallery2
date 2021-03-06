﻿using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Gallery.Models.Models;
using Gallery.Util.Conrete;
using Gallery.Util.Interfaces;
using Gallery.WebUI.CustomAttribute;
using Gallery.WebUI.Helpers;
using Gallery.WebUI.Models.Home;
using Gallery.WebUI.Models.Picture;

namespace Gallery.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPictureUtil _pictureUtil;
        private readonly IDepartamentUtil _departamentUtil;
        private readonly ICommentUtil _commentUtil;
        private readonly IAccountUtil _accountUtil;

        public HomeController()
        {
            _pictureUtil = new PictureUtil(ConfigHeper.PictureApiUrl);
            _departamentUtil = new DepartamentUtil(ConfigHeper.DepartamentApiUrl);
            _commentUtil = new CommentUtil(ConfigHeper.CommentApiUrl);
            _accountUtil = new AccountUtil(ConfigHeper.AccountApiUrl);
        }

        public ActionResult Index(string departament)
        {

            var model = new HomeViewModel { SelectedDepartament = departament };
            if (string.IsNullOrEmpty(departament))
            {
                model.Pictures = _pictureUtil.GetPicturess().ToList();
            }

            else
            {
                var dep = _departamentUtil.GetDepartamentByName(departament);
                model.Pictures = dep == null ? _pictureUtil.GetPicturess().ToList() : dep.Picture.ToList();
            }

            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var picture = _pictureUtil.GetPictureById(id);
            if (picture == null) return RedirectToAction("Index", "Error");
            var model = Mapper.Map<PictureViewModel>(picture);
            model.DepartamentName = picture.Departament.DepartamentName;
            model.GenreName = picture.Genre.GenreName;
            model.PainterName = picture.Painter.PainterFullName;
            return View(model);
        }

        [HttpPost]
        public void Comment(long id, string content)
        {
            var picture = _pictureUtil.GetPictureById(id);
            if (picture == null) return;
            var comment = new Comment { CommentPictureId = id, Content = content, CommentUserId = AuthHelper.GetUser(HttpContext, _accountUtil).UserId };
            _commentUtil.CreateComment(comment);
        }

        [PageAuthorize(UserRoles = "admin")]
        public ActionResult DeleteComment(long id)
        {
            _commentUtil.DeleteComment(id);
            return RedirectToAction("Detail", new { id });
        }
    }
}
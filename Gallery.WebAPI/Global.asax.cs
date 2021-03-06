﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Gallery.Data;
using Gallery.Mappings.Mappings;
using Gallery.WebAPI.App_Start;

namespace Gallery.WebAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            InitilizeMapper();
            Database.SetInitializer(new GalleryContextInitializer());
        }

        private static void InitilizeMapper()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<UserMappingProfile>();
                config.AddProfile<CommentMappingProfile>();
                config.AddProfile<DepartamentMappingProfile>();
                config.AddProfile<GenreMappingProfile>();
                config.AddProfile<ImageMappingProfile>();
                config.AddProfile<PainterMappingProfile>();
                config.AddProfile<PictureMappingProfile>();
                config.AddProfile<RoleMappingProfile>();
                config.AddProfile<TokenMappingProfile>();
            }
        );
            Mapper.AssertConfigurationIsValid();
        }
    }
}

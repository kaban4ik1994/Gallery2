﻿using System.ComponentModel;
using Gallery.WebUI;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Gallery.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
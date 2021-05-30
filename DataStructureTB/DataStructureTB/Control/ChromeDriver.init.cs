﻿using CefSharp.Core;
using DataStructureTB.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Control
{
    partial class ChromeDriver
    {
        private void InitializeComponent()
        {
            //Settings
            base.RequestContext = new RequestContext(new RequestContextSettings()
            {
                CachePath = Environment.CurrentDirectory + "\\Users Data\\Default"
            });
            base.Dock = System.Windows.Forms.DockStyle.Fill;

            //Handlers
            base.LifeSpanHandler = new LifeSpanHandler();
            base.RequestHandler = new RequestHandler();

            //接口获取的指纹array
            var fingerprint = new Dictionary<string, string>();

            //替换好的fingerprint js
            string js = "<script>" + Initfingerprint(fingerprint) + "</script>";

        }
    }
}

﻿using System;
using DataStructureTB.Model;
using System.Collections.Generic;

namespace DataStructureTB.Handlers
{
    /// <summary>
    /// script 标签生成
    /// </summary>
    internal class ScriptTabDirectror
    {
        internal ScriptTabDirectror()
        { }

        internal void Construct(ResponseFilterConfigItem jsCfg, HtmlTagBuilder build)
        {
            build.BeginTag("script");
            build.SetAttribute("type", "text/javascript");

            //设置src
            if (!string.IsNullOrWhiteSpace(jsCfg.Src))
                build.SetAttribute("src", jsCfg.Src);

            //设置js文件内容
            if (System.IO.File.Exists(jsCfg.Path))
                build.SetContent(System.IO.File.ReadAllText(jsCfg.Path));

            //设置js文件内容
            if (!string.IsNullOrEmpty(jsCfg.ScriptContent))
                build.SetContent(jsCfg.ScriptContent);

            build.EndTag();
        }
    }
}

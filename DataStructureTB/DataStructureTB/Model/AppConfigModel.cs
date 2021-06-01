﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureTB.Model
{
    /// <summary>
    /// 程序配置模型
    /// </summary>
    internal class AppConfigModel
    {
        public AppConfigModel() 
        { }

        public string Discription { get; set; }
        public string Version { get; set; }

        /// <summary>
        /// javascript配置
        /// </summary>
        public IEnumerable<JavaScriptMode> JavaScripts { get; set; }
    }


    /// <summary>
    /// javascript信息配置
    /// </summary>
    internal class JavaScriptMode
    {
        public JavaScriptMode() 
        { }

        /// <summary>
        /// 该脚本处理的请求地址
        /// </summary>
        public string HandleUrl { get; set; }
        /// <summary>
        /// 该脚本的服务器地址
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// 该脚本的本地路径地址
        /// </summary>
        public string Path { get; set; }
    }
}
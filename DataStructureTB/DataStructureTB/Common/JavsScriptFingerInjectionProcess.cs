﻿using DataStructureTB.Handlers;
using System.Text;

namespace DataStructureTB.Common
{
    /// <summary>
    /// 脚本指纹注入处理
    /// </summary>
    internal class JavsScriptFingerInjectionProcess : ProcessStream
    {
        internal JavsScriptFingerInjectionProcess(IFingerInfo finger)
        {
            this.finger = finger;
            this.scriptTagBuild = new HtmlTagBuilder();
            this.scriptObjBuild = new JavaScriptObjectBuilder();
            this.SetProcess(this.InjectionFinger);
        }

        private IFingerInfo finger;                     //指纹
        private HtmlTagBuilder scriptTagBuild;          //组装script标签
        private JavaScriptObjectBuilder scriptObjBuild;  //组装js对象
        private bool isInjected = false;                //是否已经注入过了


        private byte[] InjectionFinger(byte[] html)
        {
            //不能重复注入
            if (this.isInjected || this.finger == null)
                return html;

            string script;
            string result = Encoding.UTF8.GetString(html);

            //注入头部
            int injectPos = result.IndexOf("<head>");
            if (injectPos >= 0)
            {
                //构造注入对象
                StringBuilder injectObj = new StringBuilder("", 2000);
                injectObj.AppendLine("var " + AppConfigManager.Inst.AppConfig.InjectObj + " = {}");
                injectObj.AppendLine($"{AppConfigManager.Inst.AppConfig.InjectFinger } = {this.finger.Fingerprint};");
                injectObj.AppendLine($"{AppConfigManager.Inst.AppConfig.InjectTaoUser} = \"{this.finger.TaoUser}\";");
                injectObj.AppendLine($"{AppConfigManager.Inst.AppConfig.InjectTaoPass} = \"{this.finger.TaoPass}\";");


                this.scriptTagBuild.BeginTag("script");
                this.scriptTagBuild.SetAttribute("type", "text/javascript");
                this.scriptTagBuild.SetContent(injectObj.ToString());      //注入对象注入js标签
                this.scriptTagBuild.EndTag();

                script = this.scriptTagBuild.Build();
                injectPos += "<head>".Length;
                result = result.Insert(injectPos, script);
                this.isInjected = true;
            }

            return Encoding.UTF8.GetBytes(result);
        }
    }
}

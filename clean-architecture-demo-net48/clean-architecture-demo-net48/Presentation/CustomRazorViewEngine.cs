using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace CleanArchitecture.Presentation
{
    public class CustomRazorViewEngine : IRazorViewEngine
    {
        private readonly IRazorViewEngine _innerViewEngine;

        public CustomRazorViewEngine(IRazorViewEngine innerViewEngine)
        {
            _innerViewEngine = innerViewEngine;
        }

        // Forward all the required interface methods to the inner view engine
        public RazorPageResult FindPage(ActionContext context, string pagePath)
        {
            return _innerViewEngine.FindPage(context, pagePath);
        }

        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            return _innerViewEngine.FindView(context, viewName, isMainPage);
        }

        public string GetAbsolutePath(string executingFilePath, string pagePath)
        {
            return _innerViewEngine.GetAbsolutePath(executingFilePath, pagePath);
        }

        public RazorPageResult GetPage(string executingFilePath, string pagePath)
        {
            return _innerViewEngine.GetPage(executingFilePath, pagePath);
        }

        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            return _innerViewEngine.GetView(executingFilePath, viewPath, isMainPage);
        }
    }
}
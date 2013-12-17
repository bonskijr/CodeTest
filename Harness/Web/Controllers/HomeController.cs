using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeTest.Core;
using CodeTest.Core.Writer;

namespace CodeTest.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public string HighlightMatchingText(string theString, string thePattern) 
        {
            var textMatcher = new TextMatcher(theString, thePattern);
            var writer = new FancyHtmlWriter(theString, thePattern);
            writer.Write(textMatcher.GetMatchingPositions());

            return writer.FormattedHtml;                
        }

    }
}

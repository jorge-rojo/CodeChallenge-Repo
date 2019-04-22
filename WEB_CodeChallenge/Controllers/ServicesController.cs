using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB_CodeChallenge.Sevices;

namespace WEB_CodeChallenge.Controllers
{
	/// <summary>
	/// Controller responsible for any ajax calls
	/// </summary>
	public class ServicesController : Controller
	{
		/// <summary>
		/// Load Url called by ajax
		/// </summary>
		/// <param name="url">Url to be load by the API implementation</param>
		/// <returns>Json object with all the details of word counters and Image gallery</returns>
		[HttpPost]
		public ActionResult LoadUrl(string url)
		{
			HtmlAnalyzerAPIImplementation apiServiceImplementation = new HtmlAnalyzerAPIImplementation();

			var result = apiServiceImplementation.TryAnalyzeUrl(url);

			return Json(new { Data = result });
		}
	}
}
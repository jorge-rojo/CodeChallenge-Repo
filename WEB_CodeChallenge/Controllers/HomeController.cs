using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_CodeChallenge.Controllers
{
	/// <summary>
	/// Default Home Controller
	/// </summary>
	public class HomeController : Controller
	{
		/// <summary>
		/// Default Index view
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			return View();
		}
	}
}
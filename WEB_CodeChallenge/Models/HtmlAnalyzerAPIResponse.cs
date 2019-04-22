using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_CodeChallenge.Models
{
	/// <summary>
	/// Response Object for the API response
	/// </summary>
	public class HtmlAnalyzerAPIResponse : IHtmlAnalyzerAPIResponse
	{
		public string UrlRequested { get; set; }

		public int TotalWordCount { get; set; }

		public IEnumerable<WordRanked> WordsRankedList { get; set; }

		public string[] ImagesSources { get; set; }

		public bool SuccessRequest { get; set; }

		public string Error { get; set; }
	}
}
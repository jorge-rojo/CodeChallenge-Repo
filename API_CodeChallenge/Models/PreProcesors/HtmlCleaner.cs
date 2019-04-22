using API_CodeChallenge.Interfaces;
using HtmlAgilityPack;
using System.Net;

namespace API_CodeChallenge.Models.PreProcesors
{
	/// <summary>
	/// Class Reponsible to Remove non needed Html elements in Html Document
	/// </summary>
	public class HtmlCleaner : IHtmlCleaner
	{
		/// <summary>
		/// Gets or Sets the Html Source Document
		/// </summary>
		public HtmlDocument HtmlSourceDoc { get; set; }

		/// <summary>
		/// Removes Encoded Html elements, Comments, etc. 
		/// </summary>
		/// <returns>Cleaner Version of the Html Document</returns>
		public HtmlDocument CleanHtml()
		{
			string htmlPureText = HtmlSourceDoc.ParsedText;

			htmlPureText = WebUtility.HtmlDecode(htmlPureText);

			htmlPureText = htmlPureText.Replace("\r\n", string.Empty);

			htmlPureText = htmlPureText.Replace("\n", string.Empty);

			HtmlSourceDoc.LoadHtml(htmlPureText);

			var commentNodes = HtmlSourceDoc.DocumentNode.SelectNodes("//comment()");

			foreach (var commentNode in commentNodes)
			{
				commentNode.ParentNode.RemoveChild(commentNode);
			}

			return HtmlSourceDoc;
		}
	}
}
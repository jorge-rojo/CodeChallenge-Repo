using API_CodeChallenge.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CodeChallenge.Models.Processors
{
	/// <summary>
	/// Image analyzer to process and get images from html based on src attribute
	/// </summary>
	public class ImageAnalyzer : IImageAnalyzer, IHtmlAnalyzer
	{
		public HtmlDocument HtmlSourceDoc { get; set; }

		public string WebSiteUrl { get; set; }

		/// <summary>
		/// Gets the images sources based on src attribute from Html Document
		/// </summary>
		/// <returns>Array with all image source urls</returns>
		public string[] GetImageSources()
		{
			var urls = HtmlSourceDoc.DocumentNode.Descendants("img")
											.Select(e => e.GetAttributeValue("src", null))
											.Where(s => !string.IsNullOrEmpty(s)).ToArray();

			if (urls.Length > 0)
			{
				//get the host
				Uri uri = new Uri(WebSiteUrl);
				string host = $"{uri.Scheme}://{uri.Host}";

				for (int i = 0; i < urls.Length; i++)
				{
					if (urls[i].StartsWith("/"))
						urls[i] = $"{host}{urls[i]}";
					

					if(urls[i].StartsWith("~"))
						urls[i] = $"{host}/{urls[i]}";
				}

				urls = urls.Distinct().ToArray();

				return urls;
			}

			return new string[0];
		}
	}
}
using API_CodeChallenge.Interfaces;
using API_CodeChallenge.Models;
using API_CodeChallenge.Models.PreProcesors;
using API_CodeChallenge.Models.Processors;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_CodeChallenge.Controllers
{
	/// <summary>
	/// API Controller
	/// </summary>
	public class UrlAnalyzerController : ApiController
	{
		/// <summary>
		/// Loads Url analyzes the Html for get the information needed
		/// </summary>
		/// <param name="url">Url to Analyze</param>
		/// <param name="clientSecret">For security purposes we need a client secret</param>
		/// <returns>Json object with word count word ranks and image gallery</returns>
		[HttpGet]
		public IHttpActionResult LoadUrl(string url, string clientSecret)
		{
			var passkeySetting = ConfigurationManager.AppSettings["passkey"];

			if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(clientSecret) || !clientSecret.Equals(passkeySetting))
				return BadRequest();

			//GET HTML
			var web = new HtmlWeb();

			var htmlDoc = web.Load(url);

			IHtmlCleaner htmlCleaner = new HtmlCleaner
			{
				HtmlSourceDoc = htmlDoc
			};

			htmlDoc = htmlCleaner.CleanHtml();

			IWordRankAnalyzer wordRankAnalyzer = new WordRankAnalyzer
			{
				HtmlSourceDoc = htmlDoc
			};

			var wordsRankedList = wordRankAnalyzer.RankWords();

			var totalWordCount = wordRankAnalyzer.TotalWordsInHtml;

			IImageAnalyzer imgAnalyzer = new ImageAnalyzer
			{
				WebSiteUrl = url,
				HtmlSourceDoc = htmlDoc
			};

			var imgSourceList = imgAnalyzer.GetImageSources();

			return Ok(new { UrlRequested = url, TotalWordCount = totalWordCount, WordsRankedList = wordsRankedList, ImagesSources = imgSourceList });
		}
	}
}

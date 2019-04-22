using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WEB_CodeChallenge.Models;

namespace WEB_CodeChallenge.Sevices
{
	/// <summary>
	/// Class responsible for the calls to the html analyzer API
	/// </summary>
	public class HtmlAnalyzerAPIImplementation
	{
		private static HttpWebRequest _apiWebRequest;

		private static readonly string _apiUrlEndpoint;

		private static readonly string _apiHost;

		private static readonly string _apiClientSecrect;

		static HtmlAnalyzerAPIImplementation()
		{
			_apiHost = ConfigurationManager.AppSettings["apiUrlHost"];

			_apiUrlEndpoint = ConfigurationManager.AppSettings["apiUrlEndpoint"];

			_apiClientSecrect = ConfigurationManager.AppSettings["apiClientSecret"];

		}

		/// <summary>
		/// Executes the Load Url method of the api
		/// </summary>
		/// <param name="url">url to analyze</param>
		/// <returns>Reponse object with all the information of word counts and images</returns>
		public IHtmlAnalyzerAPIResponse TryAnalyzeUrl(string url)
		{
			HtmlAnalyzerAPIResponse objectResponse = new HtmlAnalyzerAPIResponse();

			try
			{
				_apiWebRequest = WebRequest.CreateHttp($"{_apiHost}{_apiUrlEndpoint}?url={url}&clientSecret={_apiClientSecrect}");

				_apiWebRequest.Method = "GET";

				var webReponse = _apiWebRequest.GetResponse();

				var responseStream = webReponse.GetResponseStream();

				StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);

				string jsonTextObject = readStream.ReadToEnd();

				objectResponse = JsonConvert.DeserializeObject<HtmlAnalyzerAPIResponse>(jsonTextObject);

				objectResponse.SuccessRequest = true;


			}
			catch (Exception ex)
			{
				objectResponse.SuccessRequest = false;

				objectResponse.Error = ex.Message;
			}

			return objectResponse;
		}
	}
}
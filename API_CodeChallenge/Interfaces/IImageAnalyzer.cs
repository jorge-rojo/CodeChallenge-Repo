using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CodeChallenge.Interfaces
{
	/// <summary>
	/// Interface for an Image analyzer implementation, could be extended to various types
	/// </summary>
	public interface IImageAnalyzer : IHtmlAnalyzer
	{
		string WebSiteUrl { get; set; }

		string[] GetImageSources();
	}
}

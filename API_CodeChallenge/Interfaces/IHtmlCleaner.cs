using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CodeChallenge.Interfaces
{
	/// <summary>
	/// Html analyzer for clean up html based implementation
	/// </summary>
	public interface IHtmlCleaner : IHtmlAnalyzer
	{
		HtmlDocument CleanHtml();
	}
}

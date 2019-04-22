using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CodeChallenge.Interfaces
{
	/// <summary>
	/// Base Interface for any html analyzer
	/// </summary>
	public interface IHtmlAnalyzer
	{
		HtmlDocument HtmlSourceDoc { get; set; }
	}
}

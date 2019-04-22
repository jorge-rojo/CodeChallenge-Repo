using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CodeChallenge.Interfaces
{
	/// <summary>
	/// Word rank analyzer interface
	/// </summary>
	public interface IWordRankAnalyzer: IHtmlAnalyzer
	{
		int TotalWordsInHtml { get; set; }

		IEnumerable<IWordRanked> RankWords();
	}
}

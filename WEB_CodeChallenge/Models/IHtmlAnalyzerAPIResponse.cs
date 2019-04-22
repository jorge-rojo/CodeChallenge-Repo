using System.Collections.Generic;

namespace WEB_CodeChallenge.Models
{
	/// <summary>
	/// Interface for reponse from the API contract
	/// </summary>
	public interface IHtmlAnalyzerAPIResponse
	{
		string[] ImagesSources { get; set; }
		int TotalWordCount { get; set; }
		string UrlRequested { get; set; }
		IEnumerable<WordRanked> WordsRankedList { get; set; }
		bool SuccessRequest { get; set; }
		string Error { get; set; }
	}
}
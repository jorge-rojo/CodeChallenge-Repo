using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CodeChallenge.Interfaces
{
	/// <summary>
	/// Word Rank Interface implementation
	/// </summary>
	public interface IWordRanked
	{
		string Text { get; set; }

		int Occurrences { get; set; }
	}
}
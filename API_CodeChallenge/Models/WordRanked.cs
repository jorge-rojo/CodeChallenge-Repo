using API_CodeChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CodeChallenge.Models
{
	/// <summary>
	/// Representing class for word ranked
	/// </summary>
	public class WordRanked : IWordRanked
	{
		public string Text { get; set; }

		public int Occurrences { get; set; }
	}
}
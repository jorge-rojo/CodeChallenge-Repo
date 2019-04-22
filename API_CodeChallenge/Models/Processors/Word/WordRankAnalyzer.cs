using API_CodeChallenge.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace API_CodeChallenge.Models.Processors
{
	/// <summary>
	/// Class responsible for get words from html count them and rank them
	/// </summary>
	public class WordRankAnalyzer : IWordRankAnalyzer
	{
		public HtmlDocument HtmlSourceDoc { get; set; }

		public int TotalWordsInHtml { get; set; }

		/// <summary>
		/// Ranks all occurences of words in Html
		/// </summary>
		/// <returns>Ranked list of all words in html</returns>
		public IEnumerable<IWordRanked> RankWords()
		{
			var textNodes = HtmlSourceDoc.DocumentNode.SelectNodes("//body//text()");

			List<IWordRanked> wordRankedList = new List<IWordRanked>();

			List<string> arrayOfAllWords = new List<string>();

			if (textNodes.Count > 0)
			{
				Regex atLeastOneCharOneNumberRegex = new Regex("([a-zA-Z]|[0-9])");

				foreach (var textNode in textNodes)
				{
					if (!textNode.InnerText.All(c => c.Equals(' ')) &&
						!textNode.InnerText.All(c => c.Equals(string.Empty)) &&
						textNode.ParentNode.Name != "script" &&
						atLeastOneCharOneNumberRegex.IsMatch(textNode.InnerText))
					{
						var textArray = textNode.InnerText.Split(' ');

						foreach (var word in textArray)
						{
							if (!string.IsNullOrWhiteSpace(word) && atLeastOneCharOneNumberRegex.IsMatch(word))
							{
								string cleanWord = new string(word.Where(c => c == '\'' || c == '-' || !char.IsPunctuation(c)).ToArray());
								if (!string.IsNullOrEmpty(cleanWord))
								{
									arrayOfAllWords.Add(cleanWord.ToLower());
								}
							}
						}
					}
				}
			}

			if (arrayOfAllWords.Count > 0)
			{
				Dictionary<string, int> wordDictionary = arrayOfAllWords.GroupBy(x => x)
									  .ToDictionary(g => g.Key,
													g => g.Count());

				foreach (var wordDefinition in wordDictionary)
				{
					wordRankedList.Add(new WordRanked
					{
						Occurrences = wordDefinition.Value,
						Text = wordDefinition.Key
					});
				}

				wordRankedList = wordRankedList.OrderByDescending(w => w.Occurrences).ToList();

				TotalWordsInHtml = wordDictionary.Sum(x => x.Value);

				return wordRankedList;
			}

			return null;
		}
	}
}
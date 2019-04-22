using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_CodeChallenge.Sevices
{
	interface IHtmlAnalyzerAPIImplementation
	{
		Task TryAnalyzeUrl(string url);
	}
}

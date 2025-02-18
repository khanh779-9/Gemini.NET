using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemini.NET.Helpers
{
    public static class StringHelper
    {
        public static string EmbedHyperlinkForMarkdown(string str, int startIndex, int endIndex, string url)
        {
            string substring = str.Substring(startIndex, endIndex - startIndex + 1);
            string hyperlink = $"[{substring}]({url})";
            return string.Concat(str.AsSpan(0, startIndex), hyperlink, str.AsSpan(endIndex + 1));
        }
    }
}

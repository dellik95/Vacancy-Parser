using ParserVacancy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace ParserVacancy.Work
{
    class WorkParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("f-visited-enable"));
            foreach (var link in items)
            {
                if (!link.Attributes["href"].Value.Contains("zapros")&&(link.Attributes["href"].Value.Contains("vacancy")))
                {
                    list.Add(link.Attributes["href"].Value);
                }
                
            }
            return list.ToArray();
        }
       
    }
}

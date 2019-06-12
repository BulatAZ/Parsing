using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace ConsoleApp1.Core.Habra
{
    class HabraParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post_title-link"));
            var items2 = document.QuerySelectorAll("a").Where(item => item.ClassName != null);
            string dere = string.Empty;
            for(int i = 0; i < 20; i++)
            {
                foreach(var r in document.GetElementsByTagName("a"))
                {
                    dere += r.GetAttribute("href")+"/n";
                }
            }
            //var rt = document.GetElementsByTagName("a").Where(it => it.it.GetAttribute("href");
            //var tt = 

            foreach(var item in items)
            {
                list.Add(item.TextContent);
            }
            return list.ToArray();
        }
    }
}

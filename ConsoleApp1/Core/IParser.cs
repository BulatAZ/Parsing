
using AngleSharp.Html.Dom;

namespace ConsoleApp1.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document); 
    }
}

using AngleSharp.Html.Parser;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;      

        #region Properties
        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }
        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        
        #endregion

       
        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings):this(parser)
        {
            this.parserSettings = parserSettings;
        }

       
        public async void Worker()
        {                         
            var source = await loader.GetSource();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            var result = parser.Parse(document);
            Console.WriteLine(result);
           
        }
       
    }
}

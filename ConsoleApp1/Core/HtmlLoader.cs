using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = "https://yandex.ru";
        }

        public async Task<string> GetSource()
        {
            var currentUrl = url;

            var respose = await client.GetAsync(currentUrl);
            string source = string.Empty;
            if (respose != null && respose.StatusCode == HttpStatusCode.OK)
            {
                source = await respose.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}

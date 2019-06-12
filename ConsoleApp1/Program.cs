using AngleSharp.Html.Parser;
using ConsoleApp1.Core;
using ConsoleApp1.Core.Habra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        /*Разработать консольное приложение которое выполняет функции: 
    1.	Запрашивает у пользователя адрес страницы сайта
    2.	Скачивает исходный html этой страницы
    3.	Получает значения атрибута HREF первых 20  тегов A
    4.	Выводит в консоль полученные значения
    5.	Сохраняет в текстовый файл полученные значения*/

        static async Task Main(string[] args)
        {
            Console.WriteLine("Введите адрес страницы сайта:");
            //string urlAddress = Console.ReadLine();
            //string html = getHtml(urlAddress);
            string BaseUrl = "http://yandex.ru";

            HttpClient client = new HttpClient();

            var respose = await client.GetAsync(BaseUrl);
            string source = string.Empty;
            if (respose != null && respose.StatusCode == HttpStatusCode.OK)
            {
                source = await respose.Content.ReadAsStringAsync();
            }

            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);

            var items2 = document.QuerySelectorAll("a").Where(item => item.ClassName != null);
            string result = string.Empty;
            for (int i = 0; i < 20; i++)
            {
                foreach (var r in document.GetElementsByTagName("a"))
                {
                    result += r.GetAttribute("href") + "\n";
                }
            }
            Console.WriteLine(result);


            Console.WriteLine("Finish");
            Console.Read();
        }

        public static string getHtml(string urlAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

                return data;
            }
            return null;
        }
    }
}

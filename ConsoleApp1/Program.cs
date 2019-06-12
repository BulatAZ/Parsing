using AngleSharp.Html.Parser;
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
            Console.WriteLine("Введите адрес страницы сайта:  (например: https://navicongroup.ru)\n");

            string urlAddress = string.Empty;
            while (true)
            {
                urlAddress = Console.ReadLine();
                if(urlAddress != string.Empty)
                {
                    break;                    
                }
                Console.WriteLine("Вы ввели пустую строку, попробуйте еще раз:\n");
            }                     

            HttpClient client = new HttpClient();
            var respose = await client.GetAsync(urlAddress);
            string source = string.Empty;
            if (respose != null && respose.StatusCode == HttpStatusCode.OK)
            {
                source = await respose.Content.ReadAsStringAsync();
            }

            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(source);
            int countOfReading = 20;
            string result = $"Значение первых {countOfReading} атрибутов HREF тега 'А' для сайта: {urlAddress}\n";
            int i = 1;
            foreach (var r in document.GetElementsByTagName("a"))
            {
                result += i + ") " + r.GetAttribute("href") + "\n";
                i++;
                if (i > countOfReading)
                {
                    break;
                }
            }
            
            Console.WriteLine(result);
            WriteToFile(result);

            Console.Read();
        } 
        
        public static void WriteToFile(string data)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "result.txt");
            try
            {              
             using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(data);                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

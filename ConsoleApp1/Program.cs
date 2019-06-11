using System;
using System.Collections.Generic;
using System.Linq;
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

        static void Main(string[] args)
        {
            Console.WriteLine("Введите адрес страницы сайта:");
            string siteAddress = Console.ReadLine();

            Console.Read();
        }
    }
}

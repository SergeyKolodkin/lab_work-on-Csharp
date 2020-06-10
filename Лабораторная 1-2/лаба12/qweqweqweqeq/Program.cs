using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using laba1;

namespace qweqweqweqeq
{
    class Program
    {
        static void Main(string[] args)
        {
            string s_year, s_count, s_sales; ;
            Print lab1=new Print();

            Console.WriteLine("Введите имя издания:");
            lab1.Name = Console.ReadLine();

            Console.WriteLine("Введите имя автора:");
            lab1.Author = Console.ReadLine();
            
            Console.WriteLine("Введите год издания:");
            s_year = Console.ReadLine();
            while (!lab1.Add_year(s_year))
            {
                Console.WriteLine("Ошибка. Повторите ввод года издания:");
                s_year = Console.ReadLine();

            }

            Console.WriteLine("Введите тираж издания:");
            s_count = Console.ReadLine();
            while (!lab1.Add_count(s_count))
            {
                Console.WriteLine("Ошибка. Повторите ввод тиража издания:");
                s_count = Console.ReadLine();
            }

            Console.WriteLine("Введите кол-во проданного:");
            s_sales = Console.ReadLine();
            while (!lab1.Add_sales(s_sales))
            {
                Console.WriteLine("Ошибка. Повторите ввод кол-во проданного:");
                s_sales = Console.ReadLine();
            }

            Console.WriteLine("Издание: " + lab1.Name + "\nавтор:" + lab1.Author + "\nгод издания: " + lab1.Year + "\nтираж: " + lab1.Count + "\nпродано: " + lab1.Sales);




            Console.ReadKey();
        }
    }
}

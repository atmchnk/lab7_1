/*Завдання.
  У текстовому файлі міститься математичний вираз. Перевірити баланс круглих дужок
  у даному виразі, використовуючи стек. 
  Вміст файлу: (1+2)-4*(a-3)/(2-7+6).

  Перевірити роботу програми при різному вмісті файлу.*/

using System;
using System.Collections;
using System.IO;

namespace lab7_1
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            try
            {
                //lab7_1/bin/Debug/netcoreapp3.1 - місцезнаходження у папці з проектом файлу "text.txt"
                StreamReader fileIn = new StreamReader("text.txt");
                string line = fileIn.ReadToEnd();
                fileIn.Close();

                Stack parentheses = new Stack(); //cтек дужок
                bool flag = true; //перевірка балансу дужок  
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '(') //якщо поточний символ - це відкриваюча дужка 
                        parentheses.Push(i); //поміщуємо її в стек

                    else if (line[i] == ')') //якщо поточний символ - це закриваюча дужка
                    {
                        if (parentheses.Count == 0) /*якщо стек порожній, то для закриваючої дужки
                                         не вистачає пари - відкриваючої дужки*/
                        {
                            flag = false;
                            Console.WriteLine("Можливо в позиції " + i + " зайва ) дужка");
                        }
                        else parentheses.Pop(); //інакше витягуємо парну дужку    
                    }
                }

                if (parentheses.Count == 0) //якщо після перегляду рядка стек порожній
                {
                    if (flag)
                        Console.WriteLine("Дужки у виразі збалансовані"); //дужки збалансовані
                }

                else //якщо порушений баланс дужок  
                {
                    Console.Write("Можливо зайва ( дужка в позиції: ");

                    while (parentheses.Count != 0)
                    {
                        Console.Write("{0} ", (int)parentheses.Pop());
                    }
                    Console.WriteLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Файл неможливо відкрити. Перевірте його наявність у проекті");
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Пустий файл");
            }
        }
    }
}

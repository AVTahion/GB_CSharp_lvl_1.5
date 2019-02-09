using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/* 1)   Создать программу, которая будет проверять корректность ввода логина.Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        а) без использования регулярных выражений;
        б) ** с использованием регулярных выражений.
   2)   Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
        а) Вывести только те слова сообщения,  которые содержат не более n букв.
        б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        в) Найти самое длинное слово сообщения.
        г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        д) *** Создать метод, который производит частотный анализ текста.В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.Здесь требуется использовать класс Dictionary.


   3)   *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        Например:
        badc являются перестановкой abcd.
   4)   *Задача ЕГЭ.
        На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
        <Фамилия> <Имя> <оценки>,
        где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и<Имя>, а также <Имя> и<оценки> разделены одним пробелом. Пример входной строки:
        Иванов Петр 4 5 3
        Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
        Достаточно решить 2 задачи.Старайтесь разбивать программы на подпрограммы.Переписывайте в начало программы условие и свою фамилию. Все программы сделать в одном решении. Для решения задач используйте неизменяемые строки (string)
*/

namespace GB_CSharp_lvl_1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int loginMin = 2;
            int loginMax = 10;
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            bool loginIn = LoginCheck(login, loginMin, loginMax);
            if (loginIn)
            {
                Console.WriteLine("Логин корректен");
            }
            else
            {
                Console.WriteLine("Введен некорректный логин");
            }
            Console.WriteLine();
            loginIn = LoginCheckRegex(login);
            if (loginIn)
            {
                Console.WriteLine("Логин корректен");
            }
            else
            {
                Console.WriteLine("Введен некорректный логин");
            }
            Console.ReadLine();

            //Console.WriteLine("Введите текст:");
            //string text = Console.ReadLine();
            //Message.WordsSmallerN(text, 4);

            //Console.WriteLine("Введите текст:");
            //string text = Console.ReadLine();
            //char x = 'a';
            //text = Message.DelitX(text, x);
            //Console.WriteLine(text);
            //Console.ReadLine();

            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            Console.WriteLine($"Самое длинное слово в тексте:{Message.LongestWord(text)}");
            Console.ReadLine();

        }

        /// <summary>
        /// Метод проверки логина без регулярного выражения
        /// </summary>
        /// <param name="login">Проверяемый логин</param>
        /// <param name="loginMin">Минимальное кол-во символов в логине</param>
        /// <param name="loginMax">Максимальное кол-во символов в логине</param>
        /// <returns></returns>
        private static bool LoginCheck(string login, int loginMin, int loginMax)
        {
            if (login.Length > loginMax || login.Length < loginMin) return false;
            char[] loginArr = login.ToCharArray();
            if (Char.IsDigit(loginArr[0])) return false;
            bool x = false; 
            foreach (char i in loginArr)
            {
                if (char.IsDigit(i) || char.IsLetter(i)) x = true;
                else x = false;
            }
            return x;
        }


        /// <summary>
        /// Метод проверки логина по регулярному выражению
        /// </summary>
        /// <param name="login">Проверяемый логин</param>
        /// <returns></returns>
        private static bool LoginCheckRegex(string login)
        {
           return Regex.IsMatch(login, @"\b[a-zA-Zа-яА-Я][a-zA-Z0-9а-яА-Я]{1,9}\b");
        }
    }
}

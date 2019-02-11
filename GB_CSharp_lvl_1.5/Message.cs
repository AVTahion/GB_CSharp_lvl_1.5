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
    /// <summary>
    /// Класс содержит методы обработки текста
    /// </summary>
    internal static class Message
    {
        /// <summary>
        /// Метод выводит слова сообщения,  которые содержат не более n букв
        /// </summary>
        /// <param name="text">Входящий текст</param>
        /// <param name="n">Макс кол-во букв в слове</param>
        internal static void WordsSmallerN(string text, int n)
        {
            StringBuilder textA = new StringBuilder(text);
            for (int i = 0; i < textA.Length;)
                if (char.IsPunctuation(textA[i])) textA.Remove(i, 1);
            else ++i;
            string x = textA.ToString();
            string[] textArr = x.Split(' ');
            for (int i = 0; i < textArr.Length; ++i)
                if (textArr[i].Length < n)
                {
                    Console.WriteLine(textArr[i]);
                }
        }

        /// <summary>
        /// Метод удаляет из сообщения все слова, которые заканчиваются на заданный символ.
        /// </summary>
        /// <param name="text">Входящее сообщение</param>
        /// <param name="X"></param>
        /// <returns></returns>
        internal static string DelitX (string text, char X)
        {
            string[] textArr = text.Split(' ');
            string result = "";
            Regex pattern = new Regex($"{X}\\b");
            for (int i = 0; i < textArr.Length; ++i)
            {
                if (pattern.IsMatch(textArr[i])) Array.Clear(textArr, i, 1);
                result += textArr[i] + ' ';
            }
            text.Trim();
            return result;
        }

        /// <summary>
        /// Метод возвращающий самое длинное слово сообщения.
        /// </summary>
        /// <param name="text">Входящее сообщение</param>
        /// <returns>Самое длинное слово в сообщении</returns>
        internal static string LongestWord (string text)
        {
            StringBuilder textA = new StringBuilder(text);
            for (int i = 0; i < textA.Length;)
                if (char.IsPunctuation(textA[i])) textA.Remove(i, 1);
                else ++i;
            text = textA.ToString();
            string[] textArr = text.Split(' ');
            string result = textArr[0];
            for (int i = 0; i < textArr.Length; ++i)
            {
                if (result.Length < textArr[i].Length) result = textArr[i];
            }
            return result;
        }
    }
}

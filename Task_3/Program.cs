using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  3) * Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
         Например:
         badc являются перестановкой abcd.

    Александр Кушмилов
*/
         
namespace Task_3
{
    class Program
    {
        public static bool CheckEquals(string s1, string s2)
        {
            bool result = false;
            char[] chArray1 = s1.ToCharArray();
            char[] chArray2 = s2.ToCharArray();
            Array.Sort(chArray1);
            Array.Sort(chArray2);
            string sr1 = new string (chArray1);
            string sr2 = new string (chArray2);
            return result = sr1.Equals(sr2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку:");
            string s1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string s2 = Console.ReadLine();
            Console.WriteLine((CheckEquals(s1, s2)) ? $"Строка {s1} является перестановкой {s2}" : $"Строка {s1} не является перестановкой {s2}");
            Console.ReadKey();
        }
    }
}

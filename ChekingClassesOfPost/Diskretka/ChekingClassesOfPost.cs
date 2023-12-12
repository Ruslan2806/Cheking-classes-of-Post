using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Diskretka
{
    public class ChekingClassesOfPost
    {
        static void Main(string[] args)
        {
            Console.WriteLine("## ПРОВЕРКА ПРИНАДЛЕЖНОСТИ ФУНКЦИИ КЛАССАМ ПОСТА ##");
            Console.WriteLine("P.S. Программа поддерживает до 10 переменных");
            while (true)
            {
                (string s, int a) = ReadFunc();
                string[] s1 = GenOfAllComb(a);
                Console.WriteLine($" _______________________________");
                Console.WriteLine($"|      |      |     |     |     | ");
                Console.WriteLine($"|  P0  |  P1  |  S  |  M  |  L  |");
                Console.WriteLine($"|______|______|_____|_____|_____| ");
                Console.WriteLine($"|      |      |     |     |     | ");
                Console.WriteLine($"|  {PrintPlus(ClassP0(s))}   |  {PrintPlus(ClassP1(s))}   |  {PrintPlus(ClassS(s))}  |  {PrintPlus(ClassM(s1, s))}  |  {PrintPlus(ClassL(s1, s, a))}  |");
                Console.WriteLine($"|______|______|_____|_____|_____| \n");
                Console.WriteLine("Хотите продолжить? да - 1 нет - любой набор символов");
                string h = Console.ReadLine();
                if (h == "1") continue;
                else Environment.Exit(0);
            }
        }
        public static bool[] returnClassesOfPost(string str)
        {
            bool[] result = new bool[5];
            (string s, int a) = ReadFunc(str);
            string[] s1 = GenOfAllComb(a);
            result[0]= ClassP0(s);
            result[1] = ClassP1(s);
            result[2] = ClassS(s);
            result[3] = ClassM(s1, s);
            result[4] = ClassL(s1, s, a);
            for (int i = 0; i < 5; i++)
                Console.Write($"|  {result[i]} ");
            return result;
        }

        public static bool AreEqualArayBool(bool[] a, bool[] b)
        {
            bool result = true;
            for (int i = 0; i < a.Length; i++ )
            {
                if (a[i] != b[i])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        static (string s, int a) ReadFunc(string str)
        {
            var result = (s: "", a: 0);
            string fString = str;
            int l = fString.Length;
            double d = l;
            int d1 = l;
            while (d > 1) d = d / 2;
            int f = 0;
            for (int i = 0; i < l; i++)
            {
                if (fString[i] == ('1')) f++;
                else if (fString[i] == ('0')) f++;
            }
            if (d == 1 & f == l)
            {
                int n = 0;
                while (d1 != 1)
                {
                    d1 = d1 / 2;
                    n++;
                }
                result.s = fString;
                result.a = n;

            }
            return result;
        }
        //Функция, считывающая eval(f)
        static (string s, int a) ReadFunc()
        {
            var result = (s: "", a: 0);
            while (true)
            {
                Console.Write("\nВведите значение eval(f): ");
                string fString = Console.ReadLine().Trim();
                int l = fString.Length;
                double d = l;
                int d1 = l;
                while (d > 1) d = d / 2;
                int f = 0;
                for (int i = 0; i < l; i++)
                {
                    if (fString[i] == ('1')) f++;
                    else if (fString[i] == ('0')) f++;
                }
                if (d == 1 & f == l)
                {
                    int n = 0;
                    while (d1 != 1)
                    {
                        d1 = d1 / 2;
                        n++;
                    }
                    result.s = fString;
                    result.a = n;
                    break;
                }
                else Console.Write("Ошибка! Введите значение функции снова:\n");
            }
            return result;
        }
        static char PrintPlus(bool a)
        {
            if (a == true) return '+';
            else if (a == false) return '-';
            return '!';
        }

        // Функция, генерирующая все комбинации из "0" и "1"
        static string[] GenOfAllComb(int c)
        {
            string[] result = new string[(int)Math.Pow(2, c)];
            for (int i = 0; i < result.Length; i++)
            {
                string binaryNumber = Convert.ToString(i, 2);
                if (binaryNumber.Length != c)
                    while (binaryNumber.Length < c)
                        binaryNumber = "0" + binaryNumber;
                result[i] = binaryNumber;
            }
            return result;
        }

        //Функция, печатающая массив строк
        static void PrintArr(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
                Console.WriteLine(s[i]);
        }

        //Функция, проверяющая принадлежит ли булева функция f к классу P0
        static bool ClassP0(string a)
        {
            if (a[0] == '0') return true;
            else return false;
        }


        //Функция, проверяющая принадлежит ли булева функция f к классу P1
        static bool ClassP1(string a)
        {
            if (a[a.Length - 1] == '1') return true;
            else return false;
        }

        //Функция, проверяющая принадлежит ли булева функция f к классу S
        static bool ClassS(string a)
        {
            string a1 = a;
            string a2 = "";
            string a3 = "";
            for (int i = a1.Length - 1; i >= 0; i--)
                a3 += a1[i];
            for (int i = 0; i < a3.Length; i++)
                if (a3[i] == '1') a2 += '0';
                else a2 += '1';
            var result = true;
            for (int i = 0; i < a2.Length; i++)
                if (a2[i] != a[i])
                {
                    result = false;
                    break;
                }
            return result;
        }

        //Функция, проверяющая принадлежит ли булева функция f к классу M
        static bool ClassM(string[] ss, string s)
        {
            var result = true;
            bool flag = false;
            for (int i = 0; i < ss.Length - 1; i++)
            {
                if (flag == true) break;
                for (int j = i + 1; j < ss.Length; j++)
                {
                    (string ss1, string ss2) = (ss[i], ss[j]);
                    (char s1, char s2) = (s[i], s[j]);
                    var c = true;
                    for (int k = 0; k < ss1.Length; k++)
                        if (ss1[k] == '1' & ss2[k] == '0')
                        {
                            c = false;
                            break;
                        }
                    if ((c == true) & (s1 == '1') & (s2 == '0'))
                    {
                        result = false;
                        flag = true;
                        break;
                    }
                }
            }
            return result;
        }

        //Операция XOR
        static char XOR(char a1, char a2)
        {
            if (a1 == a2) return '0';
            else return '1';
        }

        //Функция, проверяющая принадлежит ли булева функция f к классу S
        static bool ClassL(string[] ss, string s, int k)
        {
            char[] a = new char[k + 1];
            a[0] = s[0];
            for (int i = 1; i < ss.Length; i++) //нахождение линейных коэффициентов
            {
                var str = ss[i];
                int countOnes = 0;
                foreach (char c in str)
                    if (c == '1') countOnes++;
                if (countOnes == 1)
                {
                    var Ind = str.IndexOf('1') + 1;
                    a[Ind] = '1';
                    if (XOR(a[Ind], a[0]) != s[i]) a[Ind] = '0';
                }
            }
            string s1 = "";
            for (int i = 0; i < ss.Length; i++)
            {
                char eval = a[0];
                var str = ss[i];
                for (int j = 0; j < str.Length; j++)
                    if (a[j + 1] == '1') eval = XOR(eval, str[j]);
                s1 += eval;
            }
            if (s1 == s) return true;
            else return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LFSR;

namespace LSFR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            String text = "";
            String key = "10001110101011101110000111";
            String tmpkey = "";

            Console.WriteLine("***********************************************************");
            Console.WriteLine("***                                                     ***");
            Console.WriteLine("***     Регістр зсуву з лінійним зворотнім зв'язком     ***");
            Console.WriteLine("*** Роботу виконала студентка групи КН-22 Родчин Тетяна ***");
            Console.WriteLine("***                                                     ***");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Примітка: шифруємо й дешифруємо мовою міжнародного спілкування ;)");
            Console.WriteLine("Текст, який будемо шифрувати: ");
            using (StreamReader sr = new StreamReader("in.txt"))
            {
                text = sr.ReadToEnd();
            }
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("Введіть довільний початковий стан регістра з 0 та 1: \n" +
                "Послідовність має складатись як мінімум з 26 символів \n" +
                "Або, якщо лінь, то введіть зірочку, і ключ підбереться автоматично =) ");
            tmpkey = Console.ReadLine();
            if (tmpkey.Length < 26) tmpkey = key;
            lfsr t1 = new lfsr(text, 0, tmpkey);
            Console.WriteLine();
            
            Console.WriteLine($"Введений текст: {t1.cleanText}");
            Console.WriteLine();
            Console.WriteLine($"Початковий стан регістра: {t1.key}");
            Console.WriteLine();
            Console.WriteLine($"Введений текст, перетворений у двійковий формат: {t1.textKey}");
            Console.WriteLine();
            Console.WriteLine($"Псевдовипадкова послідовність: {t1.randomKey}");
            Console.WriteLine();
            Console.WriteLine($"Отримана зашифрована послідовність: {t1.encryptedText}");
            Console.WriteLine();
            Console.WriteLine($"Розшифрований текст: {t1.decryptedText}");
            Console.WriteLine();

            using (StreamWriter sw = new StreamWriter("out.txt", false, Encoding.ASCII))
            {
                sw.WriteLine(t1.encryptedText);
            }

            Console.Read();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Tree
{
    public class ConsoleWork
    {
        public Tree tr;
        public ConsoleWork(Tree tr) { this.tr = tr; }
        public void DoCommand(string exec)
        {
            var e = exec.Split(' ');
            string command = e[0];
            switch(command)
            {
                case "enter":
                    try
                    {
                        exec = exec.Remove(0, e[0].Length + 1);
                        tr.Enter(exec);
                    } catch(Exception ex)
                    {
                        Console.WriteLine("Something went wrong");
                    }
                    break;
                case "vars":
                        tr.Vars();
                    break;
                case "print":
                    tr.Print(false);
                    Console.WriteLine(tr.getPlnote());
                    break;
                case "comp":
                    if (exec.Length == 4) exec = "";
                    else
                        exec = exec.Remove(0, e[0].Length + 1);
                    tr.Comp(exec);
                    break;
                case "join":
                    try
                    {
                        exec = exec.Remove(0, e[0].Length + 1);
                    tr.Join(exec);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Something went wrong");
                    }
                    break;
                case "clear":
                    tr.Clear();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Tree tr = new Tree();
            ConsoleWork cw = new ConsoleWork(tr);
            string exec = "";
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("Команди, які можна ввести в консолі: ");
            Console.WriteLine("1) enter <formula> - створення дерева на основі виразу в польському записі");
            Console.WriteLine("2) print - виведення дерева в вигляді польського запису");
            Console.WriteLine("3) vars - виведення змінних, що присутні в дереві");
            Console.WriteLine("4) comp <var1> <var2> ... <varN> обчислення виразу в дереві при заданих значеннях змінних");
            Console.WriteLine("5) join <formula> - додавання до поточного дерева іншого дерева");
            Console.WriteLine("6) clear - видалення дерева");
            Console.WriteLine("7) exit - вихід з програми");
            Console.WriteLine("Примітка - значення в формулах потрібно вводити через пробіл.");
            Console.WriteLine("****************************************************************************");

            for (; ; )
            {
                Console.Write(">");
                exec = Console.ReadLine();
                cw.DoCommand(exec);
            }
        }
    }
}

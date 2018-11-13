using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrix
{
    class Execution
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            MatrixHolder mh = new MatrixHolder();
            Console.WriteLine("Список команд \n");
            Console.WriteLine("**************************************************\n");
            Console.WriteLine("1) addmat dim size1 size2 ... sizeN def name - для додання нової матриці");
            Console.WriteLine("\t dim - к-сть вимірів, size1...sizeN - розмірності вимірів, def - значення за замовчуванням, name - назва матриці");
            Console.WriteLine("2) list - виводить список матриць");
            Console.WriteLine("3) print N - виводить інформацію про матрицю під номером N");
            Console.WriteLine("4) rename N newname - змінює ім'я матриці під номером N на задане");
            Console.WriteLine("5) clone N - копіює матрицю під номером N і додає її в кінець списку");
            Console.WriteLine("7) def N  c1 c2 ... cn val - записує в клітинку матриці під номером N з координатами c1..cn значення val");
            Console.WriteLine("8) del N - видаляє матрицю під номером N");
            Console.WriteLine("9) delall - очищує весь список матриць");
            Console.WriteLine("10) help - завантаження прикладу роботи програми");
            Console.WriteLine("11) вихід\n");
            Console.WriteLine("**************************************************\n");

            string command;
            ConsoleCommands cm = new ConsoleCommands(mh);
            for(; ; )
            {
                Console.Write(">");
                command = Console.ReadLine();
                ConsoleCommands.DoCommand(command);
            }

        }
    }
}

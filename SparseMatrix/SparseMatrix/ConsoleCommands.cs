using System;

namespace SparseMatrix
{
    //клас для зчитування консольних команд та їх виконання
    public class ConsoleCommands
    {
        public static MatrixHolder mHolder;
        public ConsoleCommands(MatrixHolder holder) {mHolder = holder; }

        public static void DoCommand(string command)
        {
            var c = command.Split(' ');
            string exec = c[0];

            string args;
            int pos;
            switch(exec)
            {
                case "addmat" :
                    char[] useless = { 'a', 'd', 'm', 'a', 't', ' ' };
                    args = command.TrimStart(useless);
                    mHolder.AddMat(args);
                    break;

                case "list" :
                    mHolder.List();
                    break;

                case "del":
                    char[] useless1 = { 'd', 'e', 'l', ' '};
                    args = command.TrimStart(useless1);
                    Int32.TryParse(args, out pos);
                    mHolder.Del(pos);
                    break;

                case "delall":
                    mHolder.DelAll();
                    break;

                case "rename":
                    char[] useless5 = { 'r', 'e', 'n', 'a', 'm', 'e', ' ' };
                    args = command.TrimStart(useless5);
                    mHolder.Rename(args);
                    break;

                case "def":
                    char[] useless2 = { 'd', 'e', 'f', ' ' };
                    args = command.TrimStart(useless2);
                    mHolder.Def(args);
                    break;

                case "print":
                    char[] useless3 = { 'p', 'r', 'i', 'n', 't', ' '};
                    args = command.TrimStart(useless3);
                    Int32.TryParse(args, out pos);
                    mHolder.Print(pos);
                    break;

                case "clone":
                    char[] useless4 = { 'c', 'l', 'o', 'n', 'e', ' ' };
                    args = command.TrimStart(useless4);
                    Int32.TryParse(args, out pos);
                    mHolder.CloneMatrix(pos);
                    break;

                case "help":
                    mHolder.Example();
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Something went wrong, try again");
                    break;

            }
        }
    }
}

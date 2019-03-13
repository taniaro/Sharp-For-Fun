using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLib;

namespace BankProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank<Account> myBank = new Bank<Account>("Beta Bank");
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("1. Open account \t 2. Withdraw from account  \t 3. Put money on account");
                Console.WriteLine("4. Close account \t 5. Day++  \t 6. Account information \t 7. Exit");
                Console.WriteLine("Action: ");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            ConsoleWork.OpenAccount(myBank);
                            break;
                        case 2:
                            ConsoleWork.WithdrawFromAccount(myBank);
                            break;
                        case 3:
                            ConsoleWork.ReceiveOnAccount(myBank);
                            break;
                        case 4:
                            ConsoleWork.CloseAccount(myBank);
                            break;
                        case 5:
                            break;
                        case 6:
                            ConsoleWork.ShowAccount(myBank);
                            break;
                        case 7:
                            alive = false;
                            continue;
                    }
                    myBank.CalculatePercentage();
                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }

        }
    }
}

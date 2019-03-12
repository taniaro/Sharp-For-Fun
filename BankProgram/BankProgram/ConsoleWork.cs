using BankLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgram
{
    static class ConsoleWork
    {
        public static void OpenAccount(Bank<Account> bank)
        {
            Console.WriteLine("Start sum: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Account type:\n1. Demand account\n2. Deposit account");
            int type = Convert.ToInt32(Console.ReadLine());
            AccountType accountType;
            if (type == 1)
                accountType = AccountType.Demand;
            else if (type == 2)
                accountType = AccountType.Deposit;
            else return;

            bank.Open(
                accountType,
                sum,
                0,
                WorkWithAccountHandler, //for console I will use only one type of handler
                WorkWithAccountHandler,
                WorkWithAccountHandler,
                WorkWithAccountHandler,
                WorkWithAccountHandler);
        }

        public static void WithdrawFromAccount(Bank<Account> bank)
        {
            Console.WriteLine("Account's id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sum to withdraw: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            bank.Withdraw(sum, id);
        }

        public static void ReceiveOnAccount(Bank<Account> bank)
        {
            Console.WriteLine("Account's id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sum to receive: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            bank.Withdraw(sum, id);
        }

        public static void CloseAccount(Bank<Account> bank)
        {
            Console.WriteLine("Account's id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bank.Close(id);
        }


        private static void WorkWithAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    public interface IAccount
    {
        //Receive money on account
        void Receive(decimal sum);
        //Withdraw money from account
        decimal Withdraw(decimal sum);
    }
}

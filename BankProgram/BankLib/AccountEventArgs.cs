using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    //for creation of the events
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);

    //for events' processing
    public class AccountEventArgs
    {
        public string Message { get; private set; }
        public decimal Sum { get; private set; }

        public AccountEventArgs(string Message, decimal Sum)
        {
            this.Message = Message;
            this.Sum = Sum;
        }
    }
}

using System.Diagnostics;

namespace BankLib
{
    public abstract class Account
    {
        //event that occurs when withdrawing money
        protected internal event AccountStateHandler Withdrawed;

        //event that happens when receiving money
        protected internal event AccountStateHandler Received;

        //event that happens when opening account
        protected internal event AccountStateHandler Opened;

        //event that occurs when closing account
        protected internal event AccountStateHandler Closed;

        //event that occurs when calculating the interest of the deposit
        protected internal event AccountStateHandler PercentageCalculated;

        //event that occurs when we want to see information about account
        protected internal event AccountStateHandler InfoShowing;

        protected int id; //account's id
        static int counter; //for id calculation
        private bool isDeposit;

        protected decimal sum; //sum on account
        protected float percentage;
        protected int days;//time from account's opening

        public Account(decimal sum, float percentage)
        {
            this.sum = sum;
            this.percentage = percentage;
            if (percentage != 0)
                isDeposit = true;
            ++counter;
            id = counter.GetHashCode();
        }

        public decimal Sum { get => sum; private set => sum = value; }
        public float Percentage { get => percentage; private set => percentage = value; }
        public int Id { get => id; }


        // if (handler != null && e!=null)
        //event calling
        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if(e != null)
                handler?.Invoke(this, e);
        }

        //methods for raising of all events
        protected virtual void OnOpen(AccountEventArgs e) => CallEvent(e, Opened);
        protected virtual void OnClose(AccountEventArgs e) => CallEvent(e, Closed);
        protected virtual void OnReceive(AccountEventArgs e) => CallEvent(e, Received);
        protected virtual void OnWithdraw(AccountEventArgs e) => CallEvent(e, Withdrawed);
        protected virtual void OnPercentageCalculated(AccountEventArgs e) 
            => CallEvent(e, PercentageCalculated);
        protected virtual void OnInfoShowed(AccountEventArgs e) => CallEvent(e, InfoShowing);

        //receiving money
        public virtual void Receive(decimal sum)
        {
            Debug.Assert(sum > 0);
            Sum += sum;
            OnReceive(new AccountEventArgs(
                $"You received ${sum} on account {Id}, balance: ${Sum}", sum));   
        }

        //withdrawing money
        public virtual decimal Withdraw(decimal sum)
        {
            decimal res = 0;

            if(sum < Sum)
            {
                Sum -= sum;
                res = sum; 
                OnWithdraw(new AccountEventArgs(
                    $"You withdrawed ${sum} from account {Id}, balance: ${Sum}", sum));
            }
            else
            {
                OnWithdraw(new AccountEventArgs(
                    $"You don't have enough money on your account {Id} for operation, " +
                        $"balance: ${Sum}", 0));
            }
            return res;
        }

        //opening account
        //change to protected internal
        public virtual void Open()
        {
            OnOpen(new AccountEventArgs(
                $"New account {Id} opened. Current sum: ${Sum}", Sum));
        }

        //closing account
        //change to protected internal
        public virtual void Close()
        {
            OnClose(new AccountEventArgs(
                $"Account {Id} is closed. Sum: {Sum}", Sum));
        }

        //show info about account
        public virtual void ShowInfo()
        {
            OnInfoShowed(new AccountEventArgs(
                $"Id: {Id}, Balance: {Sum}", 0));
        }

        protected internal void DaysIncrement() => days++;

        //calculating of account's interest
        protected internal virtual void CalculatePercentage()
        {
            if (isDeposit)
            {
                decimal inc = Sum * (decimal)Percentage / 100;
                Sum = Sum + inc;
                OnPercentageCalculated(new AccountEventArgs(
                    $"Your interest of account {Id} is accured, balance: ${Sum}", inc));
            }
        }     
    }
}
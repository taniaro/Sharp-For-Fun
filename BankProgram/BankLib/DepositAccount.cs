namespace BankLib
{
    public class DepositAccount : Account
    {
        //deposit account has a period, for example 30 days
        public readonly int PERIOD;

        public DepositAccount(decimal sum, float percentage, int period) 
            : base(sum, percentage) => PERIOD = period;

        protected internal override void Open()
        {
            base.OnOpen(new AccountEventArgs(
                $"New account {Id} opened. Current sum: ${Sum}", Sum));
        }

        public override void Receive(decimal sum)
        {
            if(days%PERIOD == 0)
            {
                base.Receive(sum);
            }
            else
            {
                base.OnReceive(new AccountEventArgs(
                    $"You can put money on your account {Id} only after {PERIOD}-days period." + 
                        $"Balance: {Sum}", 0));
            }
        }

        public override decimal Withdraw(decimal sum)
        {
            if(days%PERIOD == 0)
            {
                base.Withdraw(sum);
            }
            else
            {
                base.OnWithdraw(new AccountEventArgs(
                    $"You can withdraw money from account {Id} only after {PERIOD}-days period." +
                        $" Balance: {Sum}", 0));
            }

            return sum;
        }

        protected internal override void CalculatePercentage()
        {
            if(days%PERIOD == 0)
            {
                base.CalculatePercentage();
            }
        }
    }
}
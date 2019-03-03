namespace BankLib
{
    public class Account
    {
        //event that occurs when withdrawing money
        protected internal event AccountStateHandler Withdrawed;

        //event that happens when receiving money
        protected internal event AccountStateHandler Received;

        //event that occurs when closing account
        protected internal event AccountStateHandler Closed;

        //event that occurs when calculating the interest of the deposit
        protected internal event AccountStateHandler PercentageCalculated;

        protected int id; //account's id
        static int counter; //for id calculation

        protected decimal sum; //sum on account
        protected float percentage;
        protected int days;//time from account's opening

        public Account(decimal sum, float percentage)
        {
            this.sum = sum;
            this.percentage = percentage;
            id = ++counter;
        }

        public decimal Sum { get => sum; }
        public float Percentage { get => percentage; }
        public int Id { get => id; }

        
    }
}
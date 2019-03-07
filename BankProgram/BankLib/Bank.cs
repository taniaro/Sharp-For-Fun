namespace BankLib
{
    public enum AccountType
    {
        Demand,
        Deposit
    }

    public class Bank<T> where T : Account
    {
        //list of all accounts in bank
        List<T> accounts;
        //name of the bank
        public string Name {get; private set;}
        public Bank(string Name)
        {
            this.Name = Name;
            accounts = new List<T>();
        }

        //account's opening
        public void Open(AccountType accountType, decimal sum,
            AccountStateHandler openStateHandler, AccountStateHandler closeStateHandler,
            AccountEventArgs receiveStateHandler, AccountEventArgs WithdrawStateHandler,
            AccountEventArgs percentageStateHandler)
        {

        }

        //account's closing
        public void Close(int id)
        {

        }

        //receiving money
        public void Receive(decimal sum, int id)
        {

        }

        //withdrawing money
        public void Withdraw(decimal sum, int id)
        {

        }

        //percentage calculating
        public void CalculatePercentage()
        {

        }

        //finds account by id
        public T FindAccount(int id)
        {
            return default(T);
        }

        //finds accound by id and it's index
        public T FindAccount(int id, out int index)
        {
            index = 0;
            return default(T);
        }



    }
}
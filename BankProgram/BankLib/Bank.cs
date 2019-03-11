using System;
using System.Collections.Generic;

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
        //result: addidtion of a new account to the list of existing accounts
        public void Open(AccountType accountType, decimal sum, float percentage,
            AccountStateHandler openStateHandler, AccountStateHandler closeStateHandler,
            AccountStateHandler receiveStateHandler, AccountStateHandler WithdrawStateHandler,
            AccountEventArgs percentageStateHandler, int period = 0)
        {
            T newAccount = default(T);

            switch(accountType) 
            {
                case AccountType.Demand:
                    newAccount = new DemandAccount(sum, percentage) as T;
                    break;
                case AccountType.Deposit:
                    newAccount = new DepositAccount(sum, percentage, period) as T;
                    break;
                default: 
                    throw new Exception("Error while creating account");
            }

            newAccount.Opened += openStateHandler;
            newAccount.Closed += closeStateHandler;
            newAccount.Received += receiveStateHandler;
            newAccount.Withdrawed += WithdrawStateHandler;

            accounts.Add(newAccount);
        }

        //account's closing
        public void Close(int id)
        {
            int index;
            T account = FindAccount(id, out index);
            if(account == null)
                throw new Exception("Account not found");

            account.Close();
            accounts.RemoveAt(index);
        }

        //receiving money
        public void Receive(decimal sum, int id)
        {
            T account = FindAccount(id);
            if(account == null)
                throw new Exception("Account not found");
            account.Receive(sum);
        }

        //withdrawing money
        public void Withdraw(decimal sum, int id)
        {
            T account = FindAccount(id);
            if(account == null)
                throw new Exception("Account not found");
            account.Withdraw(sum);
        }

        //percentage calculating
        public void CalculatePercentage()
        {
            for(int i=0; i < accounts.Count; i++)
            {
                T account = accounts[i];
                account.DaysIncrement();
                account.CalculatePercentage();
            }
        }

        //finds account by it's id
        public T FindAccount(int id)
        {
            T result = default(T);
            for(int i=0; i < accounts.Count; i++)
            {
                if(accounts[i].Id == id)
                    result = accounts[i];
            }
            return result;
        }

        //finds account by it's id and index
        public T FindAccount(int id, out int index)
        {
            index = -1;
            T result = default(T);
            for(int i=0; i < accounts.Count; i++)
            {
                if(accounts[i].Id == id)
                {
                    result = accounts[i];
                    index = i;
                }
            }
            return result;
        }



    }
}
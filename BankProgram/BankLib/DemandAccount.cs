namespace BankLib
{
    public class DemandAccount : Account
    {
        public DemandAccount(decimal sum, float percentage) : base(sum, percentage) {}

        protected internal override void Open()
        {
            base.OnOpen(new AccountEventArgs(
                $"New demand account {Id} opened. Current sum: {Sum}", Sum));
        }
    }
}
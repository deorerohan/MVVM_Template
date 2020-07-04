namespace Model
{
    class Account
    {
        static uint CurrentID = 0;

        public uint AccountID
        {
            get; private set;
        }

        public uint CustomerID
        {
            get; private set;
        }

        public double AccountBalance
        {
            get; private set;
        }

        public Account(uint customerID)
        {
            AccountID = CurrentID++;
            CustomerID = customerID;
            AccountBalance = 0;
        }

        public void UpdateMoney(double money)
        {
            AccountBalance += money;
        }
    }
}